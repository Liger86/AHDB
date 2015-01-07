use [AHDB]
go

insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 1', 'Company 1', GETUTCDATE())
insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 2', 'Company 2', GETUTCDATE())
insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 3', 'Company 3', GETUTCDATE())
insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 4', 'Company 4', GETUTCDATE())
insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 5', 'Company 5', GETUTCDATE())
insert into Customer ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 6', 'Company 6', GETUTCDATE())

insert into Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 7', 'Company 7', GETUTCDATE())
insert into Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 8', 'Company 8', GETUTCDATE())
insert into Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 9', 'Company 9', GETUTCDATE())
insert into Vendor ([Description], CompanyName, DateCreatedAsUtcTime) values ('Some Description 10', 'Company 10', GETUTCDATE())

insert into Repair ([Description], PurchaseOrder, Completed, DateCreatedAsUtcTime, CustomerID) values ('Some Description 11', 'PO#101', 0, GETUTCDATE(), 1)
insert into Repair ([Description], PurchaseOrder, Completed, DateCreatedAsUtcTime, CustomerID) values ('Some Description 12', 'PO#102', 0, GETUTCDATE(), 1)
insert into Repair ([Description], PurchaseOrder, Completed, DateCreatedAsUtcTime, CustomerID) values ('Some Description 13', 'PO#103', 0, GETUTCDATE(), 2)
insert into Repair ([Description], PurchaseOrder, Completed, DateCreatedAsUtcTime, CustomerID) values ('Some Description 14', 'PO#104', 0, GETUTCDATE(), 2)
insert into Repair ([Description], PurchaseOrder, Completed, DateCreatedAsUtcTime, CustomerID) values ('Some Description 15', 'PO#105', 0, GETUTCDATE(), 2)

SELECT * FROM Customer
SELECT * FROM Repair
SELECT * FROM Vendor
SELECT * FROM VendorRepair

DELETE FROM  VendorRepair

DELETE FROM Repair

SELECT * FROM Repair
inner join VendorRepair ON VendorRepair.RepairID = VendorRepair.RepairID
inner join Vendor ON VendorRepair.RepairID = Vendor.ID
WHERE Vendor.ID = 1

SELECT * FROM Repair
inner join VendorRepair ON VendorRepair.RepairID = VendorRepair.RepairID

INSERT INTO VendorRepair (RepairID, VendorID, DateCreatedAsUtcTime) VALUES (2, 2, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, DateCreatedAsUtcTime) VALUES (3, 2, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, DateCreatedAsUtcTime) VALUES (4, 3, GETUTCDATE())
INSERT INTO VendorRepair (RepairID, VendorID, DateCreatedAsUtcTime) VALUES (5, 3, GETUTCDATE())

DELETE VendorRepair
WHERE RepairID = 8
GO

DELETE Repair
WHERE Repair.ID = 8
GO

ALTER DATABASE [AHDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE

drop database [AHDB]