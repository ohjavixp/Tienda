
CREATE PROCEDURE dbo.spPropertyCategory_Select_by_ID 
@PropertyCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
SELECT 
	PropertyCategoryId,
	Name,
	IsActive
FROM PropertyCategory
WHERE 
	PropertyCategoryId=@PropertyCategoryId 
