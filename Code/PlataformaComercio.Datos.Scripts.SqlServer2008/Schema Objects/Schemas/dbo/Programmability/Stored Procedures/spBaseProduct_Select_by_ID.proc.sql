
CREATE  PROCEDURE dbo.spBaseProduct_Select_by_ID 
@BaseProductId varchar(50),
@Name varchar(50),
@IsActive bit,
@LastMod datetime,
@TradeId int,
@PropertyCategoryID int,
@PropertySubCategoryID int
AS 
SELECT 
	BaseProductId,
	Name,
	IsActive,
	LastMod,
	TradeId,
	PropertyCategoryID,
	PropertySubCategoryID
FROM BaseProduct
WHERE 
	BaseProductId=@BaseProductId 
