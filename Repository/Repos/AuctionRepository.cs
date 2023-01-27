using Auctions.WebApi.DTOs.UserDTOs;
using Auctions.WebApi.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using Auctions.WebApi.Repository.Interfaces;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Auctions.WebApi.Repository.Repos
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly string _connectionString;

        public AuctionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
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
                db.ExecuteScalarAsync("CreateAuction", parameters, commandType: CommandType.StoredProcedure);

                return parameters.Get<int>("@AuctionID");
            }
        }

        public async Task<Auction?> UpdateAuction(UpdateAuctionDTO auction)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sql = "SELECT COUNT(*) FROM Bids WHERE AuctionId = @auctionId";
                var bidCount = await db.QueryFirstOrDefaultAsync<int>(sql, new { auctionId = auction.AuctionID });

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
    }
}