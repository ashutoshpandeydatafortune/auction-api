'use client'

import React from 'react'
import { useParamsStore } from '../../../hooks/useParamsStore';
import Heading from './Heading';
import { Button } from 'flowbite-react';

type Props = {
    title?: string
    subTitle?: string
    showReset?: boolean
};

export default function EmptyFilter({
    title = 'No matches found',
    subTitle = 'Try changing the filter',
    showReset
}: Props) {
    const reset = useParamsStore(state => state.reset);

    return (
        <div className='h-[40vh] flex flex-col gap-2 justify-center items-center shadow-lg'>
            <div className="text-2xl font-bold">
                <Heading title={title} subTitle={subTitle} />
                <div className='mt-4'>
                    {showReset && (
                        <Button outline onClick={reset}>Remove Filters</Button>
                    )}
                </div>
            </div>
        </div>
    );
}