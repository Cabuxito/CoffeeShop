CREATE PROCEDURE [dbo].[spGetCakeImg]
AS
	SELECT * FROM Products WHERE Type = 'Cake'
RETURN 0
