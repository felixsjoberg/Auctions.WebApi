using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.WebApi.Controllers
{
    [Authorize]
    public class BidController : ControllerBase
    {
        private readonly IAuctionRepository _auctionRepository;
        private readonly IBidRepository _bidRepository;

        public BidController(IAuctionRepository auctionRepository, IBidRepository bidRepository)
        {
            _auctionRepository = auctionRepository;
            _bidRepository = bidRepository;
        }         
        [HttpGet("{auctionId}/bids")]
        public async Task<ActionResult<List<BidDTO>>> GetBidsByAuctionId(int auctionId)
        {
            var bids = await _bidRepository.GetBidsByAuctionId(auctionId);
            if (bids == null)
            {
                return NotFound();
            }
            return bids;
        }
        [Authorize]
        [HttpPost("{id}/bids")]
        public async Task<IActionResult> PlaceBid(int id, PlaceBidDTO bid)
        {
            var auction = await _bidRepository.GetBidsByAuctionId(id);

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

            return Ok( _bidRepository.PlaceBid(id, bid));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBid(int id)
        {
            var result = await _bidRepository.RemoveBid(id);
            return result is false ? NotFound() : Ok();
        }
    }
}