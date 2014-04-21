ALTER TABLE [dbo].[OrderShipping]
    ADD CONSTRAINT [FK_OrderShipping_OrderShippingAddress] FOREIGN KEY ([OrderID], [OrderShippingID]) REFERENCES [dbo].[OrderShippingAddress] ([OrderID], [OrderShippingID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

