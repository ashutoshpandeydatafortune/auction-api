'use client'

import { Dropdown } from 'flowbite-react'
import { User } from 'next-auth'
import React from 'react';
import Link from 'next/link';
import { signOut } from 'next-auth/react';
import { HiCog, HiUser } from 'react-icons/hi';
import { AiFillCar, AiFillTrophy, AiOutlineLogout } from 'react-icons/ai';

type Props = {
    user: Partial<User>
}

export default function UserActions({ user }: Props) {
    return (
        <Dropdown inline label={`Welcome ${user.name}`}>
            <Dropdown.Item icon={HiUser}>
                <Link href='/'>My Auctions</Link>
            </Dropdown.Item>
            <Dropdown.Item icon={AiFillTrophy}>
                <Link href='/'>Auctions Won</Link>
            </Dropdown.Item>
            <Dropdown.Item icon={AiFillCar}>
                <Link href='/'>Sell My Car</Link>
            </Dropdown.Item>
            <Dropdown.Item icon={HiCog}>
                <Link href='/session'>Session (Dev Only)</Link>
            </Dropdown.Item>
            <Dropdown.Divider></Dropdown.Divider>
            <Dropdown.Item icon={AiOutlineLogout} onClick={() => signOut({ callbackUrl: '/' })}>
                Sign Out
            </Dropdown.Item>
        </Dropdown>
    )
}
