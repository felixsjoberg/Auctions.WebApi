using System.Data;
using System.Data.SqlClient;
using Auctions.WebApi.Repository.Interfaces;
using Dapper;
using Auctions.WebApi.DTOs.BidDTO;

namespace Auctions.WebApi.Repository.Repos
{
    public class BidRepository:IBidRepository
	{

        private readonly string _connectionString;

        public BidRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Default");
        }
      
        public void PlaceBid(int auctionId, PlaceBidDTO bid)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                DynamicParameters para = new DynamicParameters();
                para.Add("@AuctionId", auctionId);
                para.Add("@BidPrice", bid.BidPrice);
                para.Add("@UserId", bid.UserId);
                para.Add("@BidDate", DateTime.Now);

                conn.Execute("PlaceBid", para, commandType: CommandType.StoredProcedure);
            }
        }
    }
}


