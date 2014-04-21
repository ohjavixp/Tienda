
CREATE PROCEDURE dbo.spPropertySubCategory_Select_by_ID 
@PropertyCategoryId int,
@PropertySubCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
SELECT 
	PropertyCategoryId,
	PropertySubCategoryId,
	Name,
	IsActive
FROM PropertySubCategory
WHERE 
	PropertyCategoryId=@PropertyCategoryId AND
 	PropertySubCategoryId=@PropertySubCategoryId 
