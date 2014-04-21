ALTER TABLE [dbo].[UsuarioDireccion]
    ADD CONSTRAINT [FK_UsuarioDireccion_Usuario] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Usuario] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

