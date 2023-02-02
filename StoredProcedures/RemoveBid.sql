CREATE PROCEDURE [dbo].[RemoveBid](
	@BidId INT)
	
AS
BEGIN
	DECLARE @auctionCurrentBalance MONEY;
    DECLARE @bidPrice MONEY;
    DECLARE @getAuctionID INT;

    SELECT @auctionCurrentBalance = Price FROM Auctions INNER JOIN Bids ON Bids.AuctionID = Auctions.AuctionID WHERE bids.BidID = @BidId;
    SELECT @getAuctionID = Auctions.AuctionID FROM Auctions INNER JOIN Bids ON Bids.AuctionID = Auctions.AuctionID WHERE bids.BidID = @BidId;
    SELECT @bidPrice = BidPrice FROM Bids WHERE BidId = @BidId;


    UPDATE Auctions SET Price = @auctionCurrentBalance - @bidPrice WHERE AuctionID = @getAuctionID;

END
GO

