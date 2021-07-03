--
-- Updates an existing movie.
--
-- PARAMS:
--    id - The ID of the existing movie.
--    name - The name of the movie. Must be unique and cannot be empty.
--    rating - The rating of the movie. Cannot be empty.
--    releaseYear - The release year. If specified must be between 1900 and 2100.
--    runLength - The run length. If specified must be >= 0.
--    description - Specifies the description of the movie.
--
-- RETURNS: None.
--
CREATE PROCEDURE [dbo].[UpdateMovie]
    @id INT,
	@name NVARCHAR(255),
    @rating NVARCHAR(20),    
    @description NVARCHAR(MAX) = NULL,
    @releaseYear INT = NULL,
    @runLength INT = NULL,
    @isClassic BIT = NULL
AS BEGIN
    SET NOCOUNT ON;

    SET @name = LTRIM(RTRIM(ISNULL(@name, '')))
    SET @rating = LTRIM(RTRIM(ISNULL(@rating, '')))

    -- Validate
	IF LEN(@name) = 0
        THROW 51000, 'Name cannot be empty.', 1
    IF LEN(@rating) = 0
        THROW 51000, 'Rating cannot be empty.', 1
    
    IF NOT ISNULL(@releaseYear, 1900) BETWEEN 1900 AND 2100
        THROW 51001, 'ReleaseYear must be between 1900 and 2100.', 1
    IF ISNULL(@runLength, 0) < 0
        THROW 51002, 'RunLength must be >= 0.', 1
    
    IF NOT EXISTS (SELECT * FROM Movies WHERE Id = @id)
        THROW 51002, 'Movie not found.', 1

    IF EXISTS (SELECT * FROM Movies WHERE Name = @name AND Id <> @id)
        THROW 51003, 'Movie with same name already exists.', 1

    -- Update
    SET @description = LTRIM(RTRIM(ISNULL(@description, '')))
    IF LEN(@description) = 0 
        SET @description = NULL

    UPDATE Movies
    SET
        Name = @name, 
        Description = @description, 
        Rating = @rating, 
        ReleaseYear = @releaseYear, 
        RunLength = @runLength, 
        IsClassic = @isClassic
    WHERE Id = @id
END