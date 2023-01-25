using System;
using Auctions.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.AuctionDTOs;

public class AuctionDTO
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
    public Guid UserId { get; set; }
}

