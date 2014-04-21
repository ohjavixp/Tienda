ALTER TABLE [dbo].[BaseProductPropertyValues]
    ADD CONSTRAINT [FK_BaseProductPropertyValues_Property] FOREIGN KEY ([PropertyId]) REFERENCES [dbo].[Property] ([PropertyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

