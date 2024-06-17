'use client'

import React, { useState } from 'react';
import { Button } from 'flowbite-react';
import { UpdateAuctionTest } from '../actions/auctionActions';

export default function AuthTest() {
    const [loading, setLoading] = useState(false);
    const [result, setResult] = useState();

    function doUpdate() {
        setResult(undefined);
        setLoading(true);
        UpdateAuctionTest()
            .then((res: any) => setResult(res))
            .finally(() => setLoading(false));
    }

    return (
        <div className='flex items-center gap-4 px-4'>
            <Button outline isProcessing={loading} onClick={doUpdate}>
                Test auth
            </Button>
            <div>
                {JSON.stringify(result, null, 2)}
            </div>
        </div>
    )
}
