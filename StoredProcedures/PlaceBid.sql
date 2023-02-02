SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PlaceBid]
    @BidId INT OUT,
    @AuctionId INT,
    @BidPrice INT,
    @UserId UNIQUEIDENTIFIER,
    @BidDate datetime
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @auctionCurrentBalance MONEY;

    SELECT @auctionCurrentBalance = Price FROM Auctions WHERE AuctionID = @AuctionId;

    UPDATE Auctions SET Price = @auctionCurrentBalance + @bidPrice WHERE AuctionID = @AuctionId;

    INSERT INTO Bids (AuctionID, BidPrice, UserID,BidDate)
    VALUES (@AuctionId, @BidPrice, @UserId,@BidDate)
    
    SELECT @BidId = @@IDENTITY
END
GO
