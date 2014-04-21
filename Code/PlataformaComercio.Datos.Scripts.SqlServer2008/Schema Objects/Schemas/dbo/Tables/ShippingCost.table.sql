CREATE TABLE [dbo].[ShippingCost] (
    [ShippingCostId]    INT             NOT NULL,
    [ShippingCompanyId] INT             NOT NULL,
    [ShippingTypeId]    INT             NOT NULL,
    [ShippingCostKey]   VARCHAR (100)   NOT NULL,
    [Cost]              DECIMAL (18, 2) NOT NULL,
    [MaxWeight]         DECIMAL (18, 2) NOT NULL,
    [AditionalCost]     DECIMAL (18, 2) NOT NULL,
    [IsActive]          BIT             NOT NULL
);



