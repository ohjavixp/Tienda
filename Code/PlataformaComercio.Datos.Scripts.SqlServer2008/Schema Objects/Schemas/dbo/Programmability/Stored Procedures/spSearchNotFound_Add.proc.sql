CREATE PROC dbo.spSearchNotFound_Add
@InventoryId AS VARCHAR(50),
@SearchString AS VARCHAR(100)
AS

IF NOT EXISTS (SELECT * FROM SearchNotFound WHERE InventoryId=@InventoryId AND SearchString=@searchString)
BEGIN
	insert into SearchNotFound values (@InventoryId,@searchString)
END


