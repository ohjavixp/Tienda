CREATE TABLE [dbo].[OrderPayment] (
    [OrderID]    INT      NOT NULL,
    [PaymentID]  INT      NOT NULL,
    [TotalPayed] MONEY    NOT NULL,
    [Status]     SMALLINT NOT NULL
);



