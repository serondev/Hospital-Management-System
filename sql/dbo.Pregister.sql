CREATE TABLE [dbo].[Pregister] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [SSN]     VARCHAR (50) NULL,
    [Name]    VARCHAR (50) NULL,
    [Surname] VARCHAR (50) NULL,
    [Gender] VARCHAR(50) NULL, 
    [Doctor] VARCHAR(50) NULL, 
    [Explanation] VARCHAR(50) NULL, 
    [Time] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

