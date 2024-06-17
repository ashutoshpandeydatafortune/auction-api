import React from 'react'

export default function AuctionDetails({ params }: { params: { id: string } }) {
    return (
        <div>details for {params.id}</div>
    )
}
