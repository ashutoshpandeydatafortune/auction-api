import React from 'react';

import AuthTest from './AuthTest';
import Heading from '../components/Heading';
import { getSession, getTokenWorkaround } from '../actions/authActions';

export default async function Session() {
    const session = await getSession();
    const token = await getTokenWorkaround();

    return (
        <div className='px-4 py-4'>
            <Heading title='Session dashboard' />

            <div className='bg-blue-200 border-2 border-blue-500 overflow-x-auto'>
                <h3 className='text-lg'>Session data</h3>
                <pre>{JSON.stringify(session, null, 2)}</pre>
            </div>
            <div className='mt-4'>
                <AuthTest />
            </div>
            <div className='bg-green-200 border-2 border-value-500 mt-4 overflow-x-auto'>
                <h3 className='text-lg'>Token data</h3>
                <pre>{JSON.stringify(token, null, 2)}</pre>
            </div>
        </div>
    )
}
