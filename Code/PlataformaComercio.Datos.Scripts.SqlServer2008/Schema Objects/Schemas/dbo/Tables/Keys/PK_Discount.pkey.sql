﻿ALTER TABLE [dbo].[Discount]
    ADD CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED ([DiscountId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

