﻿ALTER TABLE [dbo].[OrderPayment]
    ADD CONSTRAINT [PK_OrderPayment_1] PRIMARY KEY CLUSTERED ([OrderID] ASC, [PaymentID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
