ALTER TABLE [dbo].[BasketPaymentPayPal]
    ADD CONSTRAINT [FK_BasketPaymentPayPal_BasketPayment1] FOREIGN KEY ([BasketID], [PaymentID]) REFERENCES [dbo].[BasketPayment] ([BasketID], [PaymentID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

