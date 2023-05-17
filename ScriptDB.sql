USE [master]
GO
/****** Object:  Database [Cherepanov_Testing]    Script Date: 18.05.2023 0:46:35 ******/
CREATE DATABASE [Cherepanov_Testing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cherepanov_Testing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cherepanov_Testing.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cherepanov_Testing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cherepanov_Testing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cherepanov_Testing] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cherepanov_Testing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cherepanov_Testing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cherepanov_Testing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cherepanov_Testing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cherepanov_Testing] SET  MULTI_USER 
GO
ALTER DATABASE [Cherepanov_Testing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cherepanov_Testing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cherepanov_Testing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cherepanov_Testing] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cherepanov_Testing] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cherepanov_Testing] SET QUERY_STORE = OFF
GO
USE [Cherepanov_Testing]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text_Answer] [nvarchar](max) NULL,
	[Correct] [int] NULL,
	[IdQuestion] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parameters_Question]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters_Question](
	[Id] [int] NOT NULL,
	[Id_question] [int] NULL,
 CONSTRAINT [PK_Parameters_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parameters_Test]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters_Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Test] [int] NULL,
	[Sequence] [bit] NULL,
	[AbilityReturn] [bit] NULL,
	[TimeLimit] [int] NULL,
 CONSTRAINT [PK_Parameters_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Test] [int] NULL,
	[Text_question] [nvarchar](max) NULL,
	[id_type] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Answer]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_question] [int] NULL,
	[Id_Answer] [int] NULL,
 CONSTRAINT [PK_Question_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	[Scores] [float] NULL,
	[NumberClass] [int] NULL,
	[Id_Test] [int] NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Id_Type] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[id_Teacher] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[VisibleTest] [bit] NULL,
	[DateCreate] [datetime] NULL,
	[DateEdit] [datetime] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_question]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Type_question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_Teacher]    Script Date: 18.05.2023 0:46:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Type_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (345, N'Тверь', 1, 92)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (346, N'Казань', 0, 92)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (347, N'Суздаль', 0, 92)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (348, N'Вена', 0, 92)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (349, N'Салах''аддин', 1, 93)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (350, N'Альму''али', 0, 93)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (351, N'Мухамед''али', 0, 93)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (352, N'Ибрагим', 0, 93)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (353, N'Последний викинг', 1, 94)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (354, N'Шведский Александр Македонский', 1, 94)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (355, N'Бескостный', 0, 94)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (356, N'Железнобокий', 0, 94)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Parameters_Test] ON 

INSERT [dbo].[Parameters_Test] ([Id], [Id_Test], [Sequence], [AbilityReturn], [TimeLimit]) VALUES (52, 53, 0, 0, 6)
SET IDENTITY_INSERT [dbo].[Parameters_Test] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (92, 53, N'Главный противник Москвы во время Татаро-Монгольского ига', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (93, 53, N'Главный противник Ричарда "Львиное сердце"', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (94, 53, N'Какие прозвища были у Карла XII', 2)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (1, N'Черепанов', N'Денис', N'Васильевич', NULL, 6, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (2, N'Черепанов', N'Денис', N'Васильевич', NULL, 7, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (3, N'Черепанов', N'Денис', N'Васильевич', NULL, 7, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (4, N'f', N'fgf', N'ff', NULL, 4, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (5, N'hh', N'ghj', N'hjghj', NULL, 5, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (6, N'gf', N'hfgh', N'fghf', NULL, 4, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (7, N'fff', N'gfff', N'gdgdf', 0, 2, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (8, N'Черепанов', N'ДенисВ', N'Васильевич', 0, 8, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (9, N'Черепанов', N'Дени ', N'Васильевич', 0, 8, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (10, N'Черепанов', N'Денис', N'Васильевич', 2.5, 7, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (11, N'ytrhf', N'fgg', N'fgf', 0, 6, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (14, N'Черепанов', N'Денис', N'Васильевич', 0, 7, 53)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (24, N'gf', N'fgh', N'fgh', 3, 10, 53)
SET IDENTITY_INSERT [dbo].[Rating] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (1, N'Черепанов', N'Денис', N'Васильевич', N'Firmai', N'123', 2)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (2, N'Админ', N'Админ', N'Админ', N'AdminFir', N'123', 1)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (8, N'Клоун', N'Авторский', N'Вич', N'login', N'password', 2)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (9, N'Кира', N'Йошикаге', N'Вич', N'рес', N'123', 1)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([Id], [Name], [id_Teacher], [Description], [VisibleTest], [DateCreate], [DateEdit]) VALUES (53, N'Тест по истории1', 1, N'Тест на поверхностные знания о мировой истории', 1, NULL, CAST(N'2023-05-17T23:15:06.817' AS DateTime))
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
SET IDENTITY_INSERT [dbo].[Type_question] ON 

INSERT [dbo].[Type_question] ([Id], [name]) VALUES (1, N'Вопрос с одним ответом')
INSERT [dbo].[Type_question] ([Id], [name]) VALUES (2, N'Вопрос с несколькими ответами')
SET IDENTITY_INSERT [dbo].[Type_question] OFF
GO
SET IDENTITY_INSERT [dbo].[Type_Teacher] ON 

INSERT [dbo].[Type_Teacher] ([Id], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Type_Teacher] ([Id], [Name]) VALUES (2, N'Учитель')
SET IDENTITY_INSERT [dbo].[Type_Teacher] OFF
GO
ALTER TABLE [dbo].[Answer]  WITH CHECK ADD  CONSTRAINT [FK_Answer_Question1] FOREIGN KEY([IdQuestion])
REFERENCES [dbo].[Question] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answer] CHECK CONSTRAINT [FK_Answer_Question1]
GO
ALTER TABLE [dbo].[Parameters_Question]  WITH CHECK ADD  CONSTRAINT [FK_Parameters_Question_Question1] FOREIGN KEY([Id_question])
REFERENCES [dbo].[Question] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameters_Question] CHECK CONSTRAINT [FK_Parameters_Question_Question1]
GO
ALTER TABLE [dbo].[Parameters_Test]  WITH CHECK ADD  CONSTRAINT [FK_Parameters_Test_Test1] FOREIGN KEY([Id_Test])
REFERENCES [dbo].[Test] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Parameters_Test] CHECK CONSTRAINT [FK_Parameters_Test_Test1]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Test1] FOREIGN KEY([Id_Test])
REFERENCES [dbo].[Test] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Test1]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Type_question1] FOREIGN KEY([id_type])
REFERENCES [dbo].[Type_question] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Type_question1]
GO
ALTER TABLE [dbo].[Question_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer_Answer] FOREIGN KEY([Id_Answer])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[Question_Answer] CHECK CONSTRAINT [FK_Question_Answer_Answer]
GO
ALTER TABLE [dbo].[Question_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer_Question] FOREIGN KEY([Id_question])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Question_Answer] CHECK CONSTRAINT [FK_Question_Answer_Question]
GO
ALTER TABLE [dbo].[Rating]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Test1] FOREIGN KEY([Id_Test])
REFERENCES [dbo].[Test] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rating] CHECK CONSTRAINT [FK_Rating_Test1]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Type_Teacher] FOREIGN KEY([Id_Type])
REFERENCES [dbo].[Type_Teacher] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Type_Teacher]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Teacher] FOREIGN KEY([id_Teacher])
REFERENCES [dbo].[Teacher] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Teacher]
GO
USE [master]
GO
ALTER DATABASE [Cherepanov_Testing] SET  READ_WRITE 
GO
