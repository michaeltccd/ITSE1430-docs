--
-- Gets all the movies.
--
-- PARAMS: None.
-- 
-- RETURNS: The movies.
--
CREATE PROCEDURE [dbo].[GetMovies]	
AS BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Description, Rating, ReleaseYear, RunLength, IsClassic
    FROM Movies
END

