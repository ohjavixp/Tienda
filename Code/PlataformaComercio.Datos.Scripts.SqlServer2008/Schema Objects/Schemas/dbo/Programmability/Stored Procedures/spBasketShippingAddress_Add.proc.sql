
CREATE PROC [dbo].[spBasketShippingAddress_Add]
@BasketId uniqueidentifier,
@ShippingId int,
@CountryId int,
@ZipCode varchar(5),
@NeighborghoodID int,
@Street varchar(50),
@StreetNumber varchar(20),
@StreetInternalNumber varchar(20),
@StreetBetween varchar(100),
@AddressName varchar(50),
@TelephoneContact varchar(10),
@Comments varchar(100)
AS

INSERT INTO [dbo].BasketShippingAddress
           ([BasketID]  
           ,[ShippingId]         
           ,[CountryId]
           ,[ZipCode]
           ,[NeighborghoodID]
           ,[Street]
           ,[StreetNumber]
           ,[StreetInternalNumber]
           ,[StreetBetween]
           ,[AddressName]
           ,[TelephoneContact]
           ,[Comments])
     VALUES
           (
           @BasketId,           
           @ShippingId,
           @CountryId,
           @ZipCode,
           @NeighborghoodID,
           @Street,
           @StreetNumber,
           @StreetInternalNumber,
           @StreetBetween,
           @AddressName,
           @TelephoneContact,
           @Comments)
