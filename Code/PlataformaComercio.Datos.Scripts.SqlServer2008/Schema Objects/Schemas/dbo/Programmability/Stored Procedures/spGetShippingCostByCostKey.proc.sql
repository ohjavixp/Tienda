CREATE PROC dbo.spGetShippingCostByCostKey
@ShippingCostKey VARCHAR(100)
AS
SELECT	ShippingCostId, 		
		ShippingCostKey, 
		Cost, 
		MaxWeight, 
		AditionalCost, 
		SC.IsActive,
		SCO.ShippingCompanyId,
		SCO.Name,
		SCO.IsActive,
		ST.ShippingTypeId,
		ST.Name
FROM	ShippingCost SC
        INNER JOIN ShippingCompany SCO ON
            SC.ShippingCompanyId = SCO.ShippingCompanyId
        INNER JOIN ShippingType ST ON
            SC.ShippingTypeId = ST.ShippingTypeId
WHERE ShippingCostKey = @ShippingCostKey
