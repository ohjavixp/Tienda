ALTER TABLE [dbo].[BaseProductPropertyValues]
    ADD CONSTRAINT [FK_BaseProductPropertyValues_BaseProduct] FOREIGN KEY ([BaseProductId]) REFERENCES [dbo].[BaseProduct] ([BaseProductId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

