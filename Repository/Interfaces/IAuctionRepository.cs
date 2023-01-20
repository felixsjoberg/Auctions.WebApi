using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Auction?> LoginUser(LoginDTO loginDTO);
        Task<Auction?> GetAuctionByID(int id);
        Task<Auction?> UpdateAuction(AuctionUpdateDTO auction);
    }
}
