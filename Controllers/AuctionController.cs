using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Models;
using Auctions.WebApi.Repository.Interfaces;
using Auctions.WebApi.Repository.Repos;
using BankApplication.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.WebApi.Controllers;


[Route("Auction")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly IAuctionRepository _auctionRepository;
    public AuctionController(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
      
    }
    [HttpGet("{auctionId}/bids")]
    public async Task <ActionResult<List<BidDTO>>> GetBidsByAuctionId(int auctionId)
    {
        var bids = await _auctionRepository.GetBidsByAuctionId(auctionId);
        if (bids == null)
        {
            return NotFound();
        }
        return bids;
    }
}




















    /*
    [HttpGet("{id}")]
    public IActionResult GetOpenAuctionById(int id)
    {
        var auction = _auctionRepository.GetOpenAuctionById(id);

        if (auction == null)
        {
            return NotFound("No open auction found with the provided ID.");
        }
        return Ok(auction);
    }
    */


