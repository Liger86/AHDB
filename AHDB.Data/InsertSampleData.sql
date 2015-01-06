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

delete from VendorRepair

delete from Repair

Select * from Repair
inner join VendorRepair ON VendorRepair.RepairID = VendorRepair.RepairID
inner join Vendor ON VendorRepair.RepairID = Vendor.ID
where Vendor.ID = 1

Select * from Repair
inner join VendorRepair ON VendorRepair.RepairID = VendorRepair.RepairID

insert into VendorRepair (RepairID, VendorID) values (5, 2)
insert into VendorRepair (RepairID, VendorID) values (6, 2)
insert into VendorRepair (RepairID, VendorID) values (7, 3)
insert into VendorRepair (RepairID, VendorID) values (8, 3)
insert into VendorRepair (RepairID, VendorID) values (10, 3)

delete VendorRepair
where RepairID = 8
go

delete Repair
WHERE Repair.ID = 8
go