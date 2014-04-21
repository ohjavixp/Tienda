ALTER TABLE [dbo].[BasketLine]
    ADD CONSTRAINT [FK_BasketLine_Basket] FOREIGN KEY ([BasketId]) REFERENCES [dbo].[Basket] ([BasketId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

