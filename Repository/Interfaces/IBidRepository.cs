using Auctions.WebApi.DTOs.BidDTO;

namespace Auctions.WebApi.Repository.Interfaces
{
    public interface IBidRepository
    {
        int PlaceBid(int auctionId, PlaceBidDTO bid);
        Task<List<BidDTO>> GetBidsByAuctionId(int auctionId);
        Task <Boolean> RemoveBid(int bidId);
    }
}

