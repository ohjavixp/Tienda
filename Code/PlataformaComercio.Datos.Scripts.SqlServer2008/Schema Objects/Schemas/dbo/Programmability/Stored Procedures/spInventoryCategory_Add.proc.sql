CREATE PROC dbo.spInventoryCategory_Add
@InventoryID VARCHAR(50),
@FatherID INT,
@Name VARCHAR(50),
@Description TEXT,
@IsActive BIT,
@Show BIT,
@Order SMALLINT,
@ShortDescription VARCHAR(50)
AS

DECLARE @CategoryID int
SELECT @CategoryID = (ISNULL(MAX(CategoryID),0)) + 1 FROM InventoryCategory WHERE InventoryID=@InventoryID

INSERT INTO InventoryCategory
VALUES
	(
	@InventoryID,
	@CategoryID,
	@FatherID,
	@Name,
	@Description,
	@IsActive,
	@Order,
	@Order,
	@ShortDescription)

SELECT @CategoryID