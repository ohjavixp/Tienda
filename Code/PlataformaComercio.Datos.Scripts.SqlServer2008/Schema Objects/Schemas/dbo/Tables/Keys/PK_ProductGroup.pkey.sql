﻿ALTER TABLE [dbo].[ProductGroup]
    ADD CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED ([ProductGroupId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

