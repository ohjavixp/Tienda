CREATE PROC [dbo].[spTrade_Add]
@Name varchar(50),
@ShortDescription varchar(100),
@Description text,
@IsActive bit,
@HasSubSite bit
AS

DECLARE @TradeID INT

SELECT @TradeID = (ISNULL(MAX(TradeID),0)) + 1 FROM Trade

INSERT INTO [dbo].[Trade]
           ([TradeID]
           ,[Name]
           ,[ShortDescription]
           ,[Description]
           ,[IsActive]
           ,[HasSubSite],
           [LastMod])
     VALUES
           (@TradeID,
           @Name,
           @ShortDescription,
           @Description,
           @IsActive,
           @HasSubSite,
           GetDate())
SELECT @TradeID

