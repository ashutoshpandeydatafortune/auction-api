import NextAuth from "next-auth";
import { authOptions } from "app/actions/authOptions";

export default NextAuth(authOptions);
