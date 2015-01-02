
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/02/2015 16:59:48
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
IF OBJECT_ID(N'[dbo].[FK_VendorContact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_VendorContact];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Repairs] DROP CONSTRAINT [FK_CustomerService];
GO
IF OBJECT_ID(N'[dbo].[FK_RepairComponentVendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendors] DROP CONSTRAINT [FK_RepairComponentVendor];
GO
IF OBJECT_ID(N'[dbo].[FK_RepairRepairComponent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RepairComponents] DROP CONSTRAINT [FK_RepairRepairComponent];
GO
IF OBJECT_ID(N'[dbo].[FK_RepairVendor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vendors] DROP CONSTRAINT [FK_RepairVendor];
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
IF OBJECT_ID(N'[dbo].[RepairComponents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RepairComponents];
GO
IF OBJECT_ID(N'[dbo].[Repairs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Repairs];
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

-- Creating table 'RepairComponents'
CREATE TABLE [dbo].[RepairComponents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RepairId] int  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Repairs'
CREATE TABLE [dbo].[Repairs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Vendors'
CREATE TABLE [dbo].[Vendors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(max)  NOT NULL,
    [RepairComponentId] int  NULL,
    [RepairId] int  NULL
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

-- Creating primary key on [Id] in table 'RepairComponents'
ALTER TABLE [dbo].[RepairComponents]
ADD CONSTRAINT [PK_RepairComponents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Repairs'
ALTER TABLE [dbo].[Repairs]
ADD CONSTRAINT [PK_Repairs]
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

-- Creating foreign key on [CustomerId] in table 'Repairs'
ALTER TABLE [dbo].[Repairs]
ADD CONSTRAINT [FK_CustomerService]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerService'
CREATE INDEX [IX_FK_CustomerService]
ON [dbo].[Repairs]
    ([CustomerId]);
GO

-- Creating foreign key on [RepairComponentId] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [FK_RepairComponentVendor]
    FOREIGN KEY ([RepairComponentId])
    REFERENCES [dbo].[RepairComponents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RepairComponentVendor'
CREATE INDEX [IX_FK_RepairComponentVendor]
ON [dbo].[Vendors]
    ([RepairComponentId]);
GO

-- Creating foreign key on [RepairId] in table 'RepairComponents'
ALTER TABLE [dbo].[RepairComponents]
ADD CONSTRAINT [FK_RepairRepairComponent]
    FOREIGN KEY ([RepairId])
    REFERENCES [dbo].[Repairs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RepairRepairComponent'
CREATE INDEX [IX_FK_RepairRepairComponent]
ON [dbo].[RepairComponents]
    ([RepairId]);
GO

-- Creating foreign key on [RepairId] in table 'Vendors'
ALTER TABLE [dbo].[Vendors]
ADD CONSTRAINT [FK_RepairVendor]
    FOREIGN KEY ([RepairId])
    REFERENCES [dbo].[Repairs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RepairVendor'
CREATE INDEX [IX_FK_RepairVendor]
ON [dbo].[Vendors]
    ([RepairId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------