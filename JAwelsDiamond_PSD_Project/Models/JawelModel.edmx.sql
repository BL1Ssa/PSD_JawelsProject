
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2025 23:08:38
-- Generated from EDMX file: C:\Users\TisGJRRR\source\repos\PSD_JawelsProject\JAwelsDiamond_PSD_Project\Models\JawelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Jawelsdatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cart_ToTable_MsJewel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carts] DROP CONSTRAINT [FK_Cart_ToTable_MsJewel];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_ToTable_MsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carts] DROP CONSTRAINT [FK_Cart_ToTable_MsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_MsJewel_ToTable_MsBrand]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsJewels] DROP CONSTRAINT [FK_MsJewel_ToTable_MsBrand];
GO
IF OBJECT_ID(N'[dbo].[FK_MsJewel_ToTable_MsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MsJewels] DROP CONSTRAINT [FK_MsJewel_ToTable_MsCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionDetail_MsJewel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionDetails] DROP CONSTRAINT [FK_TransactionDetail_MsJewel];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionDetail_TransactionHeader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionDetails] DROP CONSTRAINT [FK_TransactionDetail_TransactionHeader];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionHeader_ToTable_MsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionHeaders] DROP CONSTRAINT [FK_TransactionHeader_ToTable_MsUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carts];
GO
IF OBJECT_ID(N'[dbo].[MsBrands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsBrands];
GO
IF OBJECT_ID(N'[dbo].[MsCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsCategories];
GO
IF OBJECT_ID(N'[dbo].[MsJewels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsJewels];
GO
IF OBJECT_ID(N'[dbo].[MsUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MsUsers];
GO
IF OBJECT_ID(N'[dbo].[TransactionDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionDetails];
GO
IF OBJECT_ID(N'[dbo].[TransactionHeaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionHeaders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [UserID] int  NOT NULL,
    [JewelID] int  NOT NULL,
    [Quantity] int  NOT NULL
);
GO

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

-- Creating table 'TransactionDetails'
CREATE TABLE [dbo].[TransactionDetails] (
    [TransactionID] int  NOT NULL,
    [JewelID] int  NOT NULL,
    [Quantity] int  NOT NULL
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID], [JewelID], [Quantity] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([UserID], [JewelID], [Quantity] ASC);
GO

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

-- Creating primary key on [TransactionID], [JewelID], [Quantity] in table 'TransactionDetails'
ALTER TABLE [dbo].[TransactionDetails]
ADD CONSTRAINT [PK_TransactionDetails]
    PRIMARY KEY CLUSTERED ([TransactionID], [JewelID], [Quantity] ASC);
GO

-- Creating primary key on [TransactionID] in table 'TransactionHeaders'
ALTER TABLE [dbo].[TransactionHeaders]
ADD CONSTRAINT [PK_TransactionHeaders]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [UserID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_ToTable_MsUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[MsUsers]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

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