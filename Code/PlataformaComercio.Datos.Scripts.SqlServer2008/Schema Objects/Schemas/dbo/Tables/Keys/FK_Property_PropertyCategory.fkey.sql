ALTER TABLE [dbo].[Property]
    ADD CONSTRAINT [FK_Property_PropertyCategory] FOREIGN KEY ([PropertyCategoryId]) REFERENCES [dbo].[PropertyCategory] ([PropertyCategoryId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

