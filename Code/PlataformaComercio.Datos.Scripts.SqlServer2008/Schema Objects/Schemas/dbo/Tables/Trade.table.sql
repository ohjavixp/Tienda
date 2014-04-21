CREATE TABLE [dbo].[Trade] (
    [TradeID]          INT           NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [ShortDescription] VARCHAR (100) NOT NULL,
    [Description]      TEXT          NULL,
    [IsActive]         BIT           NOT NULL,
    [HasSubSite]       BIT           NOT NULL,
    [LastMod]          DATETIME      NULL
);



