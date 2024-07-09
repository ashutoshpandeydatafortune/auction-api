using AuctionService.Entities;
using Xunit.Abstractions;

public class AuctionTests
{
    private readonly ITestOutputHelper _output;

    public AuctionTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void HasReservePriceReservePriceGitZeroTrue()
    {
        var auction = new Auction
        {
            Id = Guid.NewGuid(),
            ReservePrice = 10
        };

        var result = auction.HasReservePrice();
        Assert.True(result);
    }

    [Fact]
    public void HasReservePriceReservePriceGitZeroFalse()
    {
        var auction = new Auction
        {
            Id = Guid.NewGuid(),
            ReservePrice = 0
        };

        var result = auction.HasReservePrice();
        Assert.False(result);
    }
}
