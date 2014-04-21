ALTER TABLE [dbo].[BaseProduct]
    ADD CONSTRAINT [FK_BaseProduct_Trade] FOREIGN KEY ([TradeId]) REFERENCES [dbo].[Trade] ([TradeID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

