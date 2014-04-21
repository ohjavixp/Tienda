CREATE TABLE [dbo].[OrderLineDetail] (
    [OrderID]           INT          NOT NULL,
    [LineId]            INT          NOT NULL,
    [OrderLineDetailID] INT          NOT NULL,
    [InventoryId]       VARCHAR (50) NOT NULL,
    [ProductId]         VARCHAR (50) NOT NULL,
    [ProductCategoryId] INT          NULL,
    [Quantity]          FLOAT        NOT NULL
);



