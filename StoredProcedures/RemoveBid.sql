USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[CreateAuction]    Script Date: 2023-01-22 16:08:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAuction](@AuctionID INT,
	@BidId INT,
	@UserID UNIQUEIDENTIFIER,
	@BidPrice INT,
	--@StartDate DATETIME2(7),
	@BidDate DATETIME2(7),
	@Status BIT)
AS
BEGIN
    SELECT *
    FROM Auctions
    WHERE BidId = @BidId
DELETE Auctions (AuctionID, BidId, UserID, BidPrice, BidDate, Status)
END
GO

