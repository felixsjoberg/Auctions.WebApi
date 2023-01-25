using System.ComponentModel.DataAnnotations;

namespace Auctions.WebApi.DTOs.UserDTOs
{
    public class UpdateAuctionDTO
    {
        [Required]
        public int AuctionID { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public int Price { get; set; }

        //här ska StartDate inte finnas med väl
        //[Required]
        //public string StartDate { get; set; } = null!;
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
