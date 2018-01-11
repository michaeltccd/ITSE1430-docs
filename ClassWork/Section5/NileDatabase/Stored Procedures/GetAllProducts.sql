CREATE PROCEDURE [dbo].[GetAllProducts]	
AS BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Price, Description, IsDiscontinued
    FROM Products
END
