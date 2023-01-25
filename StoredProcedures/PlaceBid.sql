SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PlaceBid]
    @AuctionId INT,
    @BidPrice INT,
    @UserId UNIQUEIDENTIFIER,
    @BidDate datetime
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Bids (AuctionID, BidPrice, UserID,BidDate)
    VALUES (@AuctionId, @BidPrice, @UserId,@BidDate)
END
GO
