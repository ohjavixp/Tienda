CREATE PROC [dbo].[spProduct_Update]
@ProductID varchar(50),
@Name varchar(50),
@ShortDescription varchar(200),
@LargeDescription text,
@LargeDescriptionRaw text,
@Price decimal(18,2),
@TradeID int,
@Image128 bit,
@Image256 bit,
@IsActive bit,
@Weight decimal(18, 2),
@Measure varchar(50),
@CurrencyID int
AS


UPDATE [espaciomascota.com].[dbo].[Product]
   SET 
      [Name] = @Name,
      [ShortDescription] = @ShortDescription,
      [LargeDescription] = @LargeDescription,
      [LargeDescriptionRaw] = @LargeDescriptionRaw,
      [Price] = @Price,
      [TradeID] = @TradeID,
      [Image128] = @Image128,
      [Image256] = @Image256,
      [IsActive] = @IsActive,
      [Weight] = @Weight,
      [Measure] = @Measure,
      [CurrencyId] = @CurrencyID,
      [LastMod] = GETDATE()
 WHERE [ProductID] = @ProductID


