import { signIn } from "next-auth/react";

export const config = {
    matcher: [
        '/session'
    ],
    pages: {
        signIn: '/api/auth/signin'
    }
}