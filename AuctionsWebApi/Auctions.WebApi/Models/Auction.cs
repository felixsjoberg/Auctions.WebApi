using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.Models;
public class Auction
{
    [Key]
    public int AuctionId { get; set; }
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public int Price { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public Boolean Status { get; set; }
    public User UserId { get; set; } =null!;
    public List<Bid>? Bids { get; set; }
}