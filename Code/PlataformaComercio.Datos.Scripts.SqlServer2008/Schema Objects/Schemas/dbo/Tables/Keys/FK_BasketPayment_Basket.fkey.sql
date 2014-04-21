ALTER TABLE [dbo].[BasketPayment]
    ADD CONSTRAINT [FK_BasketPayment_Basket] FOREIGN KEY ([BasketID]) REFERENCES [dbo].[Basket] ([BasketId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

