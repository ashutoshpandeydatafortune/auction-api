'use server'

import { fetchWrapper } from "../../../lib/fetchWrapper";
import { Auction, PagedResult } from "../../../types";

export async function getData(query: string): Promise<PagedResult<Auction>> {
    return await fetchWrapper.get(`search${query}`);
}

export async function UpdateAuctionTest() {
    const data = {
        mileage: Math.floor(Math.random() * 100000) + 1
    }

    const res = await fetch('http://localhost:6001/auctions', {
        method: 'PUT',
        headers: {},
        body: JSON.stringify(data)
    })

    if (!res.ok) return { status: res.status, message: res.statusText }

    return res.statusText;
}