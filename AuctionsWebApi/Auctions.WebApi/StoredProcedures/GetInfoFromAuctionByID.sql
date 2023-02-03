USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[GetInfoFromAuctionByID]    Script Date: 2023-01-20 10:36:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetInfoFromAuctionByID] (@ID int)
AS
BEGIN
SELECT * FROM Auctions
WHERE AuctionID = @ID
END
GO


