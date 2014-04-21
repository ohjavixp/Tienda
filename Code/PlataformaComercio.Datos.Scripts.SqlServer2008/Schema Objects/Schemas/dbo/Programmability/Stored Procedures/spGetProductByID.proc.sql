CREATE PROC [dbo].spGetProductByID
@ProductID VARCHAR(50)
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
WHERE	P.ProductID = @ProductID