'use client'

import React, { useEffect } from 'react'
import { Button, TextInput } from 'flowbite-react';
import { FieldValues, useForm } from 'react-hook-form'
import Input from '../components/Input';
import DateInput from '../components/DateInput';

export default function AuctionForm() {
    const { control, handleSubmit, setFocus,
        formState: { isSubmitting, isValid, isDirty, errors } } = useForm({
            mode: 'onTouched'
        });

    useEffect(() => {
        setFocus('make');
    }, [setFocus])

    function onSubmit(data: FieldValues) {

    }

    return (
        <form className='flex flex-col mt-3' onSubmit={handleSubmit(onSubmit)}>
            <div className='mb-3 block'>
                <Input label='Make' name='make' control={control} rules={{ required: 'Make is required' }} />
                <Input label='Model' name='model' control={control} rules={{ required: 'Model is required' }} />

                <div className='grid grid-cols-2 gap-3'>
                    <Input label='Year' name='year' control={control} type='number' rules={{ required: 'Year is required' }} />
                    <Input label='Mileage' name='mileage' control={control} rules={{ required: 'Mileage is required' }} />
                </div>

                <Input label='Image URL' name='imageUrl' control={control} rules={{ required: 'Image URL is required' }} />

                <div className='grid grid-cols-2 gap-3'>
                    <Input label='Reserve Price (enter 0 if no reserve)' name='reservePrice' type='number' control={control} rules={{ required: 'Reserve price is required' }} />
                    <DateInput
                        label='Auction end date/time'
                        name='auctionEnd'
                        control={control}
                        dateFormat='dd MMM yyyy h:mm a'
                        showTimeSelect
                        rules={{ required: 'Auctoin end date is required' }}
                    />
                </div>

                <div className='flex justify-between'>
                    <Button outline color='gray'>Cancel</Button>
                    <Button
                        type='submit'
                        isProcessing={isSubmitting}
                        outline color='success'>Submit</Button>
                </div>
            </div>
        </form>
    )
}
