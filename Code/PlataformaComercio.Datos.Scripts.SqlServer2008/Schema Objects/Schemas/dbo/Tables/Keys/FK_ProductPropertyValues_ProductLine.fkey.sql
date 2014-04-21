ALTER TABLE [dbo].[ProductPropertyValues]
    ADD CONSTRAINT [FK_ProductPropertyValues_ProductLine] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[ProductLine] ([ProductId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

