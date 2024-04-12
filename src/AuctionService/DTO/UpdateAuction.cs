using System.ComponentModel.DataAnnotations;

namespace AuctionService.DTO
{
    public class UpdateAuction
    {
        [Required]
        public int Year { get; set; }
        [Required]
        public int Milleage { get; set; }
        [Required]
        public int ReservePrice { get; set; }

        [Required]
        public string Make { get; set; } = string.Empty;
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public DateTime AuctionEnd { get; set; }
    }
}
