CREATE PROC [dbo].spGetInventoryProductByID
@InventoryID VARCHAR(50),
@ProductID VARCHAR(50)
AS
SELECT	P.ProductID,
		P.Name,
		P.ShortDescription,
		P.LargeDescription,		
		P.Price,
		M.TradeID,
		M.Name AS 'Marca',
		P.Image128,
		P.Image256,
		P.[Weight],
		P.IsActive,
		P.Measure,
		P.CurrencyId
FROM	InventoryProduct IP
		INNER JOIN Product P ON
			IP.ProductID =  P.ProductID
		INNER JOIN Trade M ON
			P.TradeID = M.TradeID
WHERE	InventoryID = @InventoryID AND
		IP.ProductID = @ProductID








