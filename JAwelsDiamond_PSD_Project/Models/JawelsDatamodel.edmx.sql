
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/24/2025 21:37:59
-- Generated from EDMX file: C:\Users\alvin\Code\PSD\JAwelsDiamond_PSD_Project\Models\JawelsDatamodel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [JawelsDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[FK_Cart_ToTable_MsJewel]', 'F') IS NOT NULL
    ALTER TABLE [JawelsDatabaseModelStoreContainer].[Cart] DROP CONSTRAINT [FK_Cart_ToTable_MsJewel];
GO
IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[FK_Cart_ToTable_MsUser]', 'F') IS NOT NULL
    ALTER TABLE [JawelsDatabaseModelStoreContainer].[Cart] DROP CONSTRAINT [FK_Cart_ToTable_MsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_MsJewel_ToTable_MsBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsJewel] DROP CONSTRAINT [FK_MsJewel_ToTable_MsBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_MsJewel_ToTable_MsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsJewel] DROP CONSTRAINT [FK_MsJewel_ToTable_MsCategory];
GO
IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[FK_TransactionDetail_MsJewel]', 'F') IS NOT NULL
    ALTER TABLE [JawelsDatabaseModelStoreContainer].[TransactionDetail] DROP CONSTRAINT [FK_TransactionDetail_MsJewel];
GO
IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[FK_TransactionDetail_TransactionHeader]', 'F') IS NOT NULL
    ALTER TABLE [JawelsDatabaseModelStoreContainer].[TransactionDetail] DROP CONSTRAINT [FK_TransactionDetail_TransactionHeader];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionHeader_ToTable_MsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionHeader] DROP CONSTRAINT [FK_TransactionHeader_ToTable_MsUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MsBrand]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsBrand];
GO
IF OBJECT_ID(N'[dbo].[MsCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsCategory];
GO
IF OBJECT_ID(N'[dbo].[MsJewel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsJewel];
GO
IF OBJECT_ID(N'[dbo].[MsUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsUser];
GO
IF OBJECT_ID(N'[dbo].[TransactionHeader]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionHeader];
GO
IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[Cart]', 'U') IS NOT NULL
    DROP TABLE [JawelsDatabaseModelStoreContainer].[Cart];
GO
IF OBJECT_ID(N'[JawelsDatabaseModelStoreContainer].[TransactionDetail]', 'U') IS NOT NULL
    DROP TABLE [JawelsDatabaseModelStoreContainer].[TransactionDetail];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MsBrands'
CREATE TABLE [dbo].[MsBrands] (
    [BrandID] int  NOT NULL,
    [BrandName] varchar(50)  NOT NULL,
    [BrandCountry] varchar(50)  NOT NULL,
    [BrandClass] varchar(20)  NOT NULL
);
GO

-- Creating table 'MsCategories'
CREATE TABLE [dbo].[MsCategories] (
    [CategoryID] int  NOT NULL,
    [CategoryName] varchar(15)  NOT NULL
);
GO

-- Creating table 'MsJewels'
CREATE TABLE [dbo].[MsJewels] (
    [JewelID] int IDENTITY(1,1) NOT NULL,
    [BrandID] int  NOT NULL,
    [CategoryID] int  NOT NULL,
    [JewelName] varchar(100)  NOT NULL,
    [JewelPrice] int  NOT NULL,
    [JewelReleaseYear] int  NOT NULL
);
GO

-- Creating table 'MsUsers'
CREATE TABLE [dbo].[MsUsers] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] varchar(100)  NOT NULL,
    [UserPassword] varchar(20)  NOT NULL,
    [UserEmail] varchar(100)  NOT NULL,
    [UserDOB] datetime  NOT NULL,
    [UserGender] varchar(10)  NOT NULL,
    [UserRole] varchar(10)  NOT NULL
);
GO

-- Creating table 'TransactionHeaders'
CREATE TABLE [dbo].[TransactionHeaders] (
    [TransactionID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [TransactionDate] datetime  NOT NULL,
    [PaymentMethod] varchar(50)  NOT NULL,
    [TransactionStatus] varchar(50)  NOT NULL
);
GO

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [UserID] int  NOT NULL,
    [JewelID] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'TransactionDetails'
CREATE TABLE [dbo].[TransactionDetails] (
    [TransactionID] int  NOT NULL,
    [JewelID] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BrandID] in table 'MsBrands'
ALTER TABLE [dbo].[MsBrands]
ADD CONSTRAINT [PK_MsBrands]
    PRIMARY KEY CLUSTERED ([BrandID] ASC);
GO

-- Creating primary key on [CategoryID] in table 'MsCategories'
ALTER TABLE [dbo].[MsCategories]
ADD CONSTRAINT [PK_MsCategories]
    PRIMARY KEY CLUSTERED ([CategoryID] ASC);
GO

-- Creating primary key on [JewelID] in table 'MsJewels'
ALTER TABLE [dbo].[MsJewels]
ADD CONSTRAINT [PK_MsJewels]
    PRIMARY KEY CLUSTERED ([JewelID] ASC);
GO

-- Creating primary key on [UserID] in table 'MsUsers'
ALTER TABLE [dbo].[MsUsers]
ADD CONSTRAINT [PK_MsUsers]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [TransactionID] in table 'TransactionHeaders'
ALTER TABLE [dbo].[TransactionHeaders]
ADD CONSTRAINT [PK_TransactionHeaders]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- Creating primary key on [UserID], [JewelID], [Quantity] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([UserID], [JewelID], [Quantity] ASC);
GO

-- Creating primary key on [TransactionID], [JewelID], [Quantity] in table 'TransactionDetails'
ALTER TABLE [dbo].[TransactionDetails]
ADD CONSTRAINT [PK_TransactionDetails]
    PRIMARY KEY CLUSTERED ([TransactionID], [JewelID], [Quantity] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandID] in table 'MsJewels'
ALTER TABLE [dbo].[MsJewels]
ADD CONSTRAINT [FK_MsJewel_ToTable_MsBrand]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[MsBrands]
        ([BrandID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsJewel_ToTable_MsBrand'
CREATE INDEX [IX_FK_MsJewel_ToTable_MsBrand]
ON [dbo].[MsJewels]
    ([BrandID]);
GO

-- Creating foreign key on [CategoryID] in table 'MsJewels'
ALTER TABLE [dbo].[MsJewels]
ADD CONSTRAINT [FK_MsJewel_ToTable_MsCategory]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[MsCategories]
        ([CategoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MsJewel_ToTable_MsCategory'
CREATE INDEX [IX_FK_MsJewel_ToTable_MsCategory]
ON [dbo].[MsJewels]
    ([CategoryID]);
GO

-- Creating foreign key on [JewelID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_ToTable_MsJewel]
    FOREIGN KEY ([JewelID])
    REFERENCES [dbo].[MsJewels]
        ([JewelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_ToTable_MsJewel'
CREATE INDEX [IX_FK_Cart_ToTable_MsJewel]
ON [dbo].[Carts]
    ([JewelID]);
GO

-- Creating foreign key on [JewelID] in table 'TransactionDetails'
ALTER TABLE [dbo].[TransactionDetails]
ADD CONSTRAINT [FK_TransactionDetail_MsJewel]
    FOREIGN KEY ([JewelID])
    REFERENCES [dbo].[MsJewels]
        ([JewelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionDetail_MsJewel'
CREATE INDEX [IX_FK_TransactionDetail_MsJewel]
ON [dbo].[TransactionDetails]
    ([JewelID]);
GO

-- Creating foreign key on [UserID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_ToTable_MsUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[MsUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'TransactionHeaders'
ALTER TABLE [dbo].[TransactionHeaders]
ADD CONSTRAINT [FK_TransactionHeader_ToTable_MsUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[MsUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionHeader_ToTable_MsUser'
CREATE INDEX [IX_FK_TransactionHeader_ToTable_MsUser]
ON [dbo].[TransactionHeaders]
    ([UserID]);
GO

-- Creating foreign key on [TransactionID] in table 'TransactionDetails'
ALTER TABLE [dbo].[TransactionDetails]
ADD CONSTRAINT [FK_TransactionDetail_TransactionHeader]
    FOREIGN KEY ([TransactionID])
    REFERENCES [dbo].[TransactionHeaders]
        ([TransactionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------