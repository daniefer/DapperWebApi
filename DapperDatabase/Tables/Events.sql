CREATE TABLE [House].[Events]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1),
	[Type] INT NOT NULL,
	[Timestamp] DATETIMEOFFSET NOT NULL,
	[TimeZone] NVARCHAR(100) NOT NULL, 
    [SourceId] INT NOT NULL, 
    [EnteredDate] DATE NOT NULL, 
    [UtcTimestamp] DATETIME2 NOT NULL, 
    CONSTRAINT [PK_HouseEvents_Id] PRIMARY KEY (Id), 
    CONSTRAINT [FK_HouseEvents_Source] FOREIGN KEY ([SourceId]) REFERENCES [House].[Sources]([Id]),
	INDEX [IX_HouseEvents_Type] NONCLUSTERED ([Type])
)
