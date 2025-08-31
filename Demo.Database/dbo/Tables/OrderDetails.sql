CREATE TABLE OrderDetails (
	[Id] [bigint] NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[Product] [varchar](150) NOT NULL,
	[Price] [numeric](10,2) NOT NULL,
	[Quantity] [numeric](10,2) NOT NULL,
	[Discount] [numeric](10,2) NULL,
	[Total] [numeric](10,2) NOT NULL,

	CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
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

ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO