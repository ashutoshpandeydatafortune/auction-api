using AuctionService.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities
{
    [Table("Auctions")]
    public class Auction
    {
        public Guid Id { get; set; }
        public int? SoldAmount { get; set; }
        public int? CurrentHighBid { get; set; }
        public int ReservePrice { get; set; } = 0;

        public string Seller { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;

        public DateTime AuctionEnd { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public Item Item { get; set; }
        public Status Status { get; set; }

        public bool HasReservePrice() => ReservePrice > 0;
    }
}
