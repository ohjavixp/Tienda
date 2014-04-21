ALTER TABLE [dbo].[InventoryProduct]
    ADD CONSTRAINT [FK_InventoryProduct_Product] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

