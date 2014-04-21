
CREATE  PROCEDURE dbo.spBaseProduct_Update 
@BaseProductId varchar(50),
@Name varchar(50),
@IsActive bit,
@LastMod datetime,
@TradeId int,
@PropertyCategoryID int,
@PropertySubCategoryID int
AS 
UPDATE BaseProduct
SET 
	Name=@Name,
	IsActive=@IsActive,
	LastMod=@LastMod,
	TradeId=@TradeId,
	PropertyCategoryID=@PropertyCategoryID,
	PropertySubCategoryID=@PropertySubCategoryID
WHERE 
	BaseProductId=@BaseProductId
