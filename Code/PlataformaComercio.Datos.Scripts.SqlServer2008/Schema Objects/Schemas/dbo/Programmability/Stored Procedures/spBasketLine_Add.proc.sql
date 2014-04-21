CREATE PROC dbo.spBasketLine_Add
@BasketID uniqueidentifier,
@Name varchar(50)
AS

DECLARE @LineID INT

SELECT @LineID = (ISNULL(MAX(LineId),0)) + 1 FROM BasketLine WHERE BasketId = @BasketID

INSERT INTO [dbo].[BasketLine]
           ([BasketId]
           ,[LineId]
           ,[Name])
     VALUES
           (
           @BasketID,
           @LineID,
           @Name)
           
SELECT @LineID

