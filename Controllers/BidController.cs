using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Models;
using Auctions.WebApi.Repository.Interfaces;
using Auctions.WebApi.Repository.Repos;
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
       
            if (auction[0].UserId.UserId == bid.UserId)
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

