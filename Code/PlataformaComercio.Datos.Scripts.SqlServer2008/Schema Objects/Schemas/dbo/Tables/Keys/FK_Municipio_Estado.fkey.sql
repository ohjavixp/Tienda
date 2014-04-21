ALTER TABLE [dbo].[Municipio]
    ADD CONSTRAINT [FK_Municipio_Estado] FOREIGN KEY ([IdPais], [IdEstado]) REFERENCES [dbo].[Estado] ([IdPais], [IdEstado]) ON DELETE NO ACTION ON UPDATE NO ACTION;

