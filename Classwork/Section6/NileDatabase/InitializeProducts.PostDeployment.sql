/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DECLARE @count INT

SELECT @count = COUNT(*) FROM Products

IF @count = 0
BEGIN
    INSERT INTO Products (Name, Description, Price, IsDiscontinued) VALUES
        ('Windows Phone', 'Windows 10 Phone', 100, 0),
        ('Galaxy S7', 'Good phone', 650, 0),
        ('Galaxy Note 7', 'FAA ban edition', 150, 1),
        ('iPhone X', 'Outdated', 1900, 1)
END