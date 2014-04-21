ALTER TABLE [dbo].[InventoryProductCategory]
    ADD CONSTRAINT [FK_InventarioProducto_InventarioCategoria] FOREIGN KEY ([InventoryID], [CategoryID]) REFERENCES [dbo].[InventoryCategory] ([InventoryID], [CategoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

