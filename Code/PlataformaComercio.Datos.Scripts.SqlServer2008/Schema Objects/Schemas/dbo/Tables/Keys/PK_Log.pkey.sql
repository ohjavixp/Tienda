﻿ALTER TABLE [dbo].[Log]
    ADD CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED ([LogID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
