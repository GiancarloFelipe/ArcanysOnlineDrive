CREATE TABLE [dbo].[Menus] (
    [PageID]          INT           IDENTITY (1, 1) NOT NULL,
    [PageName]        VARCHAR (150) NOT NULL,
    [PageDescription] VARCHAR (255) NOT NULL,
    [PageURL]         VARCHAR (150) NOT NULL,
    [PageIcon]        VARCHAR (50)  NOT NULL,
    [isEnabled]       BIT           NOT NULL,
    [CreatedOn]       DATETIME      NOT NULL,
    [CreatedBy]       INT           NOT NULL,
    [LastUpdatedOn]   DATETIME      NULL,
    [LastUpdatedBy]   INT           NULL,
    [DeletedOn]       DATETIME      NULL,
    [DeletedBy]       INT           NULL,
    CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED ([PageID] ASC)
);

