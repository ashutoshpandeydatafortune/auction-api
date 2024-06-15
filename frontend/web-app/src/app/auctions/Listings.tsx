'use client'

import React, { useEffect, useState } from "react";

import Filters from "./Filters";
import AuctionCard from "./AuctionCard";
import { Auction } from "../../../types";
import { getData } from "../actions/auctionActions";
import AppPagination from "../components/AppPagination";

export default function Listings() {
    const [pageSize, setPageSize] = useState(4);
    const [pageCount, setPageCount] = useState(0);
    const [pageNumber, setPageNumber] = useState(1);
    const [auctions, setAuctions] = useState<Auction[]>([]);

    useEffect(() => {
        getData(pageNumber, pageSize).then((data: any) => {
            setAuctions(data.results);
            setPageCount(data.pageCount);
        });
    }, [pageNumber, pageSize]);

    if (!auctions || auctions.length == 0) {
        return <h3>Loading...</h3>
    }

    return (
        <>
            <Filters pageSize={pageSize} setPageSize={setPageSize} filterSizes={[4, 8, 12]} />
            <div className="grid grid-cols-4 gap-6">
                {auctions && auctions.map((auction: any) => {
                    return (
                        <AuctionCard auction={auction} key={auction.id} />
                    )
                })}
            </div>
            <div className="flex justify-center mt-4">
                <AppPagination pageChanged={setPageNumber} currentPage={pageNumber} pageCount={pageCount} />
            </div>
        </>
    )
}