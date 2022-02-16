CREATE PROCEDURE [dbo].[spGetAllCoffees]
AS
	SELECT * FROM Products WHERE Type = 'Coffee'
RETURN 0
