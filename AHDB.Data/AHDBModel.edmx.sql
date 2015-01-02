
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2015 10:06:59
-- Generated from EDMX file: C:\Users\Thomas Anderson\Documents\ahdb_new\AHDB.Data\AHDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AHDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_CustomerContact];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_CustomerService];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceComponentVendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendors] DROP CONSTRAINT [FK_ServiceComponentVendor];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceServiceComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceComponents] DROP CONSTRAINT [FK_ServiceServiceComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceVendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendors] DROP CONSTRAINT [FK_ServiceVendor];
GO
IF OBJECT_ID(N'[dbo].[FK_VendorContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_VendorContact];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[ServiceComponents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceComponents];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Vendors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vendors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NULL,
    [VendorId] int  NULL,
    [FirstName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(50)  NULL
);
GO

-- Creating table 'ServiceComponents'
CREATE TABLE [dbo].[ServiceComponents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceId] int  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vendors'
CREATE TABLE [dbo].[Vendors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [ServiceComponentId] int  NULL,
    [ServiceId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceComponents'
ALTER TABLE [dbo].[ServiceComponents]
ADD CONSTRAINT [PK_ServiceComponents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [PK_Vendors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_CustomerContact]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerContact'
CREATE INDEX [IX_FK_CustomerContact]
ON [dbo].[Contacts]
    ([CustomerId]);
GO

-- Creating foreign key on [VendorId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_VendorContact]
    FOREIGN KEY ([VendorId])
    REFERENCES [dbo].[Vendors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VendorContact'
CREATE INDEX [IX_FK_VendorContact]
ON [dbo].[Contacts]
    ([VendorId]);
GO

-- Creating foreign key on [CustomerId] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_CustomerService]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerService'
CREATE INDEX [IX_FK_CustomerService]
ON [dbo].[Services]
    ([CustomerId]);
GO

-- Creating foreign key on [ServiceComponentId] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [FK_ServiceComponentVendor]
    FOREIGN KEY ([ServiceComponentId])
    REFERENCES [dbo].[ServiceComponents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceComponentVendor'
CREATE INDEX [IX_FK_ServiceComponentVendor]
ON [dbo].[Vendors]
    ([ServiceComponentId]);
GO

-- Creating foreign key on [ServiceId] in table 'ServiceComponents'
ALTER TABLE [dbo].[ServiceComponents]
ADD CONSTRAINT [FK_ServiceServiceComponent]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceServiceComponent'
CREATE INDEX [IX_FK_ServiceServiceComponent]
ON [dbo].[ServiceComponents]
    ([ServiceId]);
GO

-- Creating foreign key on [ServiceId] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [FK_ServiceVendor]
    FOREIGN KEY ([ServiceId])
    REFERENCES [dbo].[Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceVendor'
CREATE INDEX [IX_FK_ServiceVendor]
ON [dbo].[Vendors]
    ([ServiceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------