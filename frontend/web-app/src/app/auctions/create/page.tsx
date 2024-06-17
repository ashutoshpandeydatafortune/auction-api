import React from 'react'

import AuctionForm from '../AuctionForm'
import Heading from '@/app/components/Heading'

export default function CreateAuction() {
    return (
        <div className='max-auto max-w-[75%] shadow-lg p-10 bg-white rounded-lg'>
            <Heading title='Sell your car!' subTitle='Please enter the details of your car' />
            <AuctionForm />
        </div>
    )
}
