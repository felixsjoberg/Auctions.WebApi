using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.BidDTO
{
    public class PlaceBidDTO
	{   
        [Required]
        public int BidPrice { get; set; }       
        public Guid UserId { get; set; }
    }
}

