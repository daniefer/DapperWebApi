﻿CREATE TABLE [House].[Events]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Timestamp] DATETIME2(7) NOT NULL,
	[Type] INT NOT NULL,
	CONSTRAINT [PK_HouseEvents_Id] PRIMARY KEY CLUSTERED ([Id]),
	INDEX [IX_HouseEvents_Type] NONCLUSTERED ([Type])
)

GO

