SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[searchopenAuctionbids]
    @AuctionID INT
AS
BEGIN
    SET NOCOUNT ON;

     SELECT Auctions.*,Bids.*
     FROM Auctions
     INNER JOIN Bids ON Auctions.AuctionID = Bids.AuctionID
     WHERE Auctions.AuctionID = @AuctionID AND Auctions.Status = 1
     AND Auctions.EndDate >= GETDATE()
END
GO
