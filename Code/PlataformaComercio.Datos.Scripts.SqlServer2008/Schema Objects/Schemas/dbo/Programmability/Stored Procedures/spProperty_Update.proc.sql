
CREATE PROCEDURE dbo.spProperty_Update 
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
UPDATE Property
SET 
	Name=@Name,
	FriendlyName=@FriendlyName,
	PropertyCategoryId=@PropertyCategoryId,
	PropertySubCategoryId=@PropertySubCategoryId,
	Type=@Type,
	IsRequired=@IsRequired,
	IsActive=@IsActive,
	IsBase=@IsBase
WHERE 
	PropertyId=@PropertyId
