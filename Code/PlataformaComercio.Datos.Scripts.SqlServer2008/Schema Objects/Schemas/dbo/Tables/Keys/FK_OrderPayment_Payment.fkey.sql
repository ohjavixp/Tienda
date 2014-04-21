ALTER TABLE [dbo].[OrderPayment]
    ADD CONSTRAINT [FK_OrderPayment_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [dbo].[Payment] ([PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

