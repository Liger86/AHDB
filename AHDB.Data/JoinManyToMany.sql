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
	Repair.ID RepairID,
	Repair.PurchaseOrder PurchaseOrder,
	Vendor.ID VendorID,
	Vendor.CompanyName VendorCompanyName
		FROM Repair REPAIR
			INNER JOIN VendorRepair VR ON REPAIR.ID = VR.RepairID
				INNER JOIN Vendor VENDOR ON VR.VendorID = VENDOR.ID
GO

select * from VendorRepair
GO