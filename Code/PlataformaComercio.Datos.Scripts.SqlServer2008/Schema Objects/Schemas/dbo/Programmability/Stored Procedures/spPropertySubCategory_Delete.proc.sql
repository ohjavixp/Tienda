
CREATE PROCEDURE dbo.spPropertySubCategory_Delete 
@PropertyCategoryId int,
@PropertySubCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
DELETE PropertySubCategory
WHERE 
	PropertyCategoryId=@PropertyCategoryId AND
	PropertySubCategoryId=@PropertySubCategoryId
