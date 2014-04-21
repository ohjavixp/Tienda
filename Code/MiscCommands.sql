--Inserta productos dentro del inventario, sin asociación de categorias
insert into inventoryproduct select 'Principal',ProductID,0,1 from Product where ProductID not in (select ProductID from InventoryProduct)

--Recarga el archivo de diccionario (tambien es usado como sinonimos
EXEC sys.sp_fulltext_load_thesaurus_file 3082;

/*
--Pruebas sobre full-text
SELECT *
FROM sys.dm_fts_parser
(
N'FORMSOF(FREETEXT,comida)',
3082,
NULL,
0
);
*/


