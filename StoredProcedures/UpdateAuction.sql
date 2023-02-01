CREATE PROCEDURE [dbo].[UpdateAuction](@AuctionID INT,
	                                   @Title NVARCHAR(50),
	                                   @Description NVARCHAR(50),
	                                   @Price INT,
	                                   @EndDate DATETIME2(7))
AS
BEGIN
    UPDATE dbo.Auctions
    set 
    Title = @Title,
    Description = @Description,
    EndDate = @EndDate,
    Price = @Price
    where AuctionID = @AuctionID
END
GO
