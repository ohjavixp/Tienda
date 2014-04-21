CREATE TABLE [dbo].[OrderShippingAddress] (
    [OrderID]              INT           NOT NULL,
    [OrderShippingID]      INT           NOT NULL,
    [CountryId]            INT           NOT NULL,
    [ZipCode]              VARCHAR (5)   NOT NULL,
    [NeighborghoodID]      INT           NOT NULL,
    [Street]               VARCHAR (50)  NOT NULL,
    [StreetNumber]         VARCHAR (20)  NOT NULL,
    [StreetInternalNumber] VARCHAR (20)  NULL,
    [StreetBetween]        VARCHAR (100) NOT NULL,
    [AddressName]          VARCHAR (50)  NOT NULL,
    [TelephoneContact]     VARCHAR (10)  NULL,
    [Comments]             VARCHAR (100) NULL
);



