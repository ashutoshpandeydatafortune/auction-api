using AuctionService.Entities;

namespace AuctionService.Repositories
{
    public interface IAuctionRepository
    {
        Task<Auction> GetAuctionByIdAsync(Guid id);
        Task<IEnumerable<Auction>> GetAllAuctionsAsync();
        Task AddAuctionAsync(Auction auction);
        Task UpdateAuctionAsync(Auction auction);
        Task DeleteAuctionAsync(Guid id);
    }
}
