CREATE PROCEDURE [dbo].[GetAuctionByID] 
AS
BEGIN
SELECT * FROM Auctions
WHERE AuctionID = @AuctionID 
END
GO