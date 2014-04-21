CREATE  PROC dbo.spBasket_Delete
@BasketID UniqueIdentifier
AS
DELETE FROM BasketPaymentPayPal WHERE BasketId=@BasketId
DELETE FROM BasketPayment WHERE BasketId=@BasketId
DELETE FROM BasketShippingAddress WHERE BasketId=@BasketId
DELETE FROM BasketShipping WHERE BasketId=@BasketId
DELETE FROM BasketDetail WHERE BasketId=@BasketId
DELETE FROM BasketLine WHERE BasketId=@BasketId
DELETE FROM Basket WHERE BasketId=@BasketId






















