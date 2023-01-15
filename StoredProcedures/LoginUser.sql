CREATE PROCEDURE [dbo].[LoginUser]
    @username NVARCHAR(50),
    @password NVARCHAR(50)

AS
BEGIN
    
    SELECT *  
    FROM Users
    WHERE UserName = @username
    AND [Password] = @password    

END
GO
