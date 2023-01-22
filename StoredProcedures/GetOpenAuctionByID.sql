USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[GetOpenAuctionByID]    Script Date: 2023-01-20 10:32:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetOpenAuctionByID]
AS
BEGIN
SELECT AuctionID FROM Auctions
WHERE Status = '1'
END
GO


