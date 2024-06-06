namespace Contracts
{
    public class AuctionUpdated
    {
        public string Id { get; set; }
        public int? Year { get; set; }
        public int? Milleage { get; set; }
        public int ReservePrice { get; set; }

        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime AuctionEnd { get; set; }
    }
}
