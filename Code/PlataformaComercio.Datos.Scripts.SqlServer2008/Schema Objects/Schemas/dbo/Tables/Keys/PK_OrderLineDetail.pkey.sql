﻿ALTER TABLE [dbo].[OrderLineDetail]
    ADD CONSTRAINT [PK_OrderLineDetail] PRIMARY KEY CLUSTERED ([OrderID] ASC, [LineId] ASC, [OrderLineDetailID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

