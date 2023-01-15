using System.Data;
using System.Data.SqlClient;
using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Auctions.WebApi.Repository.Repos;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConfiguration connectionString)
    {
        _connectionString = connectionString.GetConnectionString("Default");
    }
    public async Task<Boolean> RegisterUser(RegisterDTO user)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            DynamicParameters para = new DynamicParameters();
            para.Add("@UserName", user.Username);
            para.Add("@Email", user.Email);
            
            var userExist = await db.QuerySingleOrDefaultAsync<User?>("UserExist", para, commandType: CommandType.StoredProcedure); 
            if (userExist is null)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", Guid.NewGuid());
                parameters.Add("@UserName", user.Username);
                parameters.Add("@Email", user.Email);
                parameters.Add("@Password", user.Password);
                db.ExecuteScalar("CreateUser", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
                return false;
        }
    }
    public async Task<User?> LoginUser(LoginDTO userLogin)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@username", userLogin.Username);
            parameters.Add("@password", userLogin.Password);
            var result = await db.QuerySingleOrDefaultAsync<User?>("LoginUser", parameters, commandType: CommandType.StoredProcedure);
            return result is not null ? result : null;
        }
    }
     public async Task<User?> GetUserByEmail(string email)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            var result = await db.QuerySingleOrDefaultAsync<User?>("GetUserByEmail", new { email }, commandType: CommandType.StoredProcedure);
            return result is not null ? result : null;
        }
    }

}