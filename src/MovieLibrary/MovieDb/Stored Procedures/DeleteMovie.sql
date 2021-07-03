--
-- Deletes a movie.
--
-- PARAMS:
--    id - The ID of the item to remove.
--
-- RETURNS: None.
--
CREATE PROCEDURE [dbo].[DeleteMovie]
	@id INT
AS BEGIN
	SET NOCOUNT ON;

    DELETE FROM Movies WHERE Id = @id
END
