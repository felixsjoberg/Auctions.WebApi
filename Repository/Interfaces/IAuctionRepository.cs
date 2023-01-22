using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Auction?> LoginUser(LoginDTO loginDTO);
        Task<Auction?> CreateAuction(int id);
        //Jag har börjat på UpdateAuction men den tillhör inte min Item så jag avslutar här!
        Task<Auction?> UpdateAuction(UpdateAuctionDTO auction);
    }
}
