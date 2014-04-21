ALTER TABLE [dbo].[BaseProduct]
    ADD CONSTRAINT [FK_BaseProduct_PropertyCategory] FOREIGN KEY ([PropertyCategoryID]) REFERENCES [dbo].[PropertyCategory] ([PropertyCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

