USE [AHDB]
GO

spInsertNote 'note3', 1
GO
spDeleteRepair 30
GO

select getutcdate()
go

spInsertRepair 'test', 'test', 'test', null, '1'

INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('test', 'test', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 3', 'Company 3', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 4', 'Company 4', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 5', 'Company 5', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 6', 'Company 6', GETUTCDATE())

INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 7', 'Company 7', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 8', 'Company 8', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 9', 'Company 9', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 10', 'Company 10', GETUTCDATE())

INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('test', 'PO#101', 1)

SELECT * FROM Customer
SELECT * FROM Repair
SELECT * FROM Vendor
SELECT * FROM VendorRepair
SELECT * FROM Note

drop table [User]

INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (1, 2, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (3, 2, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (4, 3, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (5, 3, 0, GETUTCDATE())