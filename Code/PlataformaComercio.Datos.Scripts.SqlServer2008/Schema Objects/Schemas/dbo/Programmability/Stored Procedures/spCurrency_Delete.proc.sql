
CREATE PROCEDURE dbo.spCurrency_Delete 
@CurrencyId int,
@Name varchar(50),
@Sign varchar(1),
@IsoCode varchar(3)
AS 
DELETE Currency
WHERE 
	CurrencyId=@CurrencyId