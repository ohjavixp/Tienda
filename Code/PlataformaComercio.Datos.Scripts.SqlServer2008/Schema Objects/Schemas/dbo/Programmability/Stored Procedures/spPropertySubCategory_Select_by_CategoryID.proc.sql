CREATE PROCEDURE dbo.spPropertySubCategory_Select_by_CategoryID 
@PropertyCategoryId int
AS 
SELECT 
	PropertyCategoryId,
	PropertySubCategoryId,
	Name,
	IsActive
FROM PropertySubCategory
WHERE 
	PropertyCategoryId=@PropertyCategoryId
