ALTER TABLE [dbo].[OrderPaymentPayPal]
    ADD CONSTRAINT [FK_OrderPaymentPayPal_OrderPayment] FOREIGN KEY ([OrderID], [PaymentID]) REFERENCES [dbo].[OrderPayment] ([OrderID], [PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

