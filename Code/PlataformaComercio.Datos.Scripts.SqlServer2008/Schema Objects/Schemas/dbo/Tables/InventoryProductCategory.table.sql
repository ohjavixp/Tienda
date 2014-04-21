CREATE TABLE [dbo].[InventoryProductCategory] (
    [InventoryID] VARCHAR (50) NOT NULL,
    [CategoryID]  INT          NOT NULL,
    [ProductID]   VARCHAR (50) NOT NULL,
    [IsPrimary]   BIT          NOT NULL,
    [IsActive]    BIT          NOT NULL,
    [Order]       SMALLINT     NOT NULL
);



