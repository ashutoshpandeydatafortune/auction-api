'use client'

import Search from './Search';
import Logo from './Logo';
import LoginButton from './LoginButton';
import { getCurrentUser } from '../actions/authActions';
import UserActions from './UserActions';

export default function Navbar() {
    const user = getCurrentUser();

    return (
        <header className="sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-gray-800 shadow-md">
            <Logo />
            <Search />
            {user ? (
                <UserActions user={user} />
            ) : (
                <LoginButton />
            )}
        </header>
    )
}