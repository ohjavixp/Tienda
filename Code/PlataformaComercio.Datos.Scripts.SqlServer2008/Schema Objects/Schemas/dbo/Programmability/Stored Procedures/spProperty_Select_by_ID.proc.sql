
CREATE PROCEDURE dbo.spProperty_Select_by_ID 
@PropertyId int,
@Name varchar(100),
@FriendlyName varchar(100),
@PropertyCategoryId int,
@PropertySubCategoryId int,
@Type smallint,
@IsRequired bit,
@IsActive bit,
@IsBase bit
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
	PropertyId=@PropertyId 
