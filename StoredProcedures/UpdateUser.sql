
CREATE PROCEDURE [dbo].[UpdateUser]
    @userid UNIQUEIDENTIFIER,
    @username NVARCHAR(50),
    @password NVARCHAR(50),
    @email NVARCHAR(50)
AS
BEGIN
    UPDATE dbo.Users
    set 
    UserName=@username,
    [Password]=@password,
    Email=@email
    where UserID = @userid

    SELECT *
    FROM Users
    WHERE UserName = @username
END
GO
