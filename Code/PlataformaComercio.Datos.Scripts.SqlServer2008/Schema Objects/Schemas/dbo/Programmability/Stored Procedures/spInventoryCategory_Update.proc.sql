CREATE PROC dbo.spInventoryCategory_Update
@InventoryID varchar(50),
@CategoryID int,
@Name varchar(50),
@Description text,
@IsActive bit,
@Show bit,
@Order smallint,
@ShortDescription VARCHAR(50)
AS
UPDATE [dbo].[InventoryCategory]
   SET 
      [Name] = @Name,
      [Description] = @Description,
      [IsActive] = @IsActive,
      [Show] = @Show,
      [Order] = @Order,
		ShortDescription = @ShortDescription
WHERE	InventoryID=@InventoryID AND
		[CategoryID] = @CategoryID	

