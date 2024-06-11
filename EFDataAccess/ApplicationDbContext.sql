CREATE TABLE [Authors] (
    [Author_Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Location] nvarchar(max) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Author_Id])
);
GO


CREATE TABLE [Books] (
    [BookId] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [ISBN] nvarchar(20) NOT NULL,
    [Price] decimal(10,5) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([BookId])
);
GO


CREATE TABLE [Categories] (
    [CatagoryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CatagoryId])
);
GO


CREATE TABLE [Publishers] (
    [Publisher_Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Location] nvarchar(max) NULL,
    CONSTRAINT [PK_Publishers] PRIMARY KEY ([Publisher_Id])
);
GO


CREATE TABLE [SubCategories] (
    [SubCategory_Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_SubCategories] PRIMARY KEY ([SubCategory_Id])
);
GO


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'ISBN', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([BookId], [ISBN], [Price], [Title])
VALUES (1, N'123456789', 10.5, N'Book 1'),
(2, N'987654321', 20.5, N'Book 2'),
(3, N'123456789', 30.5, N'Book 3'),
(4, N'987654321', 40.5, N'Book 4'),
(5, N'123456789', 50.5, N'Book 5');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'ISBN', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;
GO