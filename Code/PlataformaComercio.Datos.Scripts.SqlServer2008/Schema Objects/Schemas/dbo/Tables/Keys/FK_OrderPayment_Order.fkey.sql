ALTER TABLE [dbo].[OrderPayment]
    ADD CONSTRAINT [FK_OrderPayment_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

