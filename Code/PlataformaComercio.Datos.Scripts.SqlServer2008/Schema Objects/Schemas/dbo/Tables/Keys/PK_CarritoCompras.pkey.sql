﻿ALTER TABLE [dbo].[Basket]
    ADD CONSTRAINT [PK_CarritoCompras] PRIMARY KEY CLUSTERED ([BasketId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
