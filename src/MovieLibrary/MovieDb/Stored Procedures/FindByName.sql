--
-- Searches for a movie given its name.
--
-- PARAMS:
--    name - The name to search for.
--
-- RETURNS: The movie, if found.
--
CREATE PROCEDURE [dbo].[FindByName]
	@name NVARCHAR(255)
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))

    SELECT Id, Name, Description, Rating, ReleaseYear, RunLength, IsClassic
    FROM Movies
    WHERE Name = @name
END
