/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DECLARE @count INT

SELECT @count = COUNT(*) FROM Movies
IF (@count = 0)
BEGIN
	INSERT INTO Movies (Title, Description, Length, IsOwned) VALUES
		('Star Wars', 'Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from...', 121, 1),
		('Star Trek: The Motion Picture', 'When an alien spacecraft of enormous power is spotted approaching Earth, Admiral Kirk resumes command of the Starship Enterprise...', 132, 0),
		('Cars', 'A hot-shot race-car named Lightning McQueen gets waylaid in Radiator Springs, where he finds the true meaning of friendship and family.', 117, 1),
		('E.T. the Extra-Terrestrial', 'A troubled child summons the courage to help a friendly alien escape Earth and return to his home world. ', 115, 0)
END