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
        public async Task<int> CreateAuction(CreateAuctionDTO auction)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AuctionID", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                parameters.Add("@UserID", auction.UserID);
                parameters.Add("@Title", auction.Title);
                parameters.Add("@Description", auction.Description);
                parameters.Add("@Price", auction.Price);
                parameters.Add("@StartDate", DateTime.Now);
                parameters.Add("@EndDate", auction.EndDate);
                db.ExecuteScalar("CreateAuction", parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@AuctionID");
            }   
        }

        public Task<Auction?> UpdateAuction(UpdateAuctionDTO auction)
        {
            throw new NotImplementedException();
        }
    }
}
