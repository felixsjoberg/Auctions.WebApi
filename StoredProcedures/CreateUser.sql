alter PROCEDURE [dbo].[CreateUser] 
    @UserId UNIQUEIDENTIFIER,
    @UserName NVARCHAR(50),
    @Email NVARCHAR(50),
    @Password NVARCHAR(50)

    
AS
BEGIN
INSERT INTO [Users](UserId,UserName,Email,[Password])
VALUES (@UserId,@UserName,@Email,@Password)
     
END
GO
