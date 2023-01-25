using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.Models;
public class User
{
    [Key]
    public Guid UserId { get; set; } = Guid.NewGuid();
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public List<Bid>? Bids;
    public Auction? Auction;
}

