CREATE TABLE [dbo].[BasketDetail] (
    [BasketId]          UNIQUEIDENTIFIER NOT NULL,
    [LineId]            INT              NOT NULL,
    [BasketDetailId]    INT              NOT NULL,
    [InventoryId]       VARCHAR (50)     NOT NULL,
    [ProductId]         VARCHAR (50)     NOT NULL,
    [ProductCategoryId] INT              NULL,
    [Quantity]          DECIMAL (18)     NOT NULL
);



