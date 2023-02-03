using Auctions.WebApi.Models;

namespace BankApplication.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
