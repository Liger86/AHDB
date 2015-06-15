--For creating database
USE [master]
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
	[Password] NVARCHAR(MAX) NOT NULL
)
GO

CREATE TABLE [Role]
(
	ID INT NOT NULL PRIMARY KEY IDENTITY,
	[Description] NVARCHAR(50) NULL,
	RoleName NVARCHAR(50) NOT NULL,
	UserId INT NULL
)

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

ALTER TABLE [Role] add constraint Role_UserID_FK
FOREIGN KEY (UserId) references [User](ID)
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
@PhoneNumber NVARCHAR(50),
@CellPhoneNumber NVARCHAR(50),
@Email NVARCHAR(50),
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

--Stored Procedures for updating entities
CREATE PROC spUpdateCustomer
@CustomerId INT,
@Description NVARCHAR(MAX),
@CompanyName NVARCHAR(50)
AS
BEGIN
	UPDATE Customer
	SET
	[Description] = @Description,
	CompanyName = @CompanyName
	WHERE Customer.ID = @CustomerId
END
GO

CREATE PROC spUpdateRepair
@RepairID INT,
@Description NVARCHAR(MAX),
@PurchaseOrder NVARCHAR(50),
@QuoteNumber NVARCHAR(50),
@Completed BIT,
@DateCompleted DATETIME2,
@DueDate DATETIME2
AS
BEGIN
	UPDATE Repair
	SET 
	[Description] = @Description,
	PurchaseOrder = @PurchaseOrder,
	QuoteNumber = @QuoteNumber,
	Completed = @Completed,
	DateCompleted = @DateCompleted,
	DueDate = @DueDate
	WHERE ID = @RepairID;
END
GO

CREATE PROC spUpdateVendor
@VendorId INT,
@Description NVARCHAR(MAX),
@CompanyName NVARCHAR(50)
AS
BEGIN
	UPDATE Vendor
	SET
	[Description] = @Description,
	CompanyName = @CompanyName
	WHERE ID = @VendorId
END
GO

CREATE PROC spUpdateContact
@ContactId INT,
@Description NVARCHAR(MAX),
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@PhoneNumber NVARCHAR(50),
@CellPhoneNumber NVARCHAR(50),
@Email NVARCHAR(50),
@CustomerID INT,
@VendorID INT
AS
BEGIN
	UPDATE Contact 
	SET 
	[Description] = @Description,
	FirstName = @FirstName,
	LastName = @LastName,
	PhoneNumber = @PhoneNumber,
	CellPhoneNumber = @CellPhoneNumber,
	Email = @Email,
	CustomerID = @CustomerID,
	VendorID = @VendorID
	WHERE ID = @ContactId
END
GO

CREATE PROC spUpdateVendorRepair
@RepairID INT,
@VendorID INT,
@Completed BIT
AS
BEGIN
	UPDATE VendorRepair
	SET
	VendorID = @VendorID,
	Completed = @Completed
	WHERE RepairID = @RepairID
END
GO

CREATE PROC spUpdateNote
@NoteId INT,
@NoteText NVARCHAR(MAX)
AS
BEGIN

	UPDATE Note
	SET
	NoteText = @NoteText
	WHERE ID = @NoteId
END
GO

--Stored procedures for deleting entities
CREATE PROC spDeleteCustomer
@CustomerId INT
AS
BEGIN
	DELETE FROM Customer
	WHERE ID = @CustomerId
END
GO

CREATE PROC spDeleteRepair
@RepairId INT
AS
BEGIN
	DELETE FROM Repair
	WHERE ID = @RepairId
END
GO

CREATE PROC spDeleteVendor
@VendorId INT
AS
BEGIN
	DELETE FROM Vendor
	WHERE ID = @VendorId
END
GO

CREATE PROC spDeleteContact
@ContactId INT
AS
BEGIN
	DELETE FROM Contact
	WHERE ID = @ContactId
END
GO

CREATE PROC spDeleteVendorRepair
@RepairId INT
AS
BEGIN
	DELETE FROM VendorRepair
	WHERE RepairID = @RepairId
END
GO

CREATE PROC spDeleteNote
@NoteId INT
AS
BEGIN
	DELETE FROM Note
	WHERE ID = @NoteId
END
GO

--Stored procedures for paging entities
CREATE PROC spGetCustomers
@PageNumber INT,
@RowsPerPage INT
AS
BEGIN
	SELECT ID, [Description], CompanyName, DateCreatedAsUtcTime
	FROM Customer
	ORDER BY ID
	OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
	FETCH NEXT @RowsPerPage ROWS ONLY
END
GO