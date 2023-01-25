using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.UserDTOs;
public class RegisterDTO
{
    [Required]
    public string Username { get; set; } =null!;
    [Required]
    public string Password { get; set; } =null!;
    [Required]
    public string Email { get; set; } =null!;
}