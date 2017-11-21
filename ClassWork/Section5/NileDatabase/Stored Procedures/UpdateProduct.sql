CREATE PROCEDURE [dbo].[UpdateProduct]
    @id INT,
	@name NVARCHAR(100),
    @price MONEY,    
    @description NVARCHAR(MAX) = NULL,
	@isDiscontinued BIT = 0
AS BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT * FROM Products WHERE Id = @id)
	BEGIN
		RAISERROR('Product not found', 16, 1)
		RETURN
	END

	UPDATE Products
	SET 
		Name = @name,
		Description = @description, 
		Price = @price,
		IsDiscontinued = @isDiscontinued
	WHERE Id = @id
END
