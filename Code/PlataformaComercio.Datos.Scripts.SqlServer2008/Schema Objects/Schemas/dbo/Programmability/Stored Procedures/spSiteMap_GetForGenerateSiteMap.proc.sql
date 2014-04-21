CREATE PROC dbo.spSiteMap_GetForGenerateSiteMap
AS
SELECT ProductID AS Name,LastMod,0 AS Source FROM Product WHERE IsActive=1
UNION
SELECT Name AS Name,LastMod,1 AS Source FROM Trade WHERE IsActive=1
UNION
SELECT PageUrl AS Name,LastMod,3 AS Source FROM SiteMap WHERE IsActive=1




