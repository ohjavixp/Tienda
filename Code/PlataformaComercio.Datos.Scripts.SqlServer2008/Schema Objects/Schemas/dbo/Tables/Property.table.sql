CREATE TABLE [dbo].[Property] (
    [PropertyId]            INT           NOT NULL,
    [Name]                  VARCHAR (100) NOT NULL,
    [FriendlyName]          VARCHAR (100) NULL,
    [PropertyCategoryId]    INT           NOT NULL,
    [PropertySubCategoryId] INT           NULL,
    [Type]                  SMALLINT      NOT NULL,
    [IsRequired]            BIT           NOT NULL,
    [IsActive]              BIT           NOT NULL,
    [IsBase]                BIT           NOT NULL
);



