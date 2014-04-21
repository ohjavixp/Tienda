ALTER TABLE [dbo].[BasketDetail]
    ADD CONSTRAINT [FK_BasketDetail_BasketLine] FOREIGN KEY ([BasketId], [LineId]) REFERENCES [dbo].[BasketLine] ([BasketId], [LineId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

