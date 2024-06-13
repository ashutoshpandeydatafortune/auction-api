import AuctionCard from "./AuctionCard";

async function getData() {
    const res = await fetch('http://localhost:6001/search?pageSize=10&pageNumber=1');

    if (res.status != 200) {
        console.log('Failed to fetch data');
        return {}
    }

    return res.json();
}

export default async function Listings() {
    const data = await getData();
    return (
        <div className="grid grid-cols-4 gap-6">
            {data && data.results && data.results.map((auction: any) => {
                return (
                    <AuctionCard auction={auction} key={auction.id} />
                )
            })}
        </div>
    )
}