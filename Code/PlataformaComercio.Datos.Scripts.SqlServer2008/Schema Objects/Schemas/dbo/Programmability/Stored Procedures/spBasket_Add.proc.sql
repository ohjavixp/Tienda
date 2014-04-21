CREATE PROC dbo.spBasket_Add
@Name varchar(50),
@CreationDate datetime,
@LastUpdateDate datetime,
@UserId uniqueidentifier,
@IsAnonymous bit
AS

DECLARE @BasketId uniqueidentifier
SET @BasketId = NEWID()

INSERT INTO [dbo].[Basket]
           ([BasketId]
           ,[Name]
           ,[CreationDate]
           ,[LastUpdateDate]
           ,[UserId]
           ,[IsAnonymous])
     VALUES
           (@BasketId,
           @Name,
           @CreationDate,
           @LastUpdateDate,
           @UserId,
           @IsAnonymous)
           
           
SELECT @BasketId

