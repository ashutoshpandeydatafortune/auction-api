'use server'

import { Auction, Bid, PagedResult } from "../../../types";
import { fetchWrapper } from "../../../lib/fetchWrapper";
import { FieldValues } from "react-hook-form";

export async function getData(query: string): Promise<PagedResult<Auction>> {
    return await fetchWrapper.get(`search${query}`);
}

export async function createAuction(data: FieldValues) {
    return await fetchWrapper.post(`auctions`, data);
}

export async function getAuctionDetail(id: string): Promise<Auction> {
    return await fetchWrapper.get(`auctions/${id}`);
}

export async function updateAuction(id: string, data: FieldValues) {
    return await fetchWrapper.put(`auctions/${id}`, data);
}

export async function deleteAuction(id: string) {
    return await fetchWrapper.del(`auctions/${id}`);
}

export async function getBidsForAuction(id: string): Promise<Bid[]> {
    return await fetchWrapper.get(`bids/${id}`);
}

export async function updateAuctionTest() {
    const data = {
        mileage: Math.floor(Math.random() * 100000) + 1
    }

    return await fetchWrapper.put(`auctions/155225c1-4448-4066-9886-6786536e05ea`, data);
}
