CREATE PROC [dbo].spGetAllProducts
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
FROM	Product P
		INNER JOIN Trade M ON
			P.TradeID = M.TradeID
ORDER BY P.ProductID