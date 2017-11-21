CREATE PROCEDURE [dbo].[AddProduct]
	@name NVARCHAR(100),
    @price MONEY,    
    @description NVARCHAR(MAX) = NULL,
	@isDiscontinued BIT = 0
AS BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products (Name, Price, Description, IsDiscontinued) VALUES (@name, @price, @description, @isDiscontinued)

    SELECT SCOPE_IDENTITY()
END
