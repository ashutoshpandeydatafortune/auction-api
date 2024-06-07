using AuctionService.DB;
using AuctionService.Entities.Enums;
using Contracts;
using MassTransit;

namespace AuctionService.Consumers
{
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        private AuctionDBContext _dbContext;

        public AuctionFinishedConsumer(AuctionDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            var auction = await _dbContext.Auctions.FindAsync(context.Message.AuctionId);

            if(context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = context.Message.Amount;
            }

            auction.Status = auction.SoldAmount > auction.ReservePrice ? Status.FINISHED : Status.RESERVE_NOT_MET;

            await _dbContext.SaveChangesAsync();
        }
    }
}
