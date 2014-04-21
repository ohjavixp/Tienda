CREATE TABLE [dbo].[BasketPayment] (
    [BasketID]   UNIQUEIDENTIFIER NOT NULL,
    [PaymentID]  INT              NOT NULL,
    [TotalPayed] MONEY            NOT NULL,
    [Status]     SMALLINT         NOT NULL
);



