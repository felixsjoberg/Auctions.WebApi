
CREATE PROCEDURE [dbo].[GetUserByEmail](@email NVARCHAR(50))
AS
BEGIN
    SELECT * FROM [Users]
    WHERE Email = @email
END
GO
