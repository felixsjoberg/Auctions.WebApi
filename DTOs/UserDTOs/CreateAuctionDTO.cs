using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.UserDTOs
{
    public class CreateAuctionDTO
    {
        // osäker på om StartDate ska ligga med här, därav en DTO!
        [Required]
        public int AuctionID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int Price { get; set; }
        [Required]
        public string StartDate { get; set; } = null!;
        [Required]
        public string EndDate { get; set; } = null!;
        [Required]
        public bool Status { get; set; }
    }
}
