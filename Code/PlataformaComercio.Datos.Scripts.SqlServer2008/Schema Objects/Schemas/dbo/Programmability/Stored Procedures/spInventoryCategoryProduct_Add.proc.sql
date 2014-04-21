CREATE PROC dbo.spInventoryCategoryProduct_Add
@InventoryID varchar(50),
@CategoryID int,
@ProductID varchar(50),
@IsPrimary bit,
@IsActive bit,
@Order smallint
AS

INSERT INTO [dbo].[InventoryProductCategory]
           ([InventoryID]
           ,[CategoryID]
           ,[ProductID]
           ,[IsPrimary]           
           ,[IsActive]           
           ,[Order])
     VALUES
           (@InventoryID,
           @CategoryID,
           @ProductID,
           @IsPrimary,           
           @IsActive,           
           @Order)



