﻿ALTER TABLE [dbo].[BaseProductPropertyValues]
    ADD CONSTRAINT [PK_BaseProductPropertyValues] PRIMARY KEY CLUSTERED ([BaseProductId] ASC, [PropertyId] ASC, [ProductPropertyId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
