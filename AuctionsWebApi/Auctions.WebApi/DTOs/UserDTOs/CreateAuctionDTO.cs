using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.UserDTOs
{
    public class CreateAuctionDTO
    {

        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        
        public DateTime EndDate { get; set; }
        
    }
}
