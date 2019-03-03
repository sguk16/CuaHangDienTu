USE [ThietBi]
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDTB]    Script Date: 03/03/2019 13:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDTB]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)
	IF (SELECT COUNT(id) FROM ThietBi) = 0
		SET @ID = '00000001'
	ELSE
		SELECT @ID = MAX(RIGHT(id, 7)) FROM ThietBi
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TB0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TB000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEn @ID <100 AND @ID >9 THEN 'TB00000'+ CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[ThietBi]    Script Date: 03/03/2019 13:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThietBi](
	[id] [char](10) NOT NULL,
	[ten] [nvarchar](100) NOT NULL,
	[gia] [int] NOT NULL,
	[soluong] [int] NOT NULL,
	[loai] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDKH]    Script Date: 03/03/2019 13:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDKH]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)
	IF (SELECT COUNT(id) FROM KhachHang) = 0
		SET @ID = '00000001'
	ELSE
		SELECT @ID = MAX(RIGHT(id, 7)) FROM KHACHHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'KH0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'KH000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEn @ID <100 AND @ID >9 THEN 'KH00000'+ CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 03/03/2019 13:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [varchar](10) NOT NULL,
	[ten] [nvarchar](100) NULL,
	[diachi] [nvarchar](100) NULL,
	[sdt] [char](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[AUTO_IDHD]    Script Date: 03/03/2019 13:39:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AUTO_IDHD]()
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)
	IF (SELECT COUNT(id) FROM HoaDon) = 0
		SET @ID = '00000001'
	ELSE
		SELECT @ID = MAX(RIGHT(id, 7)) FROM KHACHHANG
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'HD0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'HD000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEn @ID <100 AND @ID >9 THEN 'HD00000'+ CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 03/03/2019 13:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[id] [char](10) NOT NULL,
	[idkhanghang] [char](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[tongtien] [int] NOT NULL,
	[diachigiao] [nvarchar](100) NULL,
	[giaohang] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTHoaDon]    Script Date: 03/03/2019 13:39:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CTHoaDon](
	[id] [char](10) NOT NULL,
	[idthietbi] [char](10) NOT NULL,
	[soluong] [int] NULL,
 CONSTRAINT [machitiet] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[idthietbi] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_HoaDon_id]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF_HoaDon_id]  DEFAULT ([DBO].[AUTO_IDHD]()) FOR [id]
GO
/****** Object:  Default [DF__HoaDon__tongtien__0CBAE877]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [tongtien]
GO
/****** Object:  Default [id]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [id]  DEFAULT ([DBO].[AUTO_IDKH]()) FOR [id]
GO
/****** Object:  Default [DF_ThietBi_id]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[ThietBi] ADD  CONSTRAINT [DF_ThietBi_id]  DEFAULT ([DBO].[AUTO_IDTB]()) FOR [id]
GO
/****** Object:  Default [DF__ThietBi__ten__014935CB]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[ThietBi] ADD  DEFAULT (N'Unknown') FOR [ten]
GO
/****** Object:  Default [DF__ThietBi__gia__023D5A04]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[ThietBi] ADD  DEFAULT ((0)) FOR [gia]
GO
/****** Object:  Default [DF__ThietBi__soluong__03317E3D]    Script Date: 03/03/2019 13:39:16 ******/
ALTER TABLE [dbo].[ThietBi] ADD  DEFAULT ((0)) FOR [soluong]
GO
