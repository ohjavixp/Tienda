CREATE PROC [dbo].[spUsuarioDireccion_Add]
@UserId uniqueidentifier,
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

DECLARE @AddressId int

SELECT @AddressId = (ISNULL(MAX(AddressId),0)) + 1 FROM [UsuarioDireccion] WHERE UserId=@UserId

INSERT INTO [dbo].[UsuarioDireccion]
           ([UserId]
           ,[AddressId]
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
           @UserId,
           @AddressId,
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

SELECT @AddressId

