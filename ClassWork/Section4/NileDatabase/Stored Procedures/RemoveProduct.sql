CREATE PROCEDURE [dbo].[RemoveProduct]
    @id INT
AS BEGIN
    SET NOCOUNT ON;

    DELETE FROM Products
    WHERE Id = @id
END
