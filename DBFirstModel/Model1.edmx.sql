
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/19/2017 13:07:35
-- Generated from EDMX file: D:\users\hewei\documents\visual studio 2015\Projects\WebSiteMVC\DBFirstModel\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [website];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Articles_dbo_WebColumns_WebColumn_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Articles] DROP CONSTRAINT [FK_dbo_Articles_dbo_WebColumns_WebColumn_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Summaries_dbo_WebColumns_WebColumn_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Summaries] DROP CONSTRAINT [FK_dbo_Summaries_dbo_WebColumns_WebColumn_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_WebColumns_dbo_WebColumns_Parent_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WebColumns] DROP CONSTRAINT [FK_dbo_WebColumns_dbo_WebColumns_Parent_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_WebColumns_dbo_WebSites_WebSite_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WebColumns] DROP CONSTRAINT [FK_dbo_WebColumns_dbo_WebSites_WebSite_Id];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[Articles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articles];
GO
IF OBJECT_ID(N'[dbo].[Summaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Summaries];
GO
IF OBJECT_ID(N'[dbo].[WebColumns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WebColumns];
GO
IF OBJECT_ID(N'[dbo].[WebSites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WebSites];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Content] nvarchar(max)  NULL,
    [Images] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [PublishDate] datetime  NULL,
    [Sort] int  NOT NULL,
    [IsShow] bit  NOT NULL,
    [IsTop] bit  NOT NULL,
    [IsRecommend] bit  NOT NULL,
    [PageView] int  NOT NULL,
    [PublishUser] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Keyword] nvarchar(max)  NULL,
    [WebColumn_Id] int  NULL
);
GO

-- Creating table 'Summaries'
CREATE TABLE [dbo].[Summaries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Content] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NULL,
    [Keyword] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [CreateUser] nvarchar(max)  NULL,
    [WebColumn_Id] int  NULL
);
GO

-- Creating table 'WebColumns'
CREATE TABLE [dbo].[WebColumns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sort] int  NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Position] int  NULL,
    [ModuleType] int  NOT NULL,
    [IsOpenNew] bit  NOT NULL,
    [CanAddContent] bit  NOT NULL,
    [Title] nvarchar(max)  NULL,
    [Keyword] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Level] int  NOT NULL,
    [IsShow] bit  NOT NULL,
    [Parent_Id] int  NULL,
    [WebSite_Id] int  NULL
);
GO

-- Creating table 'WebSites'
CREATE TABLE [dbo].[WebSites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [WebUrl] nvarchar(max)  NULL,
    [Logo] nvarchar(max)  NULL,
    [Icon] nvarchar(max)  NULL,
    [Title] nvarchar(max)  NULL,
    [Keyword] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Copyright] nvarchar(max)  NULL,
    [Place] nvarchar(max)  NULL,
    [ZipCode] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [Others] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'TableSet'
CREATE TABLE [dbo].[TableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [age] nvarchar(max)  NOT NULL,
    [sex] nvarchar(max)  NOT NULL,
    [Context] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Summaries'
ALTER TABLE [dbo].[Summaries]
ADD CONSTRAINT [PK_Summaries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WebColumns'
ALTER TABLE [dbo].[WebColumns]
ADD CONSTRAINT [PK_WebColumns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WebSites'
ALTER TABLE [dbo].[WebSites]
ADD CONSTRAINT [PK_WebSites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TableSet'
ALTER TABLE [dbo].[TableSet]
ADD CONSTRAINT [PK_TableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WebColumn_Id] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [FK_dbo_Articles_dbo_WebColumns_WebColumn_Id]
    FOREIGN KEY ([WebColumn_Id])
    REFERENCES [dbo].[WebColumns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Articles_dbo_WebColumns_WebColumn_Id'
CREATE INDEX [IX_FK_dbo_Articles_dbo_WebColumns_WebColumn_Id]
ON [dbo].[Articles]
    ([WebColumn_Id]);
GO

-- Creating foreign key on [WebColumn_Id] in table 'Summaries'
ALTER TABLE [dbo].[Summaries]
ADD CONSTRAINT [FK_dbo_Summaries_dbo_WebColumns_WebColumn_Id]
    FOREIGN KEY ([WebColumn_Id])
    REFERENCES [dbo].[WebColumns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Summaries_dbo_WebColumns_WebColumn_Id'
CREATE INDEX [IX_FK_dbo_Summaries_dbo_WebColumns_WebColumn_Id]
ON [dbo].[Summaries]
    ([WebColumn_Id]);
GO

-- Creating foreign key on [Parent_Id] in table 'WebColumns'
ALTER TABLE [dbo].[WebColumns]
ADD CONSTRAINT [FK_dbo_WebColumns_dbo_WebColumns_Parent_Id]
    FOREIGN KEY ([Parent_Id])
    REFERENCES [dbo].[WebColumns]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_WebColumns_dbo_WebColumns_Parent_Id'
CREATE INDEX [IX_FK_dbo_WebColumns_dbo_WebColumns_Parent_Id]
ON [dbo].[WebColumns]
    ([Parent_Id]);
GO

-- Creating foreign key on [WebSite_Id] in table 'WebColumns'
ALTER TABLE [dbo].[WebColumns]
ADD CONSTRAINT [FK_dbo_WebColumns_dbo_WebSites_WebSite_Id]
    FOREIGN KEY ([WebSite_Id])
    REFERENCES [dbo].[WebSites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_WebColumns_dbo_WebSites_WebSite_Id'
CREATE INDEX [IX_FK_dbo_WebColumns_dbo_WebSites_WebSite_Id]
ON [dbo].[WebColumns]
    ([WebSite_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------