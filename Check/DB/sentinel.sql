USE [Sentinel]
GO
/****** Object:  Table [dbo].[HardKod]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HardKod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UstKodId] [int] NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKKId] [int] NULL,
 CONSTRAINT [PK_HardKod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kod]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UstKodId] [int] NULL,
	[KodTipId] [int] NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKKId] [int] NULL,
 CONSTRAINT [PK_Kod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KodTip]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KodTip](
	[Id] [int] NOT NULL,
	[UstKodId] [int] NULL,
	[HardKodId] [int] NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKKId] [int] NULL,
 CONSTRAINT [PK_KodTip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationClaims]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKKId] [int] NULL,
 CONSTRAINT [PK_OperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sicil] [nvarchar](6) NOT NULL,
	[Tckn] [nvarchar](11) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[CinsiyetKodıd] [int] NOT NULL,
	[RutbeKodId] [int] NOT NULL,
	[SubeKodId] [int] NOT NULL,
	[NobetTutabilirMi] [bit] NOT NULL,
	[CocukDurumu] [bit] NOT NULL,
	[CepNo] [nvarchar](10) NOT NULL,
	[Dahili] [nvarchar](5) NOT NULL,
	[BirimBaslamaTarihi] [datetime] NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKKId] [int] NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserOperationClaims]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserOperationClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[OperationClaimId] [bigint] NOT NULL,
	[AktifMi] [bit] NOT NULL,
	[IKT] [datetime] NOT NULL,
	[IKKId] [int] NOT NULL,
	[SKT] [datetime] NULL,
	[SKTId] [int] NULL,
 CONSTRAINT [PK_UserOperationClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5.10.2021 23:06:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PasswordHash] [varbinary](max) NOT NULL,
	[PasswordSalt] [varbinary](max) NOT NULL,
	[AktifMi] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[HardKod] ADD  CONSTRAINT [DF_HardKod_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[Kod] ADD  CONSTRAINT [DF_Kod_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[KodTip] ADD  CONSTRAINT [DF_KodTip_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[OperationClaims] ADD  CONSTRAINT [DF_OperationClaims_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[Personel] ADD  CONSTRAINT [DF_Personel_CocukDurumu]  DEFAULT ((0)) FOR [CocukDurumu]
GO
ALTER TABLE [dbo].[Personel] ADD  CONSTRAINT [DF_Personel_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[UserOperationClaims] ADD  CONSTRAINT [DF_UserOperationClaims_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AktifMi]  DEFAULT ((0)) FOR [AktifMi]
GO
ALTER TABLE [dbo].[HardKod]  WITH CHECK ADD  CONSTRAINT [FK_HardKodUstKodId_HardKodId] FOREIGN KEY([UstKodId])
REFERENCES [dbo].[HardKod] ([Id])
GO
ALTER TABLE [dbo].[HardKod] CHECK CONSTRAINT [FK_HardKodUstKodId_HardKodId]
GO
ALTER TABLE [dbo].[Kod]  WITH CHECK ADD  CONSTRAINT [FK_KodKodTipId_KodTipId] FOREIGN KEY([KodTipId])
REFERENCES [dbo].[KodTip] ([Id])
GO
ALTER TABLE [dbo].[Kod] CHECK CONSTRAINT [FK_KodKodTipId_KodTipId]
GO
ALTER TABLE [dbo].[Kod]  WITH CHECK ADD  CONSTRAINT [FK_KodUstKodId_KodId] FOREIGN KEY([UstKodId])
REFERENCES [dbo].[Kod] ([Id])
GO
ALTER TABLE [dbo].[Kod] CHECK CONSTRAINT [FK_KodUstKodId_KodId]
GO
ALTER TABLE [dbo].[KodTip]  WITH CHECK ADD  CONSTRAINT [FK_KodTipHardKodId_HardKodId] FOREIGN KEY([HardKodId])
REFERENCES [dbo].[HardKod] ([Id])
GO
ALTER TABLE [dbo].[KodTip] CHECK CONSTRAINT [FK_KodTipHardKodId_HardKodId]
GO
ALTER TABLE [dbo].[KodTip]  WITH CHECK ADD  CONSTRAINT [FK_KodTipUstKodId_KodTipId] FOREIGN KEY([UstKodId])
REFERENCES [dbo].[KodTip] ([Id])
GO
ALTER TABLE [dbo].[KodTip] CHECK CONSTRAINT [FK_KodTipUstKodId_KodTipId]
GO
