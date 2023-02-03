namespace Auctions.WebApi.DTOs.BidDTO;

public class BidDTO
{
    public int BidId { get; set; }
    public int BidPrice { get; set; }
    public DateTime BidDate { get; set; }
    public Guid UserId { get; set; }
    public int AuctionId { get; set; }
}