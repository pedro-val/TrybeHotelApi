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

CREATE TABLE [Cities] (
    [CityId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId])
);
GO

CREATE TABLE [Hotels] (
    [HotelId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Adress] nvarchar(max) NULL,
    [CityId] int NULL,
    CONSTRAINT [PK_Hotels] PRIMARY KEY ([HotelId]),
    CONSTRAINT [FK_Hotels_Cities_CityId] FOREIGN KEY ([CityId]) REFERENCES [Cities] ([CityId])
);
GO

CREATE TABLE [Rooms] (
    [RoomId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Capacity] int NOT NULL,
    [Image] nvarchar(max) NULL,
    [HotelId] int NULL,
    CONSTRAINT [PK_Rooms] PRIMARY KEY ([RoomId]),
    CONSTRAINT [FK_Rooms_Hotels_HotelId] FOREIGN KEY ([HotelId]) REFERENCES [Hotels] ([HotelId])
);
GO

CREATE INDEX [IX_Hotels_CityId] ON [Hotels] ([CityId]);
GO

CREATE INDEX [IX_Rooms_HotelId] ON [Rooms] ([HotelId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231019214104_firstMigration', N'7.0.4');
GO

COMMIT;
GO

