ALTER TABLE [dbo].[BasketShippingAddress]
    ADD CONSTRAINT [FK_BasketShippingAddress_Pais] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[Pais] ([IdPais]) ON DELETE NO ACTION ON UPDATE NO ACTION;

