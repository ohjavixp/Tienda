CREATE PROCEDURE dbo.spCurrency_Select_All
AS 
SELECT 
	CurrencyId,
	Name,
	[Sign],
	IsoCode
FROM Currency