'use server'

import { Auction, PagedResult } from "../../../types";
import { fetchWrapper } from "../../../lib/fetchWrapper";

export async function getData(query: string): Promise<PagedResult<Auction>> {
    return await fetchWrapper.get(`search${query}`);
}

export async function updateAuctionTest() {
    const data = {
        mileage: Math.floor(Math.random() * 100000) + 1
    }

    return await fetchWrapper.put(`auctions/155225c1-4448-4066-9886-6786536e05ea`, data);
}