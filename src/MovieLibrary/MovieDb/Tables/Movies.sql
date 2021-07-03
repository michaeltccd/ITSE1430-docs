CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(MAX),
    [Rating] NVARCHAR(20) NOT NULL,
    [ReleaseYear] INT NULL,
    [RunLength] INT NULL,
    [IsClassic] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [AK_Movies_Name] UNIQUE ([Name]), 
    CONSTRAINT [CK_Movies_ReleaseYear] CHECK (ISNULL(ReleaseYear, 1900) BETWEEN 1900 AND 2100), 
    CONSTRAINT [CK_Movies_RunLength] CHECK (ISNULL(RunLength, 0) >= 0), 
    CONSTRAINT [CK_Movies_Name] CHECK (LEN(Name) > 0) 
)
