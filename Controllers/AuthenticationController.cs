using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;
using Auctions.WebApi.Repository.Repos;
using BankApplication.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auctions.WebApi.Controllers;

[Route("auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthenticationController(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterDTO user)
    {
        var registeredUser = await _userRepository.RegisterUser(user);

        return registeredUser == true ? Ok("Account Created Successfully") : BadRequest("Email or Username already Exist");
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        var user = await _userRepository.LoginUser(loginDTO);
        var token =_jwtTokenGenerator.GenerateToken(user);
        return user is not null ? Ok(token) : BadRequest();
    }
}