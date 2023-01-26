using Auctions.WebApi.DTOs.AuctionDTOs;
using Dapper;
using System.Data.SqlClient;

public async Task<Auction> UpdateAuction(UpdateAuctionDTO auction)
{
    using (IDbConnection db = new SqlConnection(_connectionString))
    {
        var sql = "SELECT COUNT(*) FROM Bids WHERE AuctionId = @auctionId";
        var bidCount = await db.QueryFirstOrDefaultAsync<int>(sql, new { auctionId = auction.AuctionID });

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@AuctionID", auction.AuctionID);
        parameters.Add("@UserID", auction.UserID);
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
            parameters.Add("@Price", DBNull.Value);
        }
        var updatedAuction = await db.QueryFirstOrDefaultAsync<Auction>("UpdateAuction", parameters, commandType: CommandType.StoredProcedure);
        db.ExecuteScalar("CreateUser", parameters, commandType: CommandType.StoredProcedure);
        return updatedAuction;
    }
}
