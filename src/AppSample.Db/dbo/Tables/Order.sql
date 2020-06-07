CREATE TABLE [dbo].[Order]
(
	[OrderId]       INT           IDENTITY (1, 1) NOT NULL,
	[OrderDate]     DATE          NOT NULL,
	[ClientAddress] NVARCHAR(255) NOT NULL,
	[CompanyId]     INT           NOT NULL,
	[PaymentTypeId] INT           NOT NULL,
	[IsCompleted]    BIT           NOT NULL DEFAULT 0,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC),
	CONSTRAINT [FK_Order_Company] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([CompanyId]),
	CONSTRAINT [FK_Order_PaymentType] FOREIGN KEY ([PaymentTypeId]) REFERENCES [dbo].[PaymentType] ([PaymentTypeId])
)
