CREATE  PROCEDURE dbo.spBaseProduct_Add 
@BaseProductId varchar(50),
@Name varchar(50),
@IsActive bit,
@LastMod datetime,
@TradeId int,
@PropertyCategoryID int,
@PropertySubCategoryID int
AS 
INSERT INTO BaseProduct(
	[BaseProductId],
	[Name],
	[IsActive],
	[LastMod],
	[TradeId],
	[PropertyCategoryID],
	[PropertySubCategoryID])
VALUES (
	@BaseProductId,
	@Name,
	@IsActive,
	@LastMod,
	@TradeId,
	@PropertyCategoryID,
	@PropertySubCategoryID)
