
CREATE  PROCEDURE dbo.spBaseProduct_Delete 
@BaseProductId varchar(50),
@Name varchar(50),
@IsActive bit,
@LastMod datetime,
@TradeId int,
@PropertyCategoryID int,
@PropertySubCategoryID int
AS 
DELETE BaseProduct
WHERE 
	BaseProductId=@BaseProductId
