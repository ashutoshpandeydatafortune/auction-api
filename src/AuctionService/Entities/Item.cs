﻿namespace AuctionService.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public int Year {  get; set; }  
        public int Milleage { get; set; }

        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Guid AuctionId { get; set; }
        public Auction Auction { get; set; }
    }
}
