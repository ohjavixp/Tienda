CREATE PROC dbo.spBasketPayment_Add
@BasketID uniqueidentifier,
@PaymentID int,
@TotalPayed money,
@Status smallint
AS

INSERT INTO [dbo].[BasketPayment]
           ([BasketID]
           ,[PaymentID]
           ,[TotalPayed]
           ,[Status])
     VALUES
           (@BasketID,
           @PaymentID,
           @TotalPayed,
           @Status)
