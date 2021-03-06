/****** Object:  Table [dbo].[T_System_Params]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_System_Params]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_System_Params](
	[ParamKey] [nvarchar](50) NOT NULL,
	[ParamValue] [nvarchar](200) NULL,
 CONSTRAINT [PK_T_System_Params] PRIMARY KEY CLUSTERED 
(
	[ParamKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Page_Menus]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Page_Menus]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Page_Menus](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[PIndex] [int] NULL,
	[IsInner] [bit] NULL,
	[IsListType] [bit] NULL,
	[InnerItemId] [nvarchar](50) NULL,
	[OuterUrl] [nvarchar](255) NULL,
	[ParentId] [nvarchar](50) NULL,
	[IsNewWindow] [bit] NULL,
	[PLevel] [int] NULL,
	[CreateTime] [datetime] NULL,
	[LastUpdateTime] [datetime] NULL,
 CONSTRAINT [PK_T_Menu_List] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Page_List]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Page_List]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Page_List](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[CreateTime] [datetime] NULL,
	[LastUpdateTime] [datetime] NULL,
 CONSTRAINT [PK_T_Item_List_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Page_Html]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Page_Html]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Page_Html](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[TitleHtml] [nvarchar](1000) NULL,
	[ContentHtml] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL,
	[LastUpdateTime] [datetime] NULL,
	[ParentListId] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Item_Html] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Log_List]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Log_List]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Log_List](
	[Id] [uniqueidentifier] NOT NULL,
	[Category] [nvarchar](100) NULL,
	[Source] [nvarchar](100) NULL,
	[LogIndex] [bigint] IDENTITY(1,1) NOT NULL,
	[LogType] [smallint] NULL,
	[LogMessage] [nvarchar](2000) NULL,
	[LogTime] [datetime] NULL,
 CONSTRAINT [PK_T_Log_List1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[T_Log_Detail]    Script Date: 06/29/2010 08:51:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_Log_Detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[T_Log_Detail](
	[Id] [uniqueidentifier] NOT NULL,
	[LogDetail] [nvarchar](max) NULL,
 CONSTRAINT [PK_T_Log_Detail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
