CREATE TABLE Orders (
	[Id] [bigint] NOT NULL,
	[CustomerId] [bigint] NOT NULL,
	[City] [varchar](50) NULL,
	[Street] [varchar](100) NULL,
	[ZipCode] [varchar](10) NULL,
	[CreationDate] [date] NULL,
	[ShippingDate] [date] NULL,
	[Total] [numeric](10,2) NULL,

	CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)  WITH (
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON, 
		OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
	) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO