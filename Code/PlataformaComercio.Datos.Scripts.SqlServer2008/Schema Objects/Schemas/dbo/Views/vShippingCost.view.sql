CREATE VIEW vShippingCost
AS
SELECT	ShippingCostId, 		
		ShippingCostKey, 
		Cost, 
		MaxWeight, 
		AditionalCost, 
		SC.IsActive,
		SCO.ShippingCompanyId,
		SCO.Name SCOName,
		SCO.IsActive as SCOIsActive,
		ST.ShippingTypeId,
		ST.Name
FROM	ShippingCost SC
        INNER JOIN ShippingCompany SCO ON
            SC.ShippingCompanyId = SCO.ShippingCompanyId
        INNER JOIN ShippingType ST ON
            SC.ShippingTypeId = ST.ShippingTypeId



