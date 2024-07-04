using AuctionService.DTO;
using AuctionService.Entities;

namespace AuctionService.Repositories
{
    public interface IAuctionRepository
    {
        Task<bool> SaveChangesAsync();
        void AddAuction(Auction auction);
        void RemoveAuction(Auction auction);
        Task<Auction> GetAuctionEntityById(Guid id);
        Task<AuctionDTO> GetAuctionByIdAsync(Guid id);
        Task<List<AuctionDTO>> GetAuctionsAsync(string date);
    }
}
