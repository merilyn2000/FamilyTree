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

CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [PersonId] nvarchar(max) NULL,
    [BirthDate] datetime2 NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [DeathDate] datetime2 NOT NULL,
    [Sex] int NOT NULL,
    [PairId] nvarchar(max) NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vehicles] (
    [VehicleId] int NOT NULL IDENTITY,
    [VehicleType] nvarchar(max) NULL,
    [MaxSpeed] int NOT NULL,
    [Wheels] int NOT NULL,
    [Combustible] nvarchar(max) NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [PersonId] int NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([VehicleId]),
    CONSTRAINT [FK_Vehicles_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Vehicles_PersonId] ON [Vehicles] ([PersonId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210302114545_init', N'5.0.3');
GO

COMMIT;
GO

