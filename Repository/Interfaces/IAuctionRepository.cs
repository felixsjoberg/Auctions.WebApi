using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IAuctionRepository
    {
        Task<Boolean> CreateAuction(CreateAuctionDTO action);
        //Jag har börjat på UpdateAuction men den tillhör inte min Item så jag avslutar här!
        Task<Auction?> UpdateAuction(UpdateAuctionDTO auction);
    }
}
