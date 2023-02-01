CREATE PROCEDURE [dbo].[GetAuctionByID] 
AS
BEGIN
SELECT a.AuctionID,
    a.UserID,
    a.Title,
    a.Description,
    a.StartDate,
    a.EndDate,
    a.Status,
	b.BidPrice,
	b.UserID
FROM Auctions a
INNER JOIN Bids b
ON  a.AuctionID = b.AuctionID
END
GO