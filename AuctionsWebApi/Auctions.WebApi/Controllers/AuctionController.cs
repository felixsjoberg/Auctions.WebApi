using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Repository.Interfaces;
using Auctions.WebApi.Repository.Repos;
using BankApplication.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.WebApi.Controllers;

[Authorize]
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAuction(int id)
    {
        var removed = await _auctionRepository.RemoveAuction(id);

        return removed is true ? Ok("Successfully removed auction") : NotFound("Not a valid Auction or Auction has bids already.");
    }

    
    [HttpPut]
    public async Task<IActionResult> UpdateAuction(UpdateAuctionDTO update)
    {
        var auction = await _auctionRepository.UpdateAuction(update);
        return auction is not null ? Ok($"Update was Successful for AuctionID={auction.AuctionId}") : NotFound("Didn't find the auction or can't update auctionPrice");
    }

    [AllowAnonymous]
    [HttpGet]
        public async Task<IActionResult> GetAllAuctions()
        {
            var auctions = await _auctionRepository.GetAllAuctions();
            return auctions is null? NotFound() : Ok(auctions);
        }
    [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
             var auction = await _auctionRepository.GetAuctionByID(id);
          
            if (auction == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(auction);
            }
        }
}