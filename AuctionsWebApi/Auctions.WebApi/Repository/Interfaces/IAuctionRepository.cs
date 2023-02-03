using Auctions.WebApi.DTOs.AuctionDTOs;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IAuctionRepository
    {
        Task<int> CreateAuction(CreateAuctionDTO action);
        Task<AuctionDTO?> UpdateAuction(UpdateAuctionDTO auction);
        Task<AuctionDTO?> GetAuctionByID(int ID);
        Task<IEnumerable<AuctionDTO>>? GetAllAuctions();
        Task<Boolean> RemoveAuction(int id);
    }
}
