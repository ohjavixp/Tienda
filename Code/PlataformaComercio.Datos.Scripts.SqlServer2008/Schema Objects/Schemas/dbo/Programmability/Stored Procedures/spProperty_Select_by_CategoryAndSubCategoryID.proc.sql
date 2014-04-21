CREATE PROCEDURE dbo.spProperty_Select_by_CategoryAndSubCategoryID 
@PropertyCategoryId int,
@PropertySubCategoryId int
AS 
SELECT 
	PropertyId,
	Name,
	FriendlyName,
	PropertyCategoryId,
	PropertySubCategoryId,
	Type,
	IsRequired,
	IsActive,
	IsBase
FROM Property
WHERE 
	(PropertyCategoryId = @PropertyCategoryId AND PropertySubCategoryId Is NULL) OR 
	(PropertyCategoryId = @PropertyCategoryId AND PropertySubCategoryId=@PropertySubCategoryId)
