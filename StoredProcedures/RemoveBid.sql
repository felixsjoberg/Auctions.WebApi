USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[CreateAuction]    Script Date: 2023-01-22 16:08:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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

