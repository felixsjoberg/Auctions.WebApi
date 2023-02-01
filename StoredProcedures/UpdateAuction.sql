CREATE PROCEDURE [dbo].[UpdateAuction](@AuctionID INT,
    @UserID UNIQUEIDENTIFIER,
	@Title NVARCHAR(50),
	@Description NVARCHAR(50),
	@Price INT,
	--@StartDate DATETIME2(7),
	@EndDate DATETIME2(7),
	@Status BIT)
AS
BEGIN
    UPDATE dbo.Auctions
    set 
    Title = @Title,
    Description = @Description,
    EndDate = @EndDate,
    Status = @Status
    where AuctionID = @AuctionID
    SELECT	Auctions.AuctionID, Bids.AuctionID FROM Auctions INNER JOIN Bids 
	ON Auctions.AuctionID = Bids.AuctionID

    UPDATE dbo.Auctions
    set
    Title = @Title,
    Description = @Description,
    EndDate = @EndDate,
    Status = @Status,
    Price = @Price
    where AuctionID = @AuctionID



    SELECT *
    FROM Auctions
    WHERE AuctionID = @AuctionID
END
GO