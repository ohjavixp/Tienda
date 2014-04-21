CREATE TABLE [dbo].[Colonia] (
    [IdPais]              INT           NOT NULL,
    [IdEstado]            INT           NOT NULL,
    [IdMunicipio]         INT           NOT NULL,
    [IdColonia]           INT           NOT NULL,
    [Nombre]              VARCHAR (100) NOT NULL,
    [CodigoPostal]        VARCHAR (5)   NOT NULL,
    [UltimaActualizacion] DATETIME      NOT NULL,
    [Activo]              BIT           NOT NULL
);



