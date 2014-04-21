
DECLARE @BasketID UniqueIdentifier
DECLARE @Id INT

SET @BasketId = '21763A56-B3E3-4F70-8678-1BBF12C6AD8B'
SELECT @Id = CurrentID + 1 FROM ControlID WHERE ControlId=1

INSERT INTO [Order] SELECT @Id as OrderId,CreationDate,LastUpdateDate,UserId,0 FROM Basket WHERE BasketId=@BasketId
SELECT * from [Order]

INSERT INTO OrderLine SELECT @Id,LineID,Name FROM BasketLine WHERE BasketId=@BasketId
SELECT *  FROM OrderLine

INSERT INTO OrderLineDetail SELECT @Id,LineId,BasketDetailId,InventoryId,ProductId,ProductCategoryId,Quantity FROM BasketDetail WHERE BasketId=@BasketId
SELECT * FROM OrderLineDetail

INSERT INTO OrderShipping SELECT @Id,ShippingID FROM BasketShipping WHERE BasketId=@BasketId
SELECT * FROM OrderShipping

INSERT INTO OrderShippingAddress
SELECT @Id, ShippingId, CountryId,ZipCode,NeighborghoodID,Street,StreetNumber,StreetInternalNumber,StreetBetween,AddressName,TelephoneContact,Comments FROM BasketShippingAddress WHERE BasketId=@BasketId
SELECT * FROM OrderShippingAddress


INSERT INTO OrderPayment SELECT @Id,PaymentID,TotalPayed,Status FROM BasketPayment WHERE BasketId=@BasketId
SELECT * FROM OrderPayment

INSERT INTO OrderPaymentPayPal SELECT @Id,PaymentID,Token,PayerID,Status FROM BasketPaymentPayPal WHERE BasketId=@BasketId
SELECT * FROM OrderPaymentPayPal

UPDATE ControlId SET CurrentID=@Id WHERE ControlId = 1