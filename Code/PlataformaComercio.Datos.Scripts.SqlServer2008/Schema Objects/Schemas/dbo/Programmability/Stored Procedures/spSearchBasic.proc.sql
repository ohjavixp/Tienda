CREATE PROC dbo.spSearchBasic
@InventoryID VARCHAR(50),
@SearchText NVARCHAR(200)
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
FROM	(
		SELECT	SUM(PRank) AS [RANK],
				ProductID
		FROM
				(
				SELECT	FTT.RANK AS PRank,
						P.ProductID
				FROM	Product P		
						INNER JOIN FREETEXTTABLE
						(dbo.Product,
						*,
						@SearchText) AS FTT ON
							FTT.[KEY] = P.ProductID				
				UNION ALL					
				SELECT	FTT.RANK * 50 AS PRank,
						P.ProductID				
				FROM	Product P		
						INNER JOIN FREETEXTTABLE
						(dbo.Trade,
						*,
						@SearchText) AS FTT ON
							FTT.[KEY] = P.TradeID
						INNER JOIN Trade M ON
							P.TradeID = M.TradeID	
				) AS Result
		GROUP BY ProductID) AS ComputedResult
		INNER JOIN Product P ON
			ComputedResult.ProductID = P.ProductID		
		INNER JOIN Trade M ON
			P.TradeID = M.TradeID	
		INNER JOIN InventoryProduct IP ON
			P.ProductID = IP.ProductID AND
			IP.InventoryID = @InventoryID
ORDER BY [Rank] DESC;

		
			




