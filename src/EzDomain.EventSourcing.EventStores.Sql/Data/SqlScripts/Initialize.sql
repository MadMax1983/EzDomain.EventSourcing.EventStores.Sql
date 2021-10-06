IF NOT EXISTS (SELECT 1
               FROM sys.schemas [s]
               WHERE [s].[name] = N'EventStore')
    EXEC('CREATE SCHEMA [EventStore]')

IF NOT EXISTS (SELECT 1
               FROM sys.objects [o]
               JOIN sys.schemas [s] ON [s].[schema_id] = [o].[schema_id]
               WHERE [o].[name] = N'Events'
               AND [s].[name] = N'EventStore')
CREATE TABLE [EventStore].[Events]
(
    [Version] bigint NOT NULL,
    [AggregateRootId] nvarchar(64) NOT NULL,
    [StreamId] nvarchar(64) NOT NULL,
    [TimestampUtc] datetime2 NOT NULL,
    [Type] nvarchar(512) NOT NULL,
    [Data] nvarchar(max) NOT NULL,
    [Metadata] nvarchar(max) NULL,
    CONSTRAINT [PK_EventStore_Events_Version_AggregateRootId] PRIMARY KEY ([Version], [AggregateRootId])
)