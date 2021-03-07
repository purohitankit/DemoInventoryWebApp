

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](40) NULL,
	[Description] [nvarchar](100) NULL,
	[Price] [int] NULL,
	[Picture] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


