--
-- Gets a movie.
--
-- PARAMS:
--    id - The ID of the item.
-- 
-- RETURNS: The item, if found.
--
CREATE PROCEDURE [dbo].[GetMovie]
	@id INT
AS BEGIN
	SET NOCOUNT ON;

    SELECT Id, Name, Description, Rating, ReleaseYear, RunLength, IsClassic
    FROM Movies
    WHERE Id = @id
END

	 


