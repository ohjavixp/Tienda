CREATE PROC [dbo].[spBasketDetail_Add]
@BasketId uniqueidentifier,
@LineId int,
@InventoryId varchar(50),
@ProductId varchar(50),
@ProductCategoryId int,
@Quantity float
AS

DECLARE @BasketDetailId INT

SELECT @BasketDetailId = (ISNULL(MAX(BasketDetailId),0)) + 1 FROM BasketDetail WHERE BasketId = @BasketID AND LineId=@LineId

INSERT INTO [dbo].[BasketDetail]
           ([BasketId]
           ,[LineId]
           ,[BasketDetailId]
           ,[InventoryId]
           ,[ProductId]
           ,[ProductCategoryId]
           ,[Quantity])
     VALUES
           (@BasketId,
           @LineId,
           @BasketDetailId,
           @InventoryId,
           @ProductId,
           @ProductCategoryId,
           @Quantity)


SELECT @BasketDetailId


