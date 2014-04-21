
CREATE PROCEDURE dbo.spPropertyCategory_Delete 
@PropertyCategoryId int,
@Name varchar(50),
@IsActive bit
AS 
DELETE PropertyCategory
WHERE 
	PropertyCategoryId=@PropertyCategoryId
