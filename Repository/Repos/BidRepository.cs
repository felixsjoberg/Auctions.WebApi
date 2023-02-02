using System.Data;
using System.Data.SqlClient;
using Auctions.WebApi.Repository.Interfaces;
using Dapper;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Models;
using System.Data.Common;

namespace Auctions.WebApi.Repository.Repos
{
    public class BidRepository : IBidRepository
    {

        private readonly string _connectionString;

        public BidRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Default");
        }

       
        public async Task PlaceBid(int id, PlaceBidDTO bid)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                var currentHighestBid = await GetHighestBidByAuctionId(id);

                if (currentHighestBid == null || bid.BidPrice > currentHighestBid.BidPrice)
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@AuctionId", id);
                    para.Add("@BidPrice", bid.BidPrice);
                    para.Add("@UserId", bid.UserId);
                    para.Add("@BidDate", DateTime.Now);

                    conn.Execute("PlaceBid", para, commandType: CommandType.StoredProcedure);

                    var updateAuctionQuery = "UPDATE Auctions SET Price = @BidPrice WHERE AuctionId = @AuctionId";
                    await conn.ExecuteAsync(updateAuctionQuery, new { AuctionId = id, BidPrice = bid.BidPrice });

                }
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

        public async Task<BidDTO> GetHighestBidByAuctionId(int auctionId)
        {
           using (IDbConnection conn = new SqlConnection(_connectionString))
           {
              var query = "SELECT TOP 1 * FROM Bids WHERE AuctionId = @AuctionId ORDER BY BidPrice DESC";
              var result = await conn.QueryFirstOrDefaultAsync<BidDTO>(query, new { AuctionId = auctionId });

              return result;
            }
        }

    }
}
        
   

