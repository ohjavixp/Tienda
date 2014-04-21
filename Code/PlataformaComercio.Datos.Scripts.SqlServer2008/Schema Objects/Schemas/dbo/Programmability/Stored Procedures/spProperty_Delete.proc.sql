
CREATE PROCEDURE dbo.spProperty_Delete 
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
DELETE Property
WHERE 
	PropertyId=@PropertyId
