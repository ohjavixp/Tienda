ALTER TABLE [dbo].[OrderShipping]
    ADD CONSTRAINT [FK_OrderShipping_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

