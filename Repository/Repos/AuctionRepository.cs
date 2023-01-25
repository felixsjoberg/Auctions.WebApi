using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Auctions.WebApi.Repository.Interfaces;
using Auctions.WebApi.DTOs.AuctionDTOs;
using Auctions.WebApi.DTOs.BidDTO;

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
           public async Task<List<BidDTO>> GetBidsByAuctionId(int auctionId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@AuctionID", auctionId);
                return connection.Query<BidDTO>("searchopenAuctionbids", param, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public async Task<AuctionDTO?> GetAuctionByID(int ID)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var param = new DynamicParameters();
                param.Add("@ID", ID);
                var result =  await db.QuerySingleOrDefaultAsync<AuctionDTO?>("GetInfoFromAuctionByID", param, commandType: CommandType.StoredProcedure);
                return result is not null ? result : null;
            }
        }
    }
}
