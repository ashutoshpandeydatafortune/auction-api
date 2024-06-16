'use client'

import queryString from "query-string";
import { shallow } from "zustand/shallow";
import React, { useEffect, useState } from "react";

import Filters from "./Filters";
import AuctionCard from "./AuctionCard";
import { getData } from "../actions/auctionActions";
import EmptyFilter from "../components/EmptyFilter";
import { Auction, PagedResult } from "../../../types";
import AppPagination from "../components/AppPagination";
import { useParamsStore } from "../../../hooks/useParamsStore";

export default function Listings() {
    const [data, setData] = useState<PagedResult<Auction>>();
    const params = useParamsStore((state: any) => ({
        orderBy: state.orderBy,
        pageSize: state.pageSize,
        pageNumber: state.pageNumber,
        searchTerm: state.searchTerm
    }), shallow);

    const setParams = useParamsStore((state: any) => state.setParams);
    const url = queryString.stringifyUrl({ url: '', query: params });

    function setPageNumber(pageNumber: number) {
        setParams({ pageNumber });
    }

    useEffect(() => {
        getData(url).then((data: any) => {
            setData(data);
        });
    }, [url]);

    if (!data) {
        return <h3>Loading...</h3>
    }

    return (
        <>
            <Filters filterSizes={[4, 8, 12]} />
            {data.totalCount == 0 ? (
                <EmptyFilter showReset />
            ) : (
                <>
                    <div className="grid grid-cols-4 gap-6">
                        {data.results && data.results.map((auction: any) => {
                            return (
                                <AuctionCard auction={auction} key={auction.id} />
                            )
                        })}
                    </div >
                    <div className="flex justify-center mt-4">
                        <AppPagination pageChanged={setPageNumber} currentPage={params.pageNumber} pageCount={data.pageCount} />
                    </div>
                </>
            )
            }
        </>
    )
}