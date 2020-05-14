CREATE TABLE [House].[Sources]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] NVARCHAR(500) NOT NULL, 
    [Joined] DATE NOT NULL
    CONSTRAINT [PK_HouseSources_Id] PRIMARY KEY (Id), 
)
