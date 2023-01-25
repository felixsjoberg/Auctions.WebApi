using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.DTOs.BidDTO;
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

    // jag l�gger till Auctiondelen men sparar �vriga tv� eftersom anv�ndare m�ste vara inloggad f�r att l�gga ett bud
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IAuctionRepository _auctionRepository;
    public AuctionController(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IAuctionRepository auctionRepository)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _auctionRepository = auctionRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAuctionAsync(CreateAuctionDTO auction)
    {
        var createdAuction = await _auctionRepository.CreateAuction(auction);

        return Ok($"Auction created successfully with id {createdAuction}");
    }

    // Den h�r h�r till n�gon annan Item egentligen
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateAuction(UpdateAuctionDTO update)
    {
        var auction = await _auctionRepository.UpdateAuction(update);
        return auction is not null ? Ok($"Update was Successful for AuctionID=\n{auction.AuctionId}") : NotFound();
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