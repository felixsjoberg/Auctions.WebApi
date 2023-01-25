using Auctions.WebApi.DTOs.AuctionDTOs;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IAuctionRepository
    {
        Task<int> CreateAuction(CreateAuctionDTO action);
        Task<Auction?> UpdateAuction(UpdateAuctionDTO auction);
        Task<List<BidDTO>> GetBidsByAuctionId(int auctionId);
        Task<AuctionDTO?> GetAuctionByID(int ID);
    }
}
