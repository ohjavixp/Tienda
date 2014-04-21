ALTER TABLE [dbo].[SearchNotFound]
    ADD CONSTRAINT [FK_SearchNotFound_Inventory] FOREIGN KEY ([InventoryId]) REFERENCES [dbo].[Inventory] ([InventoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

