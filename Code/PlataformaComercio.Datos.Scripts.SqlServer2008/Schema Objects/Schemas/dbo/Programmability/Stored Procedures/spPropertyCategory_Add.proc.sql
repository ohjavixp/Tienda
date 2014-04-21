CREATE PROCEDURE dbo.spPropertyCategory_Add 
@PropertyCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
INSERT INTO PropertyCategory(
	[PropertyCategoryId],
	[Name],
	[IsActive])
VALUES (
	@PropertyCategoryId,
	@Name,
	@IsActive)
