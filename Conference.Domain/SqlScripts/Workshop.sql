IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    CREATE TABLE [Workshops] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [PlacesAvailable] int NULL,
        [RegistrationLink] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [RegistrationOpened] bit NOT NULL,
        [Prerequisites] nvarchar(max) NULL,
        [ShortDescription] nvarchar(max) NULL,
        CONSTRAINT [PK_Workshops] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    CREATE TABLE [Speakers] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Company] nvarchar(max) NULL,
        [WebSite] nvarchar(max) NULL,
        [JobTitle] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [WorkshopId] int NULL,
        CONSTRAINT [PK_Speakers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Speakers_Workshops_WorkshopId] FOREIGN KEY ([WorkshopId]) REFERENCES [Workshops] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    CREATE TABLE [Talks] (
        [Id] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Level] nvarchar(max) NULL,
        [Active] bit NOT NULL,
        [Feedbackenabled] bit NOT NULL,
        [SpeakerId] int NOT NULL,
        CONSTRAINT [PK_Talks] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Talks_Speakers_SpeakerId] FOREIGN KEY ([SpeakerId]) REFERENCES [Speakers] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    CREATE INDEX [IX_Speakers_WorkshopId] ON [Speakers] ([WorkshopId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    CREATE UNIQUE INDEX [IX_Talks_SpeakerId] ON [Talks] ([SpeakerId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201217174624_Workshops')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201217174624_Workshops', N'3.1.10');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210104200552_Workshop')
BEGIN
    ALTER TABLE [Talks] DROP CONSTRAINT [FK_Talks_Speakers_SpeakerId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210104200552_Workshop')
BEGIN
    DROP TABLE [Speakers];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210104200552_Workshop')
BEGIN
    DROP INDEX [IX_Talks_SpeakerId] ON [Talks];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210104200552_Workshop')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210104200552_Workshop', N'3.1.10');
END;

GO

