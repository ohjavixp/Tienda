CREATE PROC [dbo].spGetProductsByTrade
@InventoryID VARCHAR(50),
@TradeID INT
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
		P.Measure
FROM	InventoryProductCategory IP
		INNER JOIN Product P ON
			IP.ProductID =  P.ProductID
		INNER JOIN Trade M ON
			P.TradeID = M.TradeID
WHERE	InventoryID = @InventoryID AND
		P.TradeID = @TradeID
ORDER BY P.ProductID		


