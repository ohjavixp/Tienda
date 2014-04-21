CREATE TABLE [dbo].[Product] (
    [ProductID]           VARCHAR (50)    NOT NULL,
    [Name]                VARCHAR (50)    NOT NULL,
    [ShortDescription]    VARCHAR (200)   NULL,
    [LargeDescription]    TEXT            NULL,
    [LargeDescriptionRaw] TEXT            NULL,
    [Price]               DECIMAL (18, 2) NULL,
    [TradeID]             INT             NULL,
    [Image128]            BIT             NULL,
    [Image256]            BIT             NULL,
    [Weight]              DECIMAL (18, 2) NULL,
    [IsActive]            BIT             NOT NULL,
    [Measure]             VARCHAR (50)    NULL,
    [LastMod]             DATETIME        NOT NULL,
    [BaseProductId]       VARCHAR (50)    NULL,
    [CurrencyId]          INT             NOT NULL
);



