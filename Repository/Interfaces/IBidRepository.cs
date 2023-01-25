using System;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Interfaces
{
	public interface IBidRepository
    {
        public void PlaceBid(int auctionId, PlaceBidDTO bid);
    }
}

