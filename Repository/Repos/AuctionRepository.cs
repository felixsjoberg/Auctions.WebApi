using System.Data;
using System.Data.SqlClient;
using Auctions.WebApi.DTOs.AuctionDTOs;
using Auctions.WebApi.DTOs.BidDTO;
using Auctions.WebApi.Repository.Interfaces;
using Dapper;

namespace Auctions.WebApi.Repository.Repos
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly string _connectionString;

        public AuctionRepository(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("Default");
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

















        /* public List<Auction> GetOpenAuctionById(int id)
         {
             using (IDbConnection conn = new SqlConnection(_connectionString))
             {
                 DynamicParameters para = new DynamicParameters();
                 para.Add("@AuctionID", id);

                var auction = conn.Query<Auction, List<Bid>, Auction>(
                    "searchopenAuctionbids",
                    (Auction, Bid) =>
                    {
                        Auction.Bids = Bid;
                        return Auction;
                    },
                    para,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "AuctionID"
                ).ToList();

                 return auction; 
             }
         }*/



    }
}


      
   
   
            /*using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    DynamicParameters para = new DynamicParameters();
                    para.Add("@AuctionId", id);
                    // Call the stored procedure and pass in the parameter
                    var ads = conn.Query<Auction, Bid, Auction>(
                        "searchOpenAuctionBids",
                        (Auction, Bid) =>
                        {
                            Auction.Bids = Bid;
                            return Auction;
                        },
                        para,
                        commandType: CommandType.StoredProcedure,
                        splitOn: "AuctionId"
                    ).ToList();

                    return ads;

                }*/
            