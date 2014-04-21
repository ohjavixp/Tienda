ALTER TABLE [dbo].[BasketPaymentPayPal]
    ADD CONSTRAINT [FK_BasketPaymentPayPal_Payment] FOREIGN KEY ([PaymentID]) REFERENCES [dbo].[Payment] ([PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

