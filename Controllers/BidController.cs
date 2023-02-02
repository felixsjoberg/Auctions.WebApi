using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.WebApi.Controllers
{
    public class BidController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidRepository _bidRepository;
 
        public BidController(IAuctionRepository auctionRepository,IBidRepository bidRepository)
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
          

        }
      
        [HttpPost("{auctionId}/bids")]
        public async Task<IActionResult> PlaceBid(int id, PlaceBidDTO bid)
        {
            try
            {
                var auction = await _bidRepository.GetBidsByAuctionId(id);

                var auctions = await _auctionRepository.GetAuctionByID(id);

                var highestBid = await _bidRepository.GetHighestBidByAuctionId(id);

                if (auction == null)
                {
                    return NotFound();
                }
                if (bid.UserId == auctions.UserId)
                {
                    return BadRequest("User can not bid on their own auction.");
                }
                await _bidRepository.PlaceBid(id, bid);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}