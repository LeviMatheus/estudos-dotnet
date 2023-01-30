IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [CodigoBarras] nvarchar(max) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [TipoProduto] int NOT NULL,
    [Ativo] bit NOT NULL,
    [Nome] VARCHAR(80) NOT NULL,
    [Phone] CHAR(11) NOT NULL,
    [Cep] CHAR(8) NOT NULL,
    [Cidade] nvarchar(60) NOT NULL,
    [Estado] CHAR(15) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Produto] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Telefone] decimal(18,2) NOT NULL,
    [Cep] decimal(18,2) NOT NULL,
    [Estado] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [CodigoBarras] VARCHAR(80) NOT NULL,
    [Descricao] CHAR(11) NOT NULL,
    [Valor] float NOT NULL,
    [Ativo] bit NOT NULL,
    [TipoProduto] int NOT NULL,
    CONSTRAINT [PK_Produto] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pedido] (
    [Id] int NOT NULL IDENTITY,
    [ClienteId] int NOT NULL,
    [IniciadoEm] datetime2 NOT NULL,
    [FinalizadoEm] datetime2 NOT NULL,
    [TipoFrete] nvarchar(max) NOT NULL,
    [StatusPedido] nvarchar(max) NOT NULL,
    [Observacao] CHAR(50) NOT NULL,
    [FinalizandoEm] datetime2 NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Pedido] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pedido_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PedidoItem] (
    [Id] int NOT NULL IDENTITY,
    [PedidoId] int NOT NULL,
    [Quantidade] int NOT NULL DEFAULT 1,
    [Valor] float NOT NULL,
    [Desconto] float NOT NULL,
    [ProdutoId] int NOT NULL,
    CONSTRAINT [PK_PedidoItem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PedidoItem_Pedido_PedidoId] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PedidoItem_Produto_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Pedido_ClienteId] ON [Pedido] ([ClienteId]);
GO

CREATE INDEX [IX_PedidoItem_PedidoId] ON [PedidoItem] ([PedidoId]);
GO

CREATE INDEX [IX_PedidoItem_ProdutoId] ON [PedidoItem] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230130164727_Inicial', N'7.0.2');
GO

COMMIT;
GO

