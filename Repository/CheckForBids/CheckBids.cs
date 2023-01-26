using System;

public class CheckBids
{
	public CheckBids()
	{
        using System.Linq;
        using Dapper;
        using System.Data.SqlClient;

        public async Task<bool> CheckForBids(int auctionId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT * FROM Bids WHERE AuctionId = @auctionId";
                var bidCount = await db.QueryFirstOrDefaultAsync<int>(sql, new { auctionId });

                return bidCount == 0;
            }
        }
    }
}
