CREATE TABLE [dbo].[BaseProduct] (
    [BaseProductId]         VARCHAR (50) NOT NULL,
    [Name]                  VARCHAR (50) NOT NULL,
    [IsActive]              BIT          NOT NULL,
    [LastMod]               DATETIME     NOT NULL,
    [TradeId]               INT          NOT NULL,
    [PropertyCategoryID]    INT          NOT NULL,
    [PropertySubCategoryID] INT          NOT NULL
);



