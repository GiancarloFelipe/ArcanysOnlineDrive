CREATE TABLE [dbo].[OnlineDrive] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [FileNameGUID]  NVARCHAR (255) NULL,
    [FileName]      NVARCHAR (255) NULL,
    [FilePath]      TEXT           NULL,
    [UploadedOn]    DATETIME       NOT NULL,
    [UploadedBy]    INT            NOT NULL,
    [LastUpdatedOn] DATETIME       NULL,
    [LastUpdatedBy] INT            NULL,
    [DeletedOn]     DATETIME       NULL,
    [DeletedBy]     INT            NULL,
    CONSTRAINT [PK_OnlineDrive] PRIMARY KEY CLUSTERED ([Id] ASC)
);

