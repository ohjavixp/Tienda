CREATE PROCEDURE dbo.spCurrency_Add 
@CurrencyId int,
@Name varchar(50),
@Sign varchar(1),
@IsoCode varchar(3)
AS 
INSERT INTO Currency(
	[CurrencyId],
	[Name],
	[Sign],
	[IsoCode])
VALUES (
	@CurrencyId,
	@Name,
	@Sign,
	@IsoCode)