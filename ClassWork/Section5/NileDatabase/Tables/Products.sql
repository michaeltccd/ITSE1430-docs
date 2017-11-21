CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(MAX),
    [Price] MONEY NOT NULL,
    [IsDiscontinued] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [CK_Products_NameSet] CHECK (LEN(Name) > 0), 
    CONSTRAINT [AK_Products_Name] UNIQUE ([Name]), 
    CONSTRAINT [CK_Products_PricePositive] CHECK (Price >= 0)
)
