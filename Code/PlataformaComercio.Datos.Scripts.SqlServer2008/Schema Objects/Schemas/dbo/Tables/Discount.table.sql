CREATE TABLE [dbo].[Discount] (
    [DiscountId]    INT          NOT NULL,
    [DiscountName]  VARCHAR (50) NOT NULL,
    [OfferType]     INT          NOT NULL,
    [MinimumAmount] DECIMAL (18) NOT NULL,
    [OfferAmount]   DECIMAL (18) NOT NULL,
    [PerOrderLimit] INT          NOT NULL,
    [Priority]      INT          NOT NULL,
    [StartDate]     DATETIME     NOT NULL,
    [EndDate]       DATETIME     NOT NULL,
    [CreatedDate]   DATETIME     NOT NULL,
    [IsActive]      BIT          NOT NULL
);

