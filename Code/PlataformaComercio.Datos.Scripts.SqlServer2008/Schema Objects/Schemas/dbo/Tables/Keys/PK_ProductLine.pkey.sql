﻿ALTER TABLE [dbo].[ProductLine]
    ADD CONSTRAINT [PK_ProductLine] PRIMARY KEY CLUSTERED ([ProductId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
