CREATE TABLE [dbo].[Estado] (
    [IdPais]    INT          NOT NULL,
    [IdEstado]  INT          NOT NULL,
    [Nombre]    VARCHAR (50) NOT NULL,
    [Abreviado] VARCHAR (3)  NOT NULL,
    [RangoDe]   VARCHAR (5)  NOT NULL,
    [RangoAl]   VARCHAR (5)  NOT NULL,
    [Activo]    BIT          NOT NULL
);



