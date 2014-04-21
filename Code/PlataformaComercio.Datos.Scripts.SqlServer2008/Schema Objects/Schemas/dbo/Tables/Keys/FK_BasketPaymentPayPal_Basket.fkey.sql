ALTER TABLE [dbo].[BasketPaymentPayPal]
    ADD CONSTRAINT [FK_BasketPaymentPayPal_Basket] FOREIGN KEY ([BasketID]) REFERENCES [dbo].[Basket] ([BasketId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

