CREATE PROC [dbo].[spProduct_Add]
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

INSERT INTO [dbo].[Product]
           ([ProductID]
           ,[Name]
           ,[ShortDescription]
           ,[LargeDescription]
           ,[LargeDescriptionRaw]
           ,[Price]
           ,[TradeID]
           ,[Image128]
           ,[Image256]
           ,[IsActive]
           ,[Weight]
           ,[Measure]
           ,[CurrencyId]
           ,[LastMod])
     VALUES
           (@ProductID,
           @Name,
           @ShortDescription,
           @LargeDescription,
           @LargeDescriptionRaw,
           @Price,
           @TradeID,
           @Image128,
           @Image256,
           @IsActive,
           @Weight,
           @Measure,
           @CurrencyID,
           GETDATE())


