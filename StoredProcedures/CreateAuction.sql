USE [JensenAuction]
GO

/****** Object:  StoredProcedure [dbo].[CreateAuction]    Script Date: 2023-01-22 16:08:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateAuction](@AuctionID INT,
	@UserID UNIQUEIDENTIFIER,
	@Title NVARCHAR(50),
	@Description NVARCHAR(50),
	@Price INT,
	--@StartDate DATETIME2(7),
	@EndDate DATETIME2(7),
	@Status BIT)
AS
BEGIN
INSERT INTO Auctions (AuctionID, UserID, Title, Description, Price, EndDate, Status)
VALUES (@AuctionID, @UserID, @Title, @Description, @Price, @EndDate, @Status)
DECLARE @StartDate datetime =GETDATE()
SELECT @@IDENTITY
END
GO

