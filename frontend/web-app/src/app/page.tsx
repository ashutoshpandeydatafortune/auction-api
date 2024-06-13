import Listings from "./auctions/Listings";

export default function Home() {
  console.log('home');
  return (
    <div>
      <h3 className="text-3xl font-semibold"></h3>
      <Listings />
    </div>
  );
}
