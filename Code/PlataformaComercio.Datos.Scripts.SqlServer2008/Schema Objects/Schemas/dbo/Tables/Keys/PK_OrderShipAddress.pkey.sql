﻿ALTER TABLE [dbo].[OrderShippingAddress]
    ADD CONSTRAINT [PK_OrderShipAddress] PRIMARY KEY CLUSTERED ([OrderID] ASC, [OrderShippingID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

