CREATE PROCEDURE dbo.spProperty_Add 
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
INSERT INTO Property(
	[PropertyId],
	[Name],
	[FriendlyName],
	[PropertyCategoryId],
	[PropertySubCategoryId],
	[Type],
	[IsRequired],
	[IsActive],
	[IsBase])
VALUES (
	@PropertyId,
	@Name,
	@FriendlyName,
	@PropertyCategoryId,
	@PropertySubCategoryId,
	@Type,
	@IsRequired,
	@IsActive,
	@IsBase)
