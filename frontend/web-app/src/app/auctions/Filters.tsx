import { Button, ButtonGroup } from 'flowbite-react'
import React from 'react'

type Props = {
    pageSize: number;
    filterSizes: number[];
    setPageSize: (size: number) => void;
}

export default function Filters({ pageSize, setPageSize, filterSizes }: Props) {
    return (
        <div className='flex justify-between items-center mb-4'>
            <div>
                <span className='uppercase text-sm text-gray-500 m4-2'>Page size</span>
                <ButtonGroup>
                    {filterSizes.map((value, i) => (
                        <Button
                            key={i}
                            onClick={() => setPageSize(value)}
                            color={`${pageSize === value ? 'red' : 'gray'}`}
                        >{value}</Button>
                    ))}
                </ButtonGroup>
            </div>
        </div>
    )
}