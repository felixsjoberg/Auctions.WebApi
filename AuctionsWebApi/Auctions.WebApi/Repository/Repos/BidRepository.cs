using System.Data;
using System.Data.SqlClient;
using Auctions.WebApi.Repository.Interfaces;
using Dapper;
using Auctions.WebApi.DTOs.BidDTO;

namespace Auctions.WebApi.Repository.Repos
{
    public class BidRepository : IBidRepository
    {
        private readonly string _connectionString;

        public BidRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Default");
        }

        public int PlaceBid(int auctionId, PlaceBidDTO bid)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                DynamicParameters para = new DynamicParameters();
                para.Add("@BidId", 0, DbType.Int32, direction: ParameterDirection.InputOutput);
                para.Add("@AuctionId", auctionId);
                para.Add("@BidPrice", bid.BidPrice);
                para.Add("@UserId", bid.UserId);
                para.Add("@BidDate", DateTime.Now);

                conn.ExecuteScalar("PlaceBid", para, commandType: CommandType.StoredProcedure);

                return para.Get<int>("@BidId");
            }
        }
        public async Task<Boolean> RemoveBid(int bidId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BidId", bidId);

                var result = await db.ExecuteAsync("RemoveBid", parameters, commandType: CommandType.StoredProcedure);
                return result <= 0 ? false : true;
            }
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
    }
}


