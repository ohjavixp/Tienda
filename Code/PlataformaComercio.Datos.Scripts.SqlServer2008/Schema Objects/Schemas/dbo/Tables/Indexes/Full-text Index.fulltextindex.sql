CREATE FULLTEXT INDEX ON [dbo].[Product]
    ([ProductID] LANGUAGE 3082, [Name] LANGUAGE 3082, [LargeDescriptionRaw] LANGUAGE 3082)
    KEY INDEX [PK_Producto]
    ON [ProductsCatalog];

