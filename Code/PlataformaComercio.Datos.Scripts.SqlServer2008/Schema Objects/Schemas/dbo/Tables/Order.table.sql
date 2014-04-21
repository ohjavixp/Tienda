CREATE TABLE [dbo].[Order] (
    [OrderID]       INT              NOT NULL,
    [CreationDate]  DATETIME         NOT NULL,
    [LasUpdateDate] DATETIME         NOT NULL,
    [UserID]        UNIQUEIDENTIFIER NOT NULL,
    [Status]        SMALLINT         NOT NULL
);



