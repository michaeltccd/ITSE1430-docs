CREATE PROCEDURE [dbo].[GetAllMovies]	
AS BEGIN
	SET NOCOUNT ON;

	SELECT Id, Title, Description, Length, IsOwned
	FROM Movies
END
