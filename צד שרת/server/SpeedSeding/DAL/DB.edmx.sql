
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/09/2022 15:18:21
-- Generated from EDMX file: C:\Users\student\Documents\GitHub\SpeedSeding\צד שרת\server\SpeedSeding\DAL\DB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [seding];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__DELIVERIE__IDOFC__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DELIVERIES] DROP CONSTRAINT [FK__DELIVERIE__IDOFC__2B3F6F97];
GO
IF OBJECT_ID(N'[dbo].[FK__DELIVERIE__IDOFD__2A4B4B5E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DELIVERIES] DROP CONSTRAINT [FK__DELIVERIE__IDOFD__2A4B4B5E];
GO
IF OBJECT_ID(N'[dbo].[FK__POSSIBLED__IDOFD__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[POSSIBLEDRIVE] DROP CONSTRAINT [FK__POSSIBLED__IDOFD__2E1BDC42];
GO
IF OBJECT_ID(N'[dbo].[FK__RATING__DELIVERY__36B12243]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RATING] DROP CONSTRAINT [FK__RATING__DELIVERY__36B12243];
GO
IF OBJECT_ID(N'[dbo].[FK_T1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTCONFIRM] DROP CONSTRAINT [FK_T1];
GO
IF OBJECT_ID(N'[dbo].[FK_T2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NOTCONFIRM] DROP CONSTRAINT [FK_T2];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DELIVERIES]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DELIVERIES];
GO
IF OBJECT_ID(N'[dbo].[NOTCONFIRM]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NOTCONFIRM];
GO
IF OBJECT_ID(N'[dbo].[POSSIBLEDRIVE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[POSSIBLEDRIVE];
GO
IF OBJECT_ID(N'[dbo].[RATING]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RATING];
GO
IF OBJECT_ID(N'[dbo].[USERS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USERS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DELIVERIES'
CREATE TABLE [dbo].[DELIVERIES] (
    [DELIVERID] bigint  NOT NULL,
    [IDOFDELIVER] bigint  NULL,
    [IDOFCUSTUMER] bigint  NULL,
    [DATE] datetime  NULL,
    [RESPOND] bit  NULL,
    [SOURSEADRESS] varchar(50)  NULL,
    [DESTINATIONADRESS] varchar(50)  NULL,
    [DONE] bit  NULL,
    [HOUR] time  NULL
);
GO

-- Creating table 'NOTCONFIRM'
CREATE TABLE [dbo].[NOTCONFIRM] (
    [DeliveryId] bigint  NOT NULL,
    [PossibleDriveId] bigint  NOT NULL,
    [NotConfirmID] bigint  NOT NULL
);
GO

-- Creating table 'POSSIBLEDRIVE'
CREATE TABLE [dbo].[POSSIBLEDRIVE] (
    [KODOFDRIVE] bigint  NOT NULL,
    [IDOFDELIVER] bigint  NULL,
    [DATE] datetime  NULL,
    [HOUR] time  NULL,
    [SOURSEADRESS] varchar(50)  NULL,
    [DESTINATIONADRESS] varchar(50)  NULL,
    [CountOfDeliveries] int  NULL
);
GO

-- Creating table 'RATING'
CREATE TABLE [dbo].[RATING] (
    [DELIVERYID] bigint  NOT NULL,
    [IDOFDELIVER] bigint  NULL,
    [INTEGRITYDELIVER] int  NULL,
    [LATE] int  NULL,
    [SERVISE] int  NULL,
    [GENERAL] int  NULL,
    [SamPoint] bigint  NULL
);
GO

-- Creating table 'USERS'
CREATE TABLE [dbo].[USERS] (
    [Id] bigint  NOT NULL,
    [FirsteName] varchar(50)  NULL,
    [LastName] varchar(50)  NULL,
    [Status] varchar(50)  NULL,
    [phone] varchar(50)  NULL,
    [Password] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DELIVERID] in table 'DELIVERIES'
ALTER TABLE [dbo].[DELIVERIES]
ADD CONSTRAINT [PK_DELIVERIES]
    PRIMARY KEY CLUSTERED ([DELIVERID] ASC);
GO

-- Creating primary key on [NotConfirmID] in table 'NOTCONFIRM'
ALTER TABLE [dbo].[NOTCONFIRM]
ADD CONSTRAINT [PK_NOTCONFIRM]
    PRIMARY KEY CLUSTERED ([NotConfirmID] ASC);
GO

-- Creating primary key on [KODOFDRIVE] in table 'POSSIBLEDRIVE'
ALTER TABLE [dbo].[POSSIBLEDRIVE]
ADD CONSTRAINT [PK_POSSIBLEDRIVE]
    PRIMARY KEY CLUSTERED ([KODOFDRIVE] ASC);
GO

-- Creating primary key on [DELIVERYID] in table 'RATING'
ALTER TABLE [dbo].[RATING]
ADD CONSTRAINT [PK_RATING]
    PRIMARY KEY CLUSTERED ([DELIVERYID] ASC);
GO

-- Creating primary key on [Id] in table 'USERS'
ALTER TABLE [dbo].[USERS]
ADD CONSTRAINT [PK_USERS]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDOFCUSTUMER] in table 'DELIVERIES'
ALTER TABLE [dbo].[DELIVERIES]
ADD CONSTRAINT [FK__DELIVERIE__IDOFC__2B3F6F97]
    FOREIGN KEY ([IDOFCUSTUMER])
    REFERENCES [dbo].[USERS]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DELIVERIE__IDOFC__2B3F6F97'
CREATE INDEX [IX_FK__DELIVERIE__IDOFC__2B3F6F97]
ON [dbo].[DELIVERIES]
    ([IDOFCUSTUMER]);
GO

-- Creating foreign key on [IDOFDELIVER] in table 'DELIVERIES'
ALTER TABLE [dbo].[DELIVERIES]
ADD CONSTRAINT [FK__DELIVERIE__IDOFD__2A4B4B5E]
    FOREIGN KEY ([IDOFDELIVER])
    REFERENCES [dbo].[USERS]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__DELIVERIE__IDOFD__2A4B4B5E'
CREATE INDEX [IX_FK__DELIVERIE__IDOFD__2A4B4B5E]
ON [dbo].[DELIVERIES]
    ([IDOFDELIVER]);
GO

-- Creating foreign key on [DELIVERYID] in table 'RATING'
ALTER TABLE [dbo].[RATING]
ADD CONSTRAINT [FK__RATING__DELIVERY__36B12243]
    FOREIGN KEY ([DELIVERYID])
    REFERENCES [dbo].[DELIVERIES]
        ([DELIVERID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DeliveryId] in table 'NOTCONFIRM'
ALTER TABLE [dbo].[NOTCONFIRM]
ADD CONSTRAINT [FK_T1]
    FOREIGN KEY ([DeliveryId])
    REFERENCES [dbo].[DELIVERIES]
        ([DELIVERID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T1'
CREATE INDEX [IX_FK_T1]
ON [dbo].[NOTCONFIRM]
    ([DeliveryId]);
GO

-- Creating foreign key on [PossibleDriveId] in table 'NOTCONFIRM'
ALTER TABLE [dbo].[NOTCONFIRM]
ADD CONSTRAINT [FK_T2]
    FOREIGN KEY ([PossibleDriveId])
    REFERENCES [dbo].[POSSIBLEDRIVE]
        ([KODOFDRIVE])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_T2'
CREATE INDEX [IX_FK_T2]
ON [dbo].[NOTCONFIRM]
    ([PossibleDriveId]);
GO

-- Creating foreign key on [IDOFDELIVER] in table 'POSSIBLEDRIVE'
ALTER TABLE [dbo].[POSSIBLEDRIVE]
ADD CONSTRAINT [FK__POSSIBLED__IDOFD__2E1BDC42]
    FOREIGN KEY ([IDOFDELIVER])
    REFERENCES [dbo].[USERS]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__POSSIBLED__IDOFD__2E1BDC42'
CREATE INDEX [IX_FK__POSSIBLED__IDOFD__2E1BDC42]
ON [dbo].[POSSIBLEDRIVE]
    ([IDOFDELIVER]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------