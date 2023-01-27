CREATE PROCEDURE [dbo].[RemoveBid](@AuctionID INT,
	@BidId INT,
	@UserID UNIQUEIDENTIFIER,
	@BidPrice INT,
	--@StartDate DATETIME2(7),
	@BidDate DATETIME2(7),
	@Status BIT)
AS
BEGIN
	DELETE FROM Auctions 
	WHERE BidId = @BidId
END
GO