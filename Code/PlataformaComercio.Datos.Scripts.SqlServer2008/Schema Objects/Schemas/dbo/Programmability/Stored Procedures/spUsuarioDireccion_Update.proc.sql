CREATE PROC [dbo].[spUsuarioDireccion_Update]
@UserId uniqueidentifier,
@AddressId int,
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

UPDATE [dbo].[UsuarioDireccion]
   SET 
      [CountryId] = @CountryId,
      [ZipCode] = @ZipCode,
      [NeighborghoodID] = @NeighborghoodID,
      [Street] = @Street,
      [StreetNumber] = @StreetNumber,
      [StreetInternalNumber] = @StreetInternalNumber,
      [StreetBetween] = @StreetBetween,
      [AddressName] = @AddressName,
      [TelephoneContact] = @TelephoneContact,
      [Comments] = @Comments
 WHERE
	[UserId] = @UserId AND
    [AddressId] = @AddressId
