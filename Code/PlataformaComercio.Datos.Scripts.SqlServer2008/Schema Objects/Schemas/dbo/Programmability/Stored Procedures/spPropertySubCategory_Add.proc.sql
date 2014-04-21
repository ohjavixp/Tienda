CREATE PROCEDURE dbo.spPropertySubCategory_Add 
@PropertyCategoryId int,
@PropertySubCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
INSERT INTO PropertySubCategory(
	[PropertyCategoryId],
	[PropertySubCategoryId],
	[Name],
	[IsActive])
VALUES (
	@PropertyCategoryId,
	@PropertySubCategoryId,
	@Name,
	@IsActive)
