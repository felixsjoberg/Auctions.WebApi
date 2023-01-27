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
        private readonly IBidRepository _bidRepository;

        public AuctionRepository(IConfiguration connectionString, IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
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

        public async Task<Auction?> UpdateAuction(UpdateAuctionDTO auction)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT(*) FROM Bids WHERE AuctionId = @auctionId";
                var bidCount = await db.QueryFirstOrDefaultAsync<int>(sql, new { auctionId = auction.AuctionID });
                //AUGUST: Har ej gått igenom denna, du får testa se till att allt fungerar som du tänkt.

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@AuctionID", auction.AuctionID);
                parameters.Add("@Title", auction.Title);
                parameters.Add("@Description", auction.Description);
                parameters.Add("@EndDate", auction.EndDate);
                parameters.Add("@Status", auction.Status);
                if (bidCount == 0)
                {
                    parameters.Add("@Price", auction.Price);
                }
                else
                {
                    parameters.Add("@Price", 0);
                }
                var updatedAuction = await db.QueryFirstOrDefaultAsync<Auction>("UpdateAuction", parameters, commandType: CommandType.StoredProcedure);
                await db.ExecuteScalarAsync("UpdateAuction", parameters, commandType: CommandType.StoredProcedure);
                return updatedAuction;
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
        public async Task<IEnumerable<AuctionDTO>>? GetAllAuctions()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result =  await db.QueryAsync<AuctionDTO?>("GetAllAuctions");
                return result is not null ? result : null;
            }
        }
        public async Task<Boolean> RemoveAuction(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var bids=  _bidRepository.GetBidsByAuctionId(id);
                //AUGUST: gör så att det inte går att ta bort en med bud, 
                //denna fungerar med att ta bort, men har den bud så kommer denna funktion nog få error,
                //hantera dem.
                var result = await db.ExecuteScalarAsync("RemoveAuction", new { @AuctionId = id }, commandType: CommandType.StoredProcedure);
                return result is not null ? false : true;
            }
        }
    }
}
