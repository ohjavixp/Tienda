ALTER TABLE [dbo].[OrderLineDetail]
    ADD CONSTRAINT [FK_OrderLineDetail_OrderLine] FOREIGN KEY ([OrderID], [LineId]) REFERENCES [dbo].[OrderLine] ([OrderID], [LineID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

