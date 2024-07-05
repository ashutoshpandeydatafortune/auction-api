'use client'

import React from 'react'
import Heading from './Heading';
import { Button } from 'flowbite-react';
import { signIn } from 'next-auth/react';
import { useParamsStore } from 'hooks/useParamsStore';

type Props = {
    title?: string
    subtitle?: string
    showLogin?: boolean
    showReset?: boolean
    callbackUrl?: string
};

export default function EmptyFilter({
    title = 'No matches found',
    subtitle = 'Try changing the filter',
    showLogin,
    showReset,
    callbackUrl
}: Props) {
    const reset = useParamsStore(state => state.reset);

    return (
        <div className='h-[40vh] flex flex-col gap-2 justify-center items-center shadow-lg'>
            <div className="text-2xl font-bold">
                <Heading title={title} subtitle={subtitle} />
                <div className='mt-4'>
                    {showReset && (
                        <Button outline onClick={reset}>Remove Filters</Button>
                    )}
                    {showLogin && (
                        <Button outline onClick={() => signIn('id-server', { callbackUrl })}>Login</Button>
                    )}
                </div>
            </div>
        </div>
    );
}