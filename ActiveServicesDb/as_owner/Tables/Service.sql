CREATE TABLE [as_owner].[Service] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ServiceName] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED ([Id] ASC)
);

