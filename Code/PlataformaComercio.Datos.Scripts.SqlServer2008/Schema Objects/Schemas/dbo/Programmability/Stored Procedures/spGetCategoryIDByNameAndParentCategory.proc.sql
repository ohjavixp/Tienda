CREATE PROC dbo.spGetCategoryIDByNameAndParentCategory
@InventoryID VARCHAR(50),
@ParentID INT,
@Name VARCHAR(50)
AS

DECLARE @LevelID INT

SELECT	@LevelID = CategoryID
FROM	InventoryCategory
WHERE	InventoryID = @InventoryID AND
		FatherID = @ParentID AND
		Name=@Name

SELECT @LevelID
