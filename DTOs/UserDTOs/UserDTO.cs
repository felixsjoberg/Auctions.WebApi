using Auctions.WebApi.Models;

namespace Auctions.WebApi.DTOs;
public class UserDTO
{
    public User User { get; set; } = null!;
    public string Token { get; set; } = null!;
}

