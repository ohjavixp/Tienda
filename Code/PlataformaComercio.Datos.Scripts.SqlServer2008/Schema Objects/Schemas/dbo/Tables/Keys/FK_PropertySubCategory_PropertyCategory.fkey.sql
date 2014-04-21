ALTER TABLE [dbo].[PropertySubCategory]
    ADD CONSTRAINT [FK_PropertySubCategory_PropertyCategory] FOREIGN KEY ([PropertyCategoryId]) REFERENCES [dbo].[PropertyCategory] ([PropertyCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

