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
        [HttpPost("{id}/bids")]
        public async Task <IActionResult> PlaceBid(int id, PlaceBidDTO bid)
        {
            var auction = await _auctionRepository.GetBidsByAuctionId(id);
            
            var auctions = await _auctionRepository.GetAuctionByID(id);

            if (auction == null)
            {
                return NotFound();
            }
            if (bid.UserId == auctions.UserId)
            {
                return BadRequest("User can not bid on their own auction.");
            }

            if (bid.BidPrice <= auctions.Price)
            {
                return BadRequest("Bid is too low.");
            }

            _bidRepository.PlaceBid(id, bid);
            return Ok();
        }
    }
}