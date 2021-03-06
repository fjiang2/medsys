USE [medsys]
GO
/****** Object:  Table [dbo].[X12SegmentTemplate]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12SegmentTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Description] [varchar](250) NULL,
	[Purpose] [varchar](1000) NOT NULL,
	[Notes] [varchar](4000) NOT NULL,
	[Syntax] [varchar](4000) NULL,
	[Script] [ntext] NULL,
 CONSTRAINT [PK_X12Segment1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[X12SegmentInstance]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12SegmentInstance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoopName] [varchar](8) NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Sequence] [int] NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[RepeatValue] [int] NOT NULL,
	[Required] [bit] NOT NULL,
	[Situational_Rule] [varchar](4000) NULL,
	[TR3_Notes] [varchar](4000) NULL,
	[TR3_Example] [varchar](1000) NULL,
	[Script] [ntext] NULL,
 CONSTRAINT [PK_SpecSegment] PRIMARY KEY CLUSTERED 
(
	[LoopName] ASC,
	[Name] ASC,
	[Sequence] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[X12LoopTemplate]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12LoopTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[Name] [varchar](10) NOT NULL,
	[Sequence] [int] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[MinRepeat] [int] NOT NULL,
	[MaxRepeat] [int] NOT NULL,
	[Required] [bit] NOT NULL,
	[Script] [ntext] NULL,
 CONSTRAINT [PK_LoopSpec] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[X12ElementTemplate]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12ElementTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SegmentName] [varchar](8) NOT NULL,
	[RefDes] [varchar](8) NOT NULL,
	[DeNum] [varchar](10) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Condition] [char](1) NOT NULL,
	[RepeatValue] [int] NOT NULL,
	[DataType] [varchar](10) NOT NULL,
	[MinLength] [int] NOT NULL,
	[MaxLength] [int] NOT NULL,
	[Script] [ntext] NULL,
 CONSTRAINT [PK_ElementDetail] PRIMARY KEY CLUSTERED 
(
	[RefDes] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[X12ElementInstance]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12ElementInstance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ElementTemplate_ID] [int] NOT NULL,
	[SegmentInstance_ID] [int] NOT NULL,
	[Usage] [int] NOT NULL,
	[Description] [varchar](4000) NULL,
	[Situational_Rule] [varchar](4000) NULL,
	[Code_Definition] [int] NOT NULL,
	[Script] [ntext] NULL,
 CONSTRAINT [PK_X12Element2] PRIMARY KEY CLUSTERED 
(
	[ElementTemplate_ID] ASC,
	[SegmentInstance_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[X12CodeDefinition]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[X12CodeDefinition](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ElementInstance_ID] [int] NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Definition] [varchar](500) NOT NULL,
 CONSTRAINT [PK_X12CodeDefinition] PRIMARY KEY CLUSTERED 
(
	[ElementInstance_ID] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys01403]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys01403](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Table_Id] [int] NOT NULL,
	[Table_Name] [varchar](50) NULL,
	[Row_Id] [int] NOT NULL,
	[Label] [nvarchar](128) NULL,
	[File_Name] [varchar](50) NOT NULL,
	[Date_Created] [datetime] NOT NULL,
	[Owner] [int] NULL,
 CONSTRAINT [PK__sys01403__3214EC2771D1E811] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys01402]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys01402](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Doc_Id] [int] NOT NULL,
	[Label] [nvarchar](120) NULL,
	[Version] [int] NOT NULL,
	[Doc_Name] [varchar](50) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Date_Modified] [datetime] NOT NULL,
	[Comment] [nvarchar](256) NULL,
 CONSTRAINT [PK__sys01402__06B27BD26A30C649] PRIMARY KEY CLUSTERED 
(
	[Doc_Id] ASC,
	[Version] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys01401]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys01401](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[Table_Id] [int] NOT NULL,
	[Table_Name] [varchar](50) NULL,
	[Row_Id] [int] NOT NULL,
	[Label] [nvarchar](128) NULL,
	[File_Name] [varchar](100) NOT NULL,
	[File_Type] [varchar](50) NULL,
	[Owner] [int] NULL,
 CONSTRAINT [PK__sys01401__383906BC6E01572D] PRIMARY KEY CLUSTERED 
(
	[File_Name] ASC,
	[Row_Id] ASC,
	[Table_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys01308]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01308](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowInstance_ID] [int] NULL,
	[S1_Name] [nvarchar](50) NULL,
	[S2_Name] [nvarchar](50) NULL,
	[User_ID] [int] NULL,
	[Date_Created] [datetime] NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_wfNotes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01307]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01307](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkflowInstance_ID] [int] NOT NULL,
	[S1_Name] [nvarchar](50) NOT NULL,
	[S2_Name] [nvarchar](50) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Date_Created] [datetime] NOT NULL,
 CONSTRAINT [PK_wfTrack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01306]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01306](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ty] [int] NOT NULL,
	[ParentID] [int] NOT NULL,
	[ChildID] [int] NOT NULL,
 CONSTRAINT [PK_wfNodes] PRIMARY KEY CLUSTERED 
(
	[Ty] ASC,
	[ParentID] ASC,
	[ChildID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01305]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01305](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](50) NULL,
	[Summary] [nvarchar](128) NOT NULL,
	[Category1] [nvarchar](50) NULL,
	[Category2] [nvarchar](50) NULL,
	[Category3] [nvarchar](50) NULL,
	[Description] [nvarchar](2048) NULL,
	[Priority] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Submitted_Date] [datetime] NOT NULL,
	[Start_Date] [datetime] NULL,
	[Due_Date] [datetime] NULL,
	[Reminder_Date] [datetime] NULL,
	[Last_Action_Date] [datetime] NULL,
	[Work_Date] [datetime] NULL,
	[Complete_Date] [datetime] NULL,
	[Complete_Percentage] [float] NULL,
	[Time_Spent] [float] NULL,
	[Resolution] [nvarchar](2048) NULL,
	[Owner_ID] [int] NULL,
	[Sender_ID] [int] NOT NULL,
	[Unread] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[WorkflowInstance_ID] [int] NULL,
	[State_Name] [nvarchar](128) NULL,
	[Activity_Status] [int] NULL,
	[Prev_States] [nvarchar](512) NULL,
	[Next_States] [nvarchar](512) NULL,
	[Heap] [nvarchar](4000) NULL,
 CONSTRAINT [PK_xmppMessages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01304]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01304](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Workflow_Name] [nvarchar](50) NOT NULL,
	[Label] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Work_Date] [datetime] NULL,
	[Complete_Date] [datetime] NULL,
	[Heap] [ntext] NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_articipants] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01303]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01303](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Workflow_Name] [nvarchar](50) NOT NULL,
	[S1_Name] [nvarchar](50) NOT NULL,
	[S2_Name] [nvarchar](50) NOT NULL,
	[Directional] [bit] NOT NULL,
	[Expression] [nvarchar](512) NULL,
 CONSTRAINT [PK_wfTransitions_1] PRIMARY KEY CLUSTERED 
(
	[Workflow_Name] ASC,
	[S1_Name] ASC,
	[S2_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01302]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01302](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Workflow_Name] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Index] [int] NULL,
	[Label] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[Ty] [int] NOT NULL,
	[Offset] [float] NOT NULL,
	[Duration] [float] NOT NULL,
	[Metadata] [nvarchar](1024) NULL,
	[Dependency] [nvarchar](1024) NOT NULL,
	[Preaction] [nvarchar](1024) NULL,
	[Action] [nvarchar](1024) NOT NULL,
	[AfterAction] [nvarchar](1024) NULL,
	[Postaction] [nvarchar](1024) NULL,
	[Channel] [int] NOT NULL,
	[Agent] [nvarchar](1024) NULL,
 CONSTRAINT [PK_wfStates_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC,
	[Workflow_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01301]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01301](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Company] [nvarchar](50) NULL,
	[Label] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](1024) NULL,
	[Metadata] [ntext] NULL,
	[Released] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Date_Created] [datetime] NULL,
	[Creator] [int] NULL,
	[Date_Modified] [datetime] NULL,
	[Modifier] [int] NULL,
 CONSTRAINT [PK_wfWorkflows_1] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01201]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01201](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](50) NULL,
	[Friend_Name] [nvarchar](50) NULL,
	[Start_Time] [datetime] NULL,
	[End_Time] [datetime] NULL,
	[History] [ntext] NULL,
 CONSTRAINT [PK_logXmppChat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01103]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys01103](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Command_ID] [int] NOT NULL,
	[url] [nvarchar](50) NOT NULL,
	[repx] [ntext] NOT NULL,
 CONSTRAINT [PK_sys01103] PRIMARY KEY CLUSTERED 
(
	[Command_ID] ASC,
	[url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys01102]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys01102](
	[Module] [varchar](128) NOT NULL,
	[Library] [nvarchar](50) NOT NULL,
	[Script] [ntext] NOT NULL,
	[Notes] [nvarchar](256) NULL,
	[Released] [bit] NOT NULL,
 CONSTRAINT [PK_Scripts] PRIMARY KEY CLUSTERED 
(
	[Module] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys01101]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys01101](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[OrderBy] [int] NOT NULL,
	[Image_Index] [int] NOT NULL,
	[Ty] [int] NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Description] [text] NULL,
	[Header_Footer] [nvarchar](512) NOT NULL,
	[Data_Provider] [int] NOT NULL,
	[Sql_Command] [varchar](max) NOT NULL,
	[User_Layout] [nvarchar](4000) NOT NULL,
	[Setting_Script] [ntext] NOT NULL,
	[Access_Level] [int] NOT NULL,
	[Released] [bit] NOT NULL,
	[Controlled] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[ViewMode] [int] NOT NULL,
	[Owner_ID] [int] NOT NULL,
	[Help] [ntext] NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00901]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00901](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NULL,
	[Description] [nvarchar](512) NULL,
	[DataSource] [nvarchar](max) NULL,
	[ClassName] [nvarchar](256) NULL,
	[Mapping] [ntext] NULL,
	[ActionButtonName] [nvarchar](256) NULL,
 CONSTRAINT [PK_DataImport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00806]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00806](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ty] [int] NOT NULL,
	[Image_Index] [int] NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](128) NULL,
	[Picture] [image] NOT NULL,
 CONSTRAINT [PK_sys00806] PRIMARY KEY CLUSTERED 
(
	[Ty] ASC,
	[Image_Index] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00805]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00805](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](128) NULL,
	[Command] [nvarchar](128) NOT NULL,
	[Icon] [image] NULL,
	[OrderBy] [int] NULL,
 CONSTRAINT [PK__sys00805__3214EC27797309D9] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00804]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00804](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[OrderBy] [int] NULL,
	[Ty] [int] NOT NULL,
	[Company_ID] [int] NULL,
	[Application] [nvarchar](50) NULL,
	[Module] [varchar](128) NULL,
	[Label] [nvarchar](128) NULL,
	[Description] [nvarchar](512) NULL,
	[Key_Name] [nvarchar](128) NULL,
	[Command] [nvarchar](4000) NULL,
	[Icon] [image] NULL,
	[Controlled] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Released] [bit] NOT NULL,
	[Form_Class] [varchar](128) NULL,
	[Form_Place] [int] NULL,
 CONSTRAINT [PK__sys00804__3214EC277D439ABD] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00803]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00803](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ty] [int] NOT NULL,
	[Shortcut] [nvarchar](150) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](128) NULL,
	[Code] [nvarchar](256) NOT NULL,
	[Icon] [image] NULL,
	[Help] [ntext] NULL,
 CONSTRAINT [PK_sys00803] PRIMARY KEY CLUSTERED 
(
	[Shortcut] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00802]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00802](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Label] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](128) NULL,
	[Command] [nvarchar](128) NOT NULL,
	[Icon] [image] NULL,
	[OrderBy] [int] NULL,
 CONSTRAINT [PK_sys00802] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00801]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00801](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[OrderBy] [int] NULL,
	[Ty] [int] NOT NULL,
	[Module] [varchar](128) NULL,
	[Label] [nvarchar](128) NULL,
	[Description] [nvarchar](512) NULL,
	[Key_Name] [nvarchar](128) NULL,
	[Command] [nvarchar](4000) NULL,
	[Icon] [image] NULL,
	[Controlled] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Visible] [bit] NOT NULL,
	[Released] [bit] NOT NULL,
	[Form_Class] [varchar](128) NULL,
	[Form_Place] [int] NULL,
 CONSTRAINT [PK_UserMenus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00704]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00704](
	[handle] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[type] [int] NOT NULL,
	[connection] [nvarchar](250) NOT NULL,
	[user_id] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[inactive] [bit] NOT NULL,
 CONSTRAINT [PK_sys00704] PRIMARY KEY CLUSTERED 
(
	[handle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00703]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00703](
	[Version] [bigint] NOT NULL,
 CONSTRAINT [PK_sys00703] PRIMARY KEY CLUSTERED 
(
	[Version] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00702]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00702](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Form_Class] [nvarchar](128) NOT NULL,
	[Label] [nvarchar](100) NULL,
	[Description] [nvarchar](256) NULL,
	[Icon] [image] NULL,
	[Help] [ntext] NULL,
 CONSTRAINT [PK_sys00702] PRIMARY KEY CLUSTERED 
(
	[Form_Class] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00701]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00701](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssemblyName] [varchar](50) NOT NULL,
	[FullName] [varchar](2560) NULL,
	[Version] [varchar](50) NULL,
	[Label] [nvarchar](128) NULL,
	[DateInstalled] [datetime] NULL,
	[Inactive] [bit] NOT NULL,
	[Location] [varchar](50) NULL,
 CONSTRAINT [PK_sys00701] PRIMARY KEY CLUSTERED 
(
	[AssemblyName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00601]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00601](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ty] [int] NOT NULL,
	[LockID] [int] NOT NULL,
	[CO_User_ID] [int] NOT NULL,
	[CO_Time] [datetime] NOT NULL,
	[CI_User_ID] [int] NULL,
	[CI_Time] [datetime] NULL,
	[Last_Access_Time] [datetime] NOT NULL,
 CONSTRAINT [PK_wfCO] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00505]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00505](
	[User_ID] [int] NOT NULL,
	[Setting] [text] NULL,
	[Configuration] [text] NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00504]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00504](
	[Comany_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address_ID] [nchar](10) NULL,
	[Inactive] [bit] NOT NULL,
	[Default_DB] [varchar](50) NULL,
 CONSTRAINT [PK_sys00504] PRIMARY KEY CLUSTERED 
(
	[Comany_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00503]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00503](
	[Role_ID] [int] NOT NULL,
	[Ty] [int] NULL,
	[Key_Name] [nvarchar](128) NOT NULL,
	[Value] [ntext] NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC,
	[Key_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00502]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00502](
	[Role_ID] [int] NOT NULL,
	[Ty] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[Enabled] [bit] NULL,
	[Visible] [bit] NULL,
 CONSTRAINT [PK_IPermissions] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC,
	[Ty] ASC,
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00501]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00501](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[Label] [nvarchar](50) NULL,
	[OrderBy] [int] NULL,
	[key_name] [nvarchar](50) NOT NULL,
	[value] [nvarchar](512) NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_Configuration] PRIMARY KEY CLUSTERED 
(
	[key_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00403]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00403](
	[FormClass] [nvarchar](256) NOT NULL,
	[Script] [ntext] NULL,
	[Released] [bit] NOT NULL,
 CONSTRAINT [PK_wfFormRules] PRIMARY KEY CLUSTERED 
(
	[FormClass] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00402]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00402](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Error_Code] [int] NOT NULL,
	[WorkflowInstance_ID] [int] NULL,
	[Reason] [nvarchar](512) NULL,
	[Date_Created] [datetime] NULL,
	[Creator] [int] NULL,
	[Date_Modified] [datetime] NULL,
	[Modifier] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00401]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00401](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Error_Code] [int] NOT NULL,
	[OrderBy] [int] NULL,
	[Workflow_Name] [nvarchar](128) NOT NULL,
	[State_Name] [nvarchar](128) NULL,
	[Label] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](512) NULL,
	[Turned_Off_Ind] [bit] NOT NULL,
	[Rule_Direct_Ind] [bit] NULL,
	[Antecedent] [nvarchar](2024) NULL,
	[Consequent] [nvarchar](2024) NULL,
	[Severity_Level] [int] NULL,
	[Trace_Key] [nvarchar](128) NULL,
	[Message] [nvarchar](2024) NULL,
	[Business_Rule] [nvarchar](4000) NOT NULL,
	[Specification] [nvarchar](4000) NULL,
	[Comment] [nvarchar](4000) NULL,
	[Released] [bit] NOT NULL,
	[Date_Created] [datetime] NULL,
	[Creator] [int] NULL,
	[Date_Modified] [datetime] NULL,
	[Modifier] [int] NULL,
 CONSTRAINT [PK_wfRules_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00305]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00305](
	[class_id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[path] [nvarchar](250) NOT NULL,
	[name_space] [varchar](150) NOT NULL,
	[modifier] [int] NOT NULL,
	[class_name] [varchar](50) NOT NULL,
	[table_level] [int] NOT NULL,
	[packed] [bit] NOT NULL,
	[has_provider] [bit] NOT NULL,
 CONSTRAINT [PK_sys00305] PRIMARY KEY CLUSTERED 
(
	[table_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00304]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00304](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](20) NOT NULL,
	[Application_Name] [varchar](50) NOT NULL,
	[Computer_Name] [varchar](15) NOT NULL,
	[DateEntered] [datetime] NOT NULL,
	[Version] [varchar](10) NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[User_Name] ASC,
	[Application_Name] ASC,
	[Computer_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00303]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00303](
	[log_column_id] [int] IDENTITY(1,1) NOT NULL,
	[log_table_id] [int] NOT NULL,
	[table_name] [varchar](80) NULL,
	[column_name] [varchar](50) NULL,
	[column_id] [int] NOT NULL,
	[data_type] [varchar](50) NOT NULL,
	[value_from] [ntext] NOT NULL,
	[value_to] [ntext] NOT NULL,
 CONSTRAINT [PK_logColumns] PRIMARY KEY CLUSTERED 
(
	[log_column_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00302]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00302](
	[log_table_id] [int] IDENTITY(1,1) NOT NULL,
	[log_dataset_id] [int] NOT NULL,
	[table_id] [int] NOT NULL,
	[table_name] [varchar](50) NULL,
	[row_id] [int] NOT NULL,
	[operation] [int] NOT NULL,
	[action] [varchar](10) NULL,
	[value_from] [ntext] NULL,
	[value_to] [ntext] NULL,
 CONSTRAINT [PK_logTables] PRIMARY KEY CLUSTERED 
(
	[log_table_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00301]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00301](
	[log_dataset_id] [int] IDENTITY(1,1) NOT NULL,
	[form_name] [varchar](128) NOT NULL,
	[date] [datetime] NOT NULL,
	[user_id] [int] NOT NULL,
	[machine_name] [varchar](128) NULL,
 CONSTRAINT [PK_logTransactions] PRIMARY KEY CLUSTERED 
(
	[form_name] ASC,
	[date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00204]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00204](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[Feature] [varchar](50) NOT NULL,
	[Value] [int] NOT NULL,
	[Label] [nvarchar](100) NULL,
 CONSTRAINT [PK_app00001] PRIMARY KEY CLUSTERED 
(
	[Category] ASC,
	[Feature] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00203]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00203](
	[column_id] [int] IDENTITY(1,1) NOT NULL,
	[table_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[label] [nvarchar](50) NULL,
	[description] [nvarchar](128) NULL,
	[version] [int] NOT NULL,
 CONSTRAINT [PK_dictTableColumns] PRIMARY KEY CLUSTERED 
(
	[table_id] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00202]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00202](
	[table_id] [int] IDENTITY(1,1) NOT NULL,
	[database_id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[label] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
	[enabled] [bit] NOT NULL,
	[version] [int] NOT NULL,
 CONSTRAINT [PK_dictTables] PRIMARY KEY CLUSTERED 
(
	[database_id] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00201]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00201](
	[database_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[provider_id] [int] NOT NULL,
	[label] [nvarchar](50) NULL,
	[description] [nvarchar](128) NULL,
	[enabled] [bit] NOT NULL,
	[version] [int] NOT NULL,
 CONSTRAINT [PK_sys00201] PRIMARY KEY CLUSTERED 
(
	[name] ASC,
	[provider_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sys00103]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00103](
	[UR_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Role_ID] [int] NOT NULL,
	[Description] [nvarchar](128) NULL,
	[Date_Activated] [datetime] NULL,
	[Date_Expired] [datetime] NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC,
	[Role_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00102]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sys00102](
	[Role_ID] [int] NOT NULL,
	[Role_Name] [nvarchar](256) NOT NULL,
	[Parent_Role_ID] [int] NULL,
	[Description] [nvarchar](1024) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sys00101]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sys00101](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [nvarchar](256) NOT NULL,
	[Plain_Password] [nvarchar](32) NULL,
	[Password] [varbinary](64) NULL,
	[Windows_Authentication] [bit] NOT NULL,
	[Inactive] [bit] NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Middle_Name] [nvarchar](50) NULL,
	[Nickname] [nvarchar](50) NULL,
	[Group_Name] [nvarchar](64) NOT NULL,
	[Department] [nvarchar](50) NOT NULL,
	[Job_Title] [nvarchar](50) NOT NULL,
	[Supervisor] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](64) NOT NULL,
	[WorkPhone] [varchar](16) NOT NULL,
	[WorkFax] [varchar](16) NULL,
	[WorkPager] [varchar](16) NULL,
	[WorkMobile] [varchar](16) NULL,
	[Signature] [image] NULL,
	[Avatar] [image] NULL,
	[Password_Changed_DT] [datetime] NULL,
	[Logon_Locked_DT] [datetime] NULL,
	[Start_Date] [datetime] NOT NULL,
	[End_Date] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_UNIQUE_Users_Username] UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_Users_Username] UNIQUE NONCLUSTERED 
(
	[User_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[ResourceID] [int] NOT NULL,
	[ResourceName] [nvarchar](50) NULL,
	[Color] [int] NULL,
	[Image] [image] NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ptaStudents]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ptaStudents](
	[Student_ID] [int] NOT NULL,
	[Address_ID] [int] NULL,
	[Phone_ID] [int] NULL,
	[Grade] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ptaStudents] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ptaAdults]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ptaAdults](
	[Adult_ID] [int] NOT NULL,
	[Address_ID] [int] NOT NULL,
	[Home_Phone_ID] [int] NOT NULL,
	[Work_Phone_ID] [int] NULL,
	[Email] [varchar](60) NULL,
	[Profession] [nvarchar](150) NULL,
	[Day] [bit] NOT NULL,
	[Night] [bit] NOT NULL,
	[Weekend] [bit] NOT NULL,
	[Arts] [bit] NOT NULL,
	[Chess] [bit] NOT NULL,
	[Classroom] [bit] NOT NULL,
	[Construction] [bit] NOT NULL,
	[Crawfish] [bit] NOT NULL,
	[Writing] [bit] NOT NULL,
	[Fundraising] [bit] NOT NULL,
	[Events] [bit] NOT NULL,
	[Landscaping] [bit] NOT NULL,
	[Gardening] [bit] NOT NULL,
	[Library] [bit] NOT NULL,
	[Lice] [bit] NOT NULL,
	[Lunch] [bit] NOT NULL,
	[Letter] [bit] NOT NULL,
	[Office] [bit] NOT NULL,
	[Traffic] [bit] NOT NULL,
	[Registration] [bit] NOT NULL,
	[Nurse] [bit] NOT NULL,
	[Soiree] [bit] NOT NULL,
	[Auction] [bit] NOT NULL,
	[Technology] [bit] NOT NULL,
	[Tutoring] [bit] NOT NULL,
	[Committee] [bit] NOT NULL,
	[Other] [nvarchar](120) NULL,
 CONSTRAINT [PK_ptaInterests] PRIMARY KEY CLUSTERED 
(
	[Adult_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[StartDate] [smalldatetime] NOT NULL,
	[EndDate] [smalldatetime] NOT NULL,
	[AllDay] [bit] NOT NULL,
	[Subject] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Label] [int] NULL,
	[ResourceID] [int] NOT NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[CustomField1] [nvarchar](max) NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[app00203]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app00203](
	[Job_ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Dept_ID] [int] NULL,
 CONSTRAINT [PK__theJobTi__E76A768657DD0BE4] PRIMARY KEY CLUSTERED 
(
	[Job_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[app00202]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app00202](
	[Dept_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Label] [nvarchar](50) NULL,
	[Description] [nvarchar](128) NULL,
	[Manager_ID] [int] NULL,
 CONSTRAINT [PK__theDepar__737584F75F7E2DAC] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[app00201]    Script Date: 05/14/2013 22:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app00201](
	[Emp_ID] [int] IDENTITY(1,1) NOT NULL,
	[Badge] [nvarchar](50) NOT NULL,
	[Person_ID] [int] NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Job_Title_ID] [int] NOT NULL,
	[Manager_ID] [int] NOT NULL,
	[Department_ID] [int] NOT NULL,
	[Address_ID] [int] NOT NULL,
	[Work_Phone_ID] [int] NOT NULL,
	[Home_Phone_ID] [int] NULL,
	[First_Day_Worked] [datetime] NOT NULL,
	[Last_Day_Worked] [datetime] NULL,
	[Benefit_Expired_Date] [datetime] NULL,
	[Veteran] [bit] NOT NULL,
	[Vietnam_Veteran] [bit] NOT NULL,
	[Disable_Veteran] [bit] NOT NULL,
	[Handicapped] [bit] NOT NULL,
	[Union_Employee] [bit] NULL,
	[Smoker] [bit] NOT NULL,
	[Verified] [bit] NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_theEmployee] PRIMARY KEY CLUSTERED 
(
	[Badge] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[app00104]    Script Date: 05/14/2013 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[app00104](
	[Phone_ID] [int] NOT NULL,
	[Phone] [varchar](16) NOT NULL,
	[Mobile] [varchar](16) NULL,
	[Fax] [varchar](16) NULL,
	[Pager] [varchar](16) NULL,
 CONSTRAINT [PK_app00104] PRIMARY KEY CLUSTERED 
(
	[Phone_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[app00103]    Script Date: 05/14/2013 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app00103](
	[Person_ID1] [int] NOT NULL,
	[Person_ID2] [int] NOT NULL,
	[Relationship_Enum] [int] NOT NULL,
 CONSTRAINT [PK_app00103] PRIMARY KEY CLUSTERED 
(
	[Person_ID1] ASC,
	[Person_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[app00102]    Script Date: 05/14/2013 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[app00102](
	[Address_ID] [int] IDENTITY(1,1) NOT NULL,
	[Address_Enum] [int] NOT NULL,
	[Street_Number] [int] NULL,
	[Street_Name] [nvarchar](150) NULL,
	[Apartment] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Postal_Code] [varchar](12) NULL,
	[Country_Code] [nvarchar](50) NULL,
	[Country_Sub_Code] [nvarchar](20) NULL,
 CONSTRAINT [PK_app00102] PRIMARY KEY CLUSTERED 
(
	[Address_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[app00101]    Script Date: 05/14/2013 22:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[app00101](
	[Person_ID] [int] IDENTITY(1,1) NOT NULL,
	[SSN] [nvarchar](10) NULL,
	[First_Name] [nvarchar](50) NOT NULL,
	[Last_Name] [nvarchar](50) NOT NULL,
	[Middle_Name] [nvarchar](50) NULL,
	[Nick_Name] [nvarchar](50) NULL,
	[Prefix_Name] [nvarchar](50) NULL,
	[Suffix_Name] [nvarchar](50) NULL,
	[Gender_Enum] [int] NULL,
	[Birthday] [datetime] NULL,
	[MaritalStatus_Enum] [int] NULL,
	[Citizen] [bit] NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_app00101] PRIMARY KEY CLUSTERED 
(
	[Person_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
