﻿ALTER TABLE [dbo].[Estado]
    ADD CONSTRAINT [FK_Estado_Pais] FOREIGN KEY ([IdPais]) REFERENCES [dbo].[Pais] ([IdPais]) ON DELETE NO ACTION ON UPDATE NO ACTION;

