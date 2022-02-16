CREATE PROCEDURE [dbo].[spGetCoffeImg]
AS
	SELECT * FROM Products WHERE Type = 'Coffee';
RETURN 0
