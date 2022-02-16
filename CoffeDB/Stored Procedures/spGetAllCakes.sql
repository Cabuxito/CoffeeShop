CREATE PROCEDURE [dbo].[spGetAllCakes]
AS
	SELECT * FROM Products WHERE Type = 'Cake'
RETURN 0
