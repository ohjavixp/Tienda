ALTER TABLE [dbo].[BaseProduct]
    ADD CONSTRAINT [FK_BaseProduct_PropertySubCategory] FOREIGN KEY ([PropertyCategoryID], [PropertySubCategoryID]) REFERENCES [dbo].[PropertySubCategory] ([PropertyCategoryId], [PropertySubCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

