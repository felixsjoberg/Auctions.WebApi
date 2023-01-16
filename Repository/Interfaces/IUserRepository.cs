using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;

namespace Auctions.WebApi.Repository.Repos
{
    public interface IUserRepository
    {
         Task<Boolean> RegisterUser(RegisterDTO user);
         Task<User?> LoginUser(LoginDTO loginDTO);
         Task<User?> GetUserByEmail(string email);
         Task<User?> UpdateUser(UpdateDTO user);
    }
}