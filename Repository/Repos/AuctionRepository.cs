using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Auctions.WebApi.Repository.Interfaces;

namespace Auctions.WebApi.Repository.Repos
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly string _connectionString;

        public AuctionRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Default");
        }
        public async Task<Boolean> CreateAuction(CreateAuctionDTO auction)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                para.Add("@Description", auction.Description);
                para.Add("@Price", auction.Price);
                para.Add("@StartDate", auction.StartDate);
                // alternativt ska detta taggas med dagens datum
                para.Add("@EndDate", auction.EndDate);
                //status ska väl inte vara med
                para.Add("@Status", auction.Status);
                    public int AuctionId { get; set; }

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
    }
}
