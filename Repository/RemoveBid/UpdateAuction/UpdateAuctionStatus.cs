using System;

public class UpdateAuctionStatus
{
	public UpdateAuctionStatus()
	{
        if (auction.EndDate < DateTime.Now)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Auctions SET Status = 'Closed' WHERE AuctionID = @AuctionID";
                await db.ExecuteAsync(sql, new { AuctionID = parameters.Get<int>("@AuctionID") });
            }
        }
    }
}
