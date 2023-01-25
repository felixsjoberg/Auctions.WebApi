using System;
using System.ComponentModel.DataAnnotations;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.DTOs.BidDTO
{
	public class PlaceBidDTO
	{
        
        [Required]
        public int BidPrice { get; set; }
        
        public Guid UserId { get; set; }
    }
}

