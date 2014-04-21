ALTER TABLE [dbo].[InventoryCategory]
    ADD CONSTRAINT [FK_InventarioCategoria_Inventario] FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

