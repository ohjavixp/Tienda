ALTER TABLE [dbo].[BasketShipping]
    ADD CONSTRAINT [FK_BasketShipping_Basket] FOREIGN KEY ([BasketID]) REFERENCES [dbo].[Basket] ([BasketId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

