ALTER TABLE [dbo].[ShippingCost]
    ADD CONSTRAINT [FK_ShippingCost_ShippingType] FOREIGN KEY ([ShippingTypeId]) REFERENCES [dbo].[ShippingType] ([ShippingTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

