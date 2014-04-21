ALTER TABLE [dbo].[InventoryProductCategory]
    ADD CONSTRAINT [FK_InventarioProducto_Producto] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Product] ([ProductID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

