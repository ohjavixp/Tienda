ALTER TABLE [dbo].[Colonia]
    ADD CONSTRAINT [FK_Colonia_Municipio] FOREIGN KEY ([IdPais], [IdEstado], [IdMunicipio]) REFERENCES [dbo].[Municipio] ([IdPais], [IdEstado], [IdMunicipio]) ON DELETE NO ACTION ON UPDATE NO ACTION;

