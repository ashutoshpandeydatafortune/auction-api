import React from 'react'
import { Button, ButtonGroup } from 'flowbite-react'
import { useParamsStore } from '../../../hooks/useParamsStore';

type Props = {
    filterSizes: number[];
}

export default function Filters({ filterSizes }: Props) {
    const pageSize = useParamsStore(state => state.pageSize);
    const setParams = useParamsStore(state => state.setParams);

    return (
        <div className='flex justify-between items-center mb-4'>
            <div>
                <span className='uppercase text-sm text-gray-500 m4-2'>Page size: </span>
                <Button.Group>
                    {filterSizes.map((value, i) => (
                        <Button
                            key={i}
                            onClick={() => setParams({ pageSize: value })}
                            color={`${pageSize === value ? 'red' : 'gray'}`}
                        >{value}</Button>
                    ))}
                </Button.Group>
            </div>
        </div>
    )
}