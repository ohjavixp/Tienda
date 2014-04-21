ALTER TABLE [dbo].[OrderPaymentPayPal]
    ADD CONSTRAINT [FK_OrderPaymentPayPal_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [dbo].[Payment] ([PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

