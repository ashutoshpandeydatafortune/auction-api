import Image from 'next/image';
import React from 'react';

type Props = {
    auction: any
};

export default function AuctionCard({ auction }: Props) {
    return (
        <a href='#'>
            <div className='w-full mx-auto bg-gray-200 aspect-w-16 aspect-h-10 rounded-lg overflow-hidden'>
                <Image
                    src={auction.imageUrl}
                    width={200}
                    height={100}
                    className='object-cover'
                    alt='image'
                    sizes='(max-width:768px) 100vw, (max-width: 1200px) 50vw, 25vw' />
            </div>

        </a>
    )
}