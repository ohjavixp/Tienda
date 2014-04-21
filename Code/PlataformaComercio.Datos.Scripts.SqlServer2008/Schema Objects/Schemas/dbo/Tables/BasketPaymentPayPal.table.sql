CREATE TABLE [dbo].[BasketPaymentPayPal] (
    [BasketID]  UNIQUEIDENTIFIER NOT NULL,
    [PaymentID] INT              NOT NULL,
    [Token]     VARCHAR (50)     NOT NULL,
    [PayerID]   VARCHAR (50)     NOT NULL,
    [Status]    SMALLINT         NOT NULL
);



