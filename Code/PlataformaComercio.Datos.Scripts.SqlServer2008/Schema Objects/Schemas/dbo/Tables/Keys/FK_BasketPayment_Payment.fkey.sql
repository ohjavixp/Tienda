ALTER TABLE [dbo].[BasketPayment]
    ADD CONSTRAINT [FK_BasketPayment_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [dbo].[Payment] ([PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

