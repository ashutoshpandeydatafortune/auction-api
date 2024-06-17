import React from 'react'

export default function UpdateAuction({ params }: { params: { id: string } }) {
    return (
        <div>update for {params.id}</div>
    )
}
