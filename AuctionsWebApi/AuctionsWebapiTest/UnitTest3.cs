using AuctionsTest;
using System.Security.Cryptography.X509Certificates;

namespace AuctionsTest
{
    public class UnitTest3
    {
        [Fact]
        public void Test3()
        {
            //arrange
            int bidUserID = 1;
            int auctionOwnerUserID = 1;

            //Act
            PlaceBid bid = new PlaceBid();
            bool tryBidResult = bid.TryPlaceBid(bidUserID, auctionOwnerUserID);

            //Assert
            Assert.False(tryBidResult);
        }
    }
}