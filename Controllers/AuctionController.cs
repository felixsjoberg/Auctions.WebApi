using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.DTOs;
using Auctions.WebApi.Repository.Repos;
using BankApplication.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auctions.WebApi.Repository.Interfaces;

namespace Auctions.WebApi.Controllers;


[Route("Auction")]
[ApiController]
public class AuctionController : ControllerBase
{

    // jag lägger till Auctiondelen men sparar övriga två eftersom användare måste vara inloggad för att lägga ett bud
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IAuctionRepository _auctionRepository;
    public AuthenticationController(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var user = await _userRepository.LoginUser(loginDTO);
        var token = _jwtTokenGenerator.GenerateToken(user);
        UserDTO userDTO = new UserDTO
        {
            User = user,
            Token = token
        };
        return user is not null ? Ok(userDTO) : NotFound();
    }

    [HttpPost("createauction")]
    public async Task<IActionResult> CreateAuctionAsync(AuctionDTO auction)
    {
        var createdAuction = await _auctionRepository.CreatedAuction(auction);

        return createdAuction == true ? Ok("Auction created successfully") : BadRequest("Auction was not created, please try again");
    }

    // Den här hör till någon annan Item egentligen
    [Authorize]
    [HttpPut("updateauction")]
    public async Task<IActionResult> UpdateAuction(UpdateAuctionDTO update)
    {
        var auction = await _auctionRepository.UpdateAuction(update);
        return auction is not null ? Ok($"Update was Successful for AuctionID=\n{auction.AuctionId}") : NotFound();
    }
}