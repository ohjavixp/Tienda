


CREATE FUNCTION dbo.ObtenerIdCategoriaPorNombre(@IdInventario VARCHAR(50),@IdPadre INT,@Nombre VARCHAR(50))
RETURNS INT
WITH EXECUTE AS CALLER
AS
BEGIN

DECLARE @IdNivel1 INT

SELECT	@IdNivel1 = IdCategoria
FROM	InventarioCategoria 
WHERE	IdInventario = @IdInventario AND
		IdPadre = @IdPadre AND
		Nombre=@Nombre
RETURN(@IdNivel1)
END;
