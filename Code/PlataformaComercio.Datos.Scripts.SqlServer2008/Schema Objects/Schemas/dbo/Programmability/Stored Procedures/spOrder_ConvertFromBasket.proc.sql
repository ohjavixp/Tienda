CREATE PROC dbo.spOrder_ConvertFromBasket
@BasketID UniqueIdentifier
AS

DECLARE @Id INT

SELECT @Id = CurrentID + 1 FROM ControlID WHERE ControlId=1

INSERT INTO [Order] SELECT @Id as OrderId,GETDATE(),GETDATE(),UserId,0 FROM Basket WHERE BasketId=@BasketId


INSERT INTO OrderLine SELECT @Id,LineID,Name FROM BasketLine WHERE BasketId=@BasketId


INSERT INTO OrderLineDetail SELECT @Id,LineId,BasketDetailId,InventoryId,ProductId,ProductCategoryId,Quantity FROM BasketDetail WHERE BasketId=@BasketId


INSERT INTO OrderShipping SELECT @Id,ShippingID FROM BasketShipping WHERE BasketId=@BasketId


INSERT INTO OrderShippingAddress
SELECT @Id, ShippingId, CountryId,ZipCode,NeighborghoodID,Street,StreetNumber,StreetInternalNumber,StreetBetween,AddressName,TelephoneContact,Comments FROM BasketShippingAddress WHERE BasketId=@BasketId



INSERT INTO OrderPayment SELECT @Id,PaymentID,TotalPayed,Status FROM BasketPayment WHERE BasketId=@BasketId


INSERT INTO OrderPaymentPayPal SELECT @Id,PaymentID,Token,PayerID,Status FROM BasketPaymentPayPal WHERE BasketId=@BasketId


UPDATE ControlId SET CurrentID=@Id WHERE ControlId = 1

SELECT @Id