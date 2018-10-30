CREATE PROCEDURE [dbo].[AddMovie]
	@title VARCHAR(100),
	@length INT,
	@isOwned BIT,
	@description VARCHAR(MAX) = NULL
AS BEGIN
	SET NOCOUNT ON;

	INSERT INTO Movies (Title, Description, Length, IsOwned) VALUES (@title, @description, @length, @isOwned)

	SELECT SCOPE_IDENTITY()
END
