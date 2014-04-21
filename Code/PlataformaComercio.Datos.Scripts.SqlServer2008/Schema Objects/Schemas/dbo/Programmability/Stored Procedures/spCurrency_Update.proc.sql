
CREATE PROCEDURE dbo.spCurrency_Update 
@CurrencyId int,
@Name varchar(50),
@Sign varchar(1),
@IsoCode varchar(3)
AS 
UPDATE Currency
SET 
	Name=@Name,
	Sign=@Sign,
	IsoCode=@IsoCode
WHERE 
	CurrencyId=@CurrencyId