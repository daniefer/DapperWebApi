﻿CREATE TABLE [House].[Types]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT [PK_HouseTypes_Id] PRIMARY KEY ([Id])
)