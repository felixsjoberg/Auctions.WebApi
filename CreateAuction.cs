
namespace Auctions.WebApi
{
    public class CreateAuction : Auctions
    {
        // Här gör vi en ny auktion

        public string AuctionEndDate;
        public int UserInput;
        public string NewAuction()
        {
            AuctionEndDate = DateTime.UtcNow.Date().ToString + UserInput;
        }
    }

}
