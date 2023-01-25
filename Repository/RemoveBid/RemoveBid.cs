using System.Data;
using System.Data.SqlClient;
using System;

namespace Auctions.WebApi.Repository.RemoveBid
{
    public class RemoveBidRepo
    {
        private readonly string connectionString;
        public RemoveBidRepo(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public void RemoveBid(int auctionId, int bidId, Guid userId, int bidPrice, DateTime bidDate, bool status)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("RemoveBid", (SqlConnection)db))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AuctionID", auctionId);
                    command.Parameters.AddWithValue("@BidId", bidId);
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@BidPrice", bidPrice);
                    command.Parameters.AddWithValue("@BidDate", bidDate);
                    command.Parameters.AddWithValue("@Status", status);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
