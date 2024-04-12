using AuctionService.Entities.Enums;
using AuctionService.Entities;

namespace AuctionService.DTO
{
    public class AuctionDTO
    {
        public Guid Id { get; set; }
        public int? SoldAmount { get; set; }
        public int? CurrentHighBid { get; set; }
        public int ReservePrice { get; set; } = 0;

        public string Seller { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;

        public DateTime AuctionEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Status { get; set; } = string.Empty;

        public int Year { get; set; }
        public int Milleage { get; set; }

        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
