import NextAuth from "next-auth";
import { authOptions } from "app/api/auth/authOptions";

console.log({
    id: 'id-server',
    clientId: 'nextApp',
    clientSecret: process.env.CLIENT_SECRET!,
    issuer: process.env.ID_URL,
    authorization: { params: { scope: 'openid profile auctionApp' } },
    idToken: true
});

const handler = NextAuth(authOptions);
export { handler as GET, handler as POST }
