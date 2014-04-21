ALTER TABLE [dbo].[InventoryProductCategory]
    ADD CONSTRAINT [FK_InventarioProducto_Inventario] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

