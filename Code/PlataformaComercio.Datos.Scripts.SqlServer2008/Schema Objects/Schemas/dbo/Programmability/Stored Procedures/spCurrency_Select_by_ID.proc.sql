
CREATE PROCEDURE dbo.spCurrency_Select_by_ID 
@CurrencyId int,
@Name varchar(50),
@Sign varchar(1),
@IsoCode varchar(3)
AS 
SELECT 
	CurrencyId,
	Name,
	Sign,
	IsoCode
FROM Currency
WHERE 
	CurrencyId=@CurrencyId