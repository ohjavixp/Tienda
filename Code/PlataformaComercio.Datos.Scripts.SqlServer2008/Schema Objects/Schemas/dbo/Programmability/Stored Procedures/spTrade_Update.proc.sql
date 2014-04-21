CREATE PROC [dbo].[spTrade_Update]
@TradeID INT,
@Name varchar(50),
@ShortDescription varchar(100),
@Description text,
@IsActive bit,
@HasSubSite bit
AS

UPDATE [dbo].[Trade] SET
           
           [Name] = @Name,
           [ShortDescription] = @ShortDescription,
           [Description] = @Description,
           [IsActive] = @IsActive,
           [HasSubSite] = @HasSubSite   ,
           [LastMod]  = GETDATE()
WHERE [TradeID] =  @TradeID

