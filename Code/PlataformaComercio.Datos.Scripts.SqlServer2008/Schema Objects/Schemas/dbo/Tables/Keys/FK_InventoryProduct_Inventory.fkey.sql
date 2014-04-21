ALTER TABLE [dbo].[InventoryProduct]
    ADD CONSTRAINT [FK_InventoryProduct_Inventory] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

