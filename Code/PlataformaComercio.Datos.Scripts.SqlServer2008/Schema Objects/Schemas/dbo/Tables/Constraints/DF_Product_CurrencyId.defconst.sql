ALTER TABLE [dbo].[Product]
    ADD CONSTRAINT [DF_Product_CurrencyId] DEFAULT ((1)) FOR [CurrencyId];

