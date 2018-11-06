CREATE TABLE [dbo].[Movies]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] VARCHAR(100) NOT NULL,
	[IsOwned] BIT NOT NULL DEFAULT 0,
	[Description] VARCHAR(MAX), 
    [Length] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [CK_Movies_Length_Positive] CHECK ([Length] >= 0), 
    CONSTRAINT [AK_Movies_Title] UNIQUE ([Title]), 
    CONSTRAINT [CK_Movies_Title_Set] CHECK (LEN(Title) > 0),
)
