CREATE TABLE [dbo].[PaymentType]
(
	[PaymentTypeId] INT           IDENTITY (1, 1) NOT NULL,
	[Title]         NVARCHAR(255) NOT NULL,
	CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED ([PaymentTypeId] ASC)
)
