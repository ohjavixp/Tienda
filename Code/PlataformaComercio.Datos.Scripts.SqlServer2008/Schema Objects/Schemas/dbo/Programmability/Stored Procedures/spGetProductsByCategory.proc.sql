CREATE PROC [dbo].spGetProductsByCategory
@InventoryID VARCHAR(50),
@CategoryID INT
AS
SELECT	P.ProductID,
		P.Name,
		P.ShortDescription,
		P.LargeDescription,		
		P.Price,
		M.TradeID,
		M.Name AS 'Trade',
		P.Image128,
		P.Image256,
		P.[Weight],
		P.IsActive,
		P.Measure,
		P.CurrencyId
FROM	InventoryProductCategory IP
		INNER JOIN Product P ON
			IP.ProductID =  P.ProductID
		INNER JOIN Trade M ON
			P.TradeID = M.TradeID
WHERE	InventoryID = @InventoryID AND
		CategoryID = @CategoryID
ORDER BY P.ProductID
