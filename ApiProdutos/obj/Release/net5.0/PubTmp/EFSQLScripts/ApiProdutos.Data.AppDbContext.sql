IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019191757_initial')
BEGIN
    CREATE TABLE [Produtos] (
        [Id] int NOT NULL IDENTITY,
        [Nome] nvarchar(60) NULL,
        [Preco] decimal(10,2) NOT NULL,
        [Estoque] int NOT NULL,
        CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019191757_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] ON;
    EXEC(N'INSERT INTO [Produtos] ([Id], [Estoque], [Nome], [Preco])
    VALUES (1, 10, N''Fichario'', 10.75)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019191757_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] ON;
    EXEC(N'INSERT INTO [Produtos] ([Id], [Estoque], [Nome], [Preco])
    VALUES (2, 8, N''Bolsinha'', 30.5)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019191757_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] ON;
    EXEC(N'INSERT INTO [Produtos] ([Id], [Estoque], [Nome], [Preco])
    VALUES (3, 5, N''Lapiseira'', 100.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Estoque', N'Nome', N'Preco') AND [object_id] = OBJECT_ID(N'[Produtos]'))
        SET IDENTITY_INSERT [Produtos] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019191757_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221019191757_initial', N'5.0.17');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019203825_v2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221019203825_v2', N'5.0.17');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019204828_v3')
BEGIN
    CREATE TABLE [Departamentos] (
        [departamentoId] int NOT NULL IDENTITY,
        [nome] nvarchar(60) NULL,
        [maximoFuncionarios] int NOT NULL,
        CONSTRAINT [PK_Departamentos] PRIMARY KEY ([departamentoId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019204828_v3')
BEGIN
    CREATE TABLE [Funcionarios] (
        [funcionarioId] int NOT NULL IDENTITY,
        [nome] nvarchar(60) NULL,
        [departamento_id] int NOT NULL,
        [data_entrada] datetime2 NOT NULL,
        CONSTRAINT [PK_Funcionarios] PRIMARY KEY ([funcionarioId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019204828_v3')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'departamentoId', N'maximoFuncionarios', N'nome') AND [object_id] = OBJECT_ID(N'[Departamentos]'))
        SET IDENTITY_INSERT [Departamentos] ON;
    EXEC(N'INSERT INTO [Departamentos] ([departamentoId], [maximoFuncionarios], [nome])
    VALUES (1, 10, N''TI''),
    (2, 10, N''Suporte'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'departamentoId', N'maximoFuncionarios', N'nome') AND [object_id] = OBJECT_ID(N'[Departamentos]'))
        SET IDENTITY_INSERT [Departamentos] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019204828_v3')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'funcionarioId', N'data_entrada', N'departamento_id', N'nome') AND [object_id] = OBJECT_ID(N'[Funcionarios]'))
        SET IDENTITY_INSERT [Funcionarios] ON;
    EXEC(N'INSERT INTO [Funcionarios] ([funcionarioId], [data_entrada], [departamento_id], [nome])
    VALUES (1, ''2022-10-19T17:48:28.4367909-03:00'', 1, N''Filipe''),
    (2, ''2022-10-19T17:48:28.4374188-03:00'', 2, N''Fernando'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'funcionarioId', N'data_entrada', N'departamento_id', N'nome') AND [object_id] = OBJECT_ID(N'[Funcionarios]'))
        SET IDENTITY_INSERT [Funcionarios] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221019204828_v3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221019204828_v3', N'5.0.17');
END;
GO

COMMIT;
GO

