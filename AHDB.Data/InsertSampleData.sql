USE [AHDB]
GO

spInsertCustomer 'Some Description 2', 'Company 2'
GO

INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 2', 'Company 2', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 3', 'Company 3', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 4', 'Company 4', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 5', 'Company 5', GETUTCDATE())
INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 6', 'Company 6', GETUTCDATE())

INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 7', 'Company 7', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 8', 'Company 8', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 9', 'Company 9', GETUTCDATE())
INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 10', 'Company 10', GETUTCDATE())

INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('Some Description 11', 'PO#101', 1)
INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('Some Description 12', 'PO#102', 1)
INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('Some Description 13', 'PO#103', 2)
INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('Some Description 14', 'PO#104', 2)
INSERT INTO Repair ([Description], PurchaseOrder, CustomerID) values ('Some Description 16', 'PO#106', 2)

SELECT * FROM Customer
SELECT * FROM Repair
SELECT * FROM Vendor
SELECT * FROM VendorRepair

delete from Customer

INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (2, 2, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (3, 2, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (4, 3, 0, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (5, 3, 0, GETUTCDATE())

ALTER TABLE Repair
ADD CONSTRAINT DF_Repair_DateCreatedAsUtcTime
DEFAULT GETUTCDATE() FOR DateCreatedAsUtcTime