ALTER TABLE [dbo].[ProductPropertyValues]
    ADD CONSTRAINT [FK_ProductPropertyValues_Property] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[Property] ([PropertyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

