CREATE TABLE [dbo].[Company]
(
	[CompanyId] INT           IDENTITY (1, 1) NOT NULL,
	[Title]     NVARCHAR(255) NOT NULL,
	CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
)
