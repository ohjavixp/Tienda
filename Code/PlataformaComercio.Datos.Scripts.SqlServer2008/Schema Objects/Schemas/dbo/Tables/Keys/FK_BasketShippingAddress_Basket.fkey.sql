ALTER TABLE [dbo].[BasketShippingAddress]
    ADD CONSTRAINT [FK_BasketShippingAddress_Basket] FOREIGN KEY ([BasketID]) REFERENCES [dbo].[Basket] ([BasketId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

