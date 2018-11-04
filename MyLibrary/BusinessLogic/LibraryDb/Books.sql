﻿CREATE TABLE [Books]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(200) NOT NULL, 
    [Year] INT NOT NULL CHECK([Year] <= YEAR(GETDATE()) AND [Year] > 0)
)