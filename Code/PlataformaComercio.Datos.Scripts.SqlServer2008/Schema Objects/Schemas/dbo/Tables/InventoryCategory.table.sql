CREATE TABLE [dbo].[InventoryCategory] (
    [InventoryID]      VARCHAR (50) NOT NULL,
    [CategoryID]       INT          NOT NULL,
    [FatherID]         INT          NOT NULL,
    [Name]             VARCHAR (50) COLLATE Modern_Spanish_CI_AI NOT NULL,
    [Description]      TEXT         NULL,
    [IsActive]         BIT          NOT NULL,
    [Show]             BIT          NOT NULL,
    [Order]            SMALLINT     NOT NULL,
    [ShortDescription] VARCHAR (50) NOT NULL
);



