﻿ALTER TABLE [dbo].[PropertyCategory]
    ADD CONSTRAINT [PK_PropertyCategory] PRIMARY KEY CLUSTERED ([PropertyCategoryId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
