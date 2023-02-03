using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.Models;
public class Bid
{
    [Key]
    public int BidId { get; set; }
    [Required]
    public int BidPrice { get; set; }
    [Required]
    public DateTime BidDate { get; set; }
    public User UserId { get; set; } =null!;
    public Auction AuctionId { get; set; } =null!;
}