USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[CreateAuction]    Script Date: 2023-01-25 10:59:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAuction](
	@AuctionID INT OUT,
	@UserID UNIQUEIDENTIFIER,
	@Title NVARCHAR(50),
	@Description NVARCHAR(50),
	@Price INT,
	@StartDate DATETIME2(7),
	@EndDate DATETIME2(7))
AS
BEGIN
INSERT INTO Auctions (UserID, Title, Description, Price, StartDate, EndDate)
VALUES (@UserID, @Title, @Description, @Price, @StartDate, @EndDate)
SELECT @AuctionID = @@IDENTITY
END
GO
