ALTER TABLE [dbo].[BasketShipping]
    ADD CONSTRAINT [FK_BasketShipping_BasketShippingAddress] FOREIGN KEY ([BasketID], [ShippingID]) REFERENCES [dbo].[BasketShippingAddress] ([BasketID], [ShippingId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

