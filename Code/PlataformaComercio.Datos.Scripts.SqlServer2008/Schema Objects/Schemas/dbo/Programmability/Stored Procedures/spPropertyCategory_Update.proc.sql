
CREATE PROCEDURE dbo.spPropertyCategory_Update 
@PropertyCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
UPDATE PropertyCategory
SET 
	Name=@Name,
	IsActive=@IsActive
WHERE 
	PropertyCategoryId=@PropertyCategoryId
