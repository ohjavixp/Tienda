CREATE TABLE [dbo].[ProductPropertyValues] (
    [ProductId]         VARCHAR (50) NOT NULL,
    [PropertyId]        INT          NOT NULL,
    [ProductPropertyId] INT          NOT NULL,
    [Value]             TEXT         NULL,
    [Value2]            TEXT         NULL,
    [IsOverride]        BIT          NOT NULL
);



