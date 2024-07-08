import React from 'react'
import DatePicker from "react-datepicker";
import { DatePickerProps } from 'react-datepicker';
import { UseControllerProps, useController } from 'react-hook-form'

type Props = {
    label: string
    type?: string
    showLabel?: string
} & UseControllerProps & Partial<DatePickerProps>

export default function DateInput(props: Props) {
    const { fieldState, field } = useController({ ...props, defaultValue: '' });

    return (
        <div className='block'>
            <DatePicker
                {...field}
                placeholderText={props.label}
                onChange={date => field.onChange(date)}
                selected={field.value ? new Date(field.value) : null}
                className={`rounded-lg w-full flex flex-col 
                    ${fieldState.error ? 'bg-red-50 border-red-500 text-red-900' :
                        (!fieldState.invalid && fieldState.isDirty) ?
                            'bg-green-50 border-green-500 text-green-900' : ''}`}
            />

            {fieldState.error && (
                <div className='text-red-500 text-sm'>
                    {fieldState.error.message}
                </div>
            )}
        </div>
    )
}
