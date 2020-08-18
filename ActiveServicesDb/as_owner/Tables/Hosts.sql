CREATE TABLE [as_owner].[Hosts] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Hostname] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Hosts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

