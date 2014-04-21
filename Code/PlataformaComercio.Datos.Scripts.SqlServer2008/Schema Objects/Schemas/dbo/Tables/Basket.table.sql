CREATE TABLE [dbo].[Basket] (
    [BasketId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]           VARCHAR (50)     NOT NULL,
    [CreationDate]   DATETIME         NOT NULL,
    [LastUpdateDate] DATETIME         NOT NULL,
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [IsAnonymous]    BIT              NOT NULL
);



