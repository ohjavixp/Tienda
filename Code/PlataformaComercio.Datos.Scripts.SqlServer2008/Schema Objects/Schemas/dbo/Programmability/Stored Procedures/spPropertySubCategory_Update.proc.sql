
CREATE PROCEDURE dbo.spPropertySubCategory_Update 
@PropertyCategoryId int,
@PropertySubCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
UPDATE PropertySubCategory
SET 
	Name=@Name,
	IsActive=@IsActive
WHERE 
	PropertyCategoryId=@PropertyCategoryId AND
	PropertySubCategoryId=@PropertySubCategoryId
