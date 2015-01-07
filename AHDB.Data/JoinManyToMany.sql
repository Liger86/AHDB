SELECT 
	Repair.ID RepairID,
	Repair.PurchaseOrder PurchaseOrder,
	Vendor.ID VendorID,
	Vendor.CompanyName VendorCompanyName
		FROM Repair REPAIR
			INNER JOIN VendorRepair VR ON REPAIR.ID = VR.RepairID
				INNER JOIN Vendor VENDOR ON VR.VendorID = VENDOR.ID
GO

SELECT 
	Repair.ID,
	Repair.PurchaseOrder PurchaseOrder,
	Vendor.ID VendorID,
	Vendor.CompanyName VendorCompanyName,
	VR.Completed
		FROM Repair REPAIR
			INNER JOIN VendorRepair VR ON REPAIR.ID = VR.RepairID
				INNER JOIN Vendor VENDOR ON VR.VendorID = VENDOR.ID
GO

select * from VendorRepair
GO

SELECT 
    [Extent1].[RepairID] AS [RepairID], 
    [Extent1].[Completed] AS [Completed], 
    [Extent1].[VendorID] AS [VendorID]
    FROM [dbo].[VendorRepair] AS [Extent1] 
GO

SELECT 
    [Extent1].[ID] AS [ID], 
    [Extent1].[PurchaseOrder] AS [PurchaseOrder], 
    [Extent2].[Completed] AS [Completed], 
    [Extent2].[VendorID] AS [VendorID], 
    [Extent3].[CompanyName] AS [CompanyName]
    FROM   [dbo].[Repair] AS [Extent1]
    INNER JOIN [dbo].[VendorRepair] AS [Extent2] ON [Extent1].[ID] = [Extent2].[RepairID]
    INNER JOIN [dbo].[Vendor] AS [Extent3] ON [Extent2].[VendorID] = [Extent3].[ID]