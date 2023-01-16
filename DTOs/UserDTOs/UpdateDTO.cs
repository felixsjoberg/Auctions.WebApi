using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.UserDTOs;
public class UpdateDTO
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Username { get; set; } =null!;
    [Required]
    public string Password { get; set; } =null!;
    [Required]
    public string Email { get; set; } =null!;
}