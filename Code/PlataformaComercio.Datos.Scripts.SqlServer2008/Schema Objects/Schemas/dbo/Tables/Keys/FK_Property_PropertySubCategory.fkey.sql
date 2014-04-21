ALTER TABLE [dbo].[Property]
    ADD CONSTRAINT [FK_Property_PropertySubCategory] FOREIGN KEY ([PropertyCategoryId], [PropertySubCategoryId]) REFERENCES [dbo].[PropertySubCategory] ([PropertyCategoryId], [PropertySubCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

