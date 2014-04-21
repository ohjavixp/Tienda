﻿ALTER TABLE [dbo].[BasketShippingAddress]
    ADD CONSTRAINT [PK_BasketShippingAddress_1] PRIMARY KEY CLUSTERED ([BasketID] ASC, [ShippingId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
