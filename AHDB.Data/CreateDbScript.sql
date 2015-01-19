--For creating database
USE [master]
GO

DROP DATABASE [AHDB]
GO

CREATE DATABASE [AHDB]
GO

USE [AHDB]
GO

--First create all tables
CREATE TABLE Repair
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(MAX) NULL,

	PurchaseOrder NVARCHAR(50) NULL,
	QuoteNumber NVARCHAR(50) NULL,
	Completed BIT NULL, 

	DateCreatedAsUtcTime DATETIME2 NOT NULL,
	DateCompleted DATETIME2 NULL,
	DueDate DATETIME2 NULL,

	CustomerID INT NOT NULL,
)
GO

ALTER TABLE Repair
ALTER COLUMN DueDate DATETIME2 NULL
GO

CREATE TABLE Customer
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(MAX),

	CompanyName NVARCHAR(50) NULL,

	DateCreatedAsUtcTime DATETIME2 NOT NULL,
)
GO

CREATE TABLE Vendor
(
	ID int NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(MAX) NULL,

	CompanyName NVARCHAR(50) NULL,

	DateCreatedAsUtcTime DATETIME2 NOT NULL,
)
GO

CREATE TABLE Contact
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(MAX) NULL,

	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NULL,
	PhoneNumber nvarchar(50) NULL,
	CellPhoneNumber nvarchar(50) NULL,
	Email nvarchar(50) NULL,

	DateCreatedAsUtcTime DATETIME2 NOT NULL,

	CustomerID INT NULL,
	VendorID INT NULL,
)
GO

CREATE TABLE Note
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	NoteText NVARCHAR(max) NULL,

	DateCreatedAsUtcTime DATETIME2 NOT NULL,

	RepairID int NOT NULL,
)
GO

CREATE TABLE [User]
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(MAX) NULL,

	Username NVARCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NULL,
	[Hash] NVARCHAR(MAX) NOT NULL,
	Salt NVARCHAR(MAX) NOT NULL,
)
GO

--Creating relationships
ALTER TABLE Repair add constraint Repair_CustomerID_FK
FOREIGN KEY (CustomerID) REFERENCES Customer(ID)
GO

ALTER TABLE Contact add constraint Contact_CustomerID_FK
FOREIGN KEY (CustomerID) references Customer(ID)
GO

ALTER TABLE Contact add constraint Contact_VendorID_FK
FOREIGN KEY (VendorID) references Vendor(ID)
GO

ALTER TABLE Note add constraint Note_RepairID_FK
FOREIGN KEY (RepairID) references Repair(ID)
GO

--Bridge table for many-to-many
CREATE TABLE VendorRepair
(
	RepairID INT NOT NULL FOREIGN KEY REFERENCES Repair (ID),
	VendorID INT NOT NULL FOREIGN KEY REFERENCES Vendor (ID) PRIMARY KEY(RepairID, VendorID),

	Completed BIT NULL,
	DateCreatedAsUtcTime DATETIME2 NOT NULL,
)
GO

--Stored Procedures for inserting entities
CREATE PROC spInsertCustomer
@Description NVARCHAR(MAX),
@CompanyName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Customer ([Description], CompanyName, DateCreatedAsUtcTime) 
	VALUES (@Description, @CompanyName, GETUTCDATE())
END
GO

CREATE PROC spInsertRepair
@Description NVARCHAR(MAX),
@PurchaseOrder NVARCHAR(50),
@QuoteNumber NVARCHAR(50),
@DueDate DATETIME2,
@CustomerID INT
AS
BEGIN
	INSERT INTO Repair ([Description], PurchaseOrder, QuoteNumber, Completed, DateCreatedAsUtcTime, DueDate, CustomerID)
	VALUES (@Description, @PurchaseOrder, @QuoteNumber, 0, GETUTCDATE(), @DueDate, @CustomerID)
END
GO

CREATE PROC spInsertVendor
@Description NVARCHAR(MAX),
@CompanyName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Vendor ([Description], CompanyName, DateCreatedAsUtcTime) 
	VALUES (@Description, @CompanyName, GETUTCDATE())
END
GO

CREATE PROC spInsertContact
@Description NVARCHAR(MAX),
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@PhoneNumber nvarchar(50),
@CellPhoneNumber nvarchar(50),
@Email nvarchar(50),
@CustomerID INT,
@VendorID INT
AS
BEGIN
	INSERT INTO Contact ([Description], FirstName, LastName, PhoneNumber, CellPhoneNumber, Email, DateCreatedAsUtcTime, VendorID, CustomerID)
	VALUES (@Description, @FirstName, @LastName, @PhoneNumber, @CellPhoneNumber, @Email, GETUTCDATE(), @VendorID, @CustomerID)
END
GO

CREATE PROC spInsertVendorRepair
@RepairID INT,
@VendorID INT
AS
BEGIN
	INSERT INTO VendorRepair (RepairID, VendorID, Completed, DateCreatedAsUtcTime) VALUES (@RepairID, @VendorID, 0, GETUTCDATE())
END
GO

CREATE PROC spInsertNote
@NoteText NVARCHAR(MAX),
@RepairID INT
AS
BEGIN
	INSERT INTO Note (NoteText, DateCreatedAsUtcTime, RepairID) VALUES (@NoteText, GETUTCDATE(), @RepairID)
END
GO

CREATE PROC spDeleteRepair
@RepairID INT
AS
BEGIN
	DELETE FROM Repair
	WHERE ID = @RepairID
END
--Additional constraints