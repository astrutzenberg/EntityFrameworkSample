CREATE TABLE [as_owner].[ServiceMessage] (
    [Id]        INT            NOT NULL,
    [HostId]    INT            NOT NULL,
    [ServiceId] INT            NOT NULL,
    [Message]   NVARCHAR (256) NOT NULL,
    [Notes]     NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NOT NULL,
    CONSTRAINT [PK_ServiceMessage] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ServiceMessage_Host] FOREIGN KEY ([HostId]) REFERENCES [as_owner].[Hosts] ([Id]),
    CONSTRAINT [FK_ServiceMessage_Service] FOREIGN KEY ([ServiceId]) REFERENCES [as_owner].[Service] ([Id])
);

