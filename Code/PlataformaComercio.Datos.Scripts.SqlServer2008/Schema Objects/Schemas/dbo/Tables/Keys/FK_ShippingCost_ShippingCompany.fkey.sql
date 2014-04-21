ALTER TABLE [dbo].[ShippingCost]
    ADD CONSTRAINT [FK_ShippingCost_ShippingCompany] FOREIGN KEY ([ShippingCompanyId]) REFERENCES [dbo].[ShippingCompany] ([ShippingCompanyId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

