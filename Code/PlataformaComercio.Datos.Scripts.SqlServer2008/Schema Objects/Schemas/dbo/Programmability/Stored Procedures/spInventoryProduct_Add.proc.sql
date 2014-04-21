CREATE PROC dbo.spInventoryProduct_Add
@InventoryID varchar(50),
@ProductID varchar(50),
@Quantity int,
@IsActive bit
AS
INSERT INTO [dbo].[InventoryProduct]
           ([InventoryID]
           ,[ProductID]           
           ,[Quantity]
           ,[IsActive])
     VALUES
           (@InventoryID,
           @ProductID,           
           @Quantity,
           @IsActive)
