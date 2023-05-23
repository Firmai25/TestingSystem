USE [master]
GO
/****** Object:  Database [Cherepanov_Testing]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Answer]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Parameters_Question]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Parameters_Test]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Question]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Question_Answer]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Rating]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Test]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Type_question]    Script Date: 24.05.2023 0:38:53 ******/
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
/****** Object:  Table [dbo].[Type_Teacher]    Script Date: 24.05.2023 0:38:53 ******/
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

INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (519, N'Ньютон', 0, 133)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (520, N'Паскаль', 1, 133)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (521, N'Ампер', 0, 133)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (522, N'Марс', 0, 134)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (523, N'Венера', 0, 134)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (524, N'Меркурий', 1, 134)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (525, N'Земля', 0, 134)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (526, N'Что делает биссектриса треугольника?', 1, 135)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (527, N'Делит противоположную сторону на два равных отрезка', 0, 135)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (528, N'Делит треугольник на две фигуры с одинаковой площадью', 0, 135)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (529, N'Сергей Есенин', 1, 136)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (530, N'Александр Блок', 0, 136)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (531, N'Александр Пушкин', 0, 136)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (532, N'23 пары', 1, 137)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (533, N'22 пары', 0, 137)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (534, N'24 пары', 0, 137)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (535, N'Атлантический, Индийский', 1, 138)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (536, N'Тихий, Индийский', 0, 138)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (537, N'Тихий, Атлантический', 0, 138)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (538, N'NaHCO', 1, 139)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (539, N'NaCl', 0, 139)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (540, N'CaOH', 0, 139)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (541, N'Сергей Трубецкой', 1, 140)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (542, N'Михаил Сперанский', 0, 140)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (543, N'Павел Пестель', 0, 140)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (544, N'Формой морды: у крокодила она длинная и узкая, а у аллигатора широкая и сплющенная', 1, 141)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (545, N'Размерами: аллигаторы в длину достигают до 3 метров, крокодилы - до 5 метров', 0, 141)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (546, N'У аллигаторов видны зубы, если сомкнута челюсть', 0, 141)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (547, N'Сталинградская битва
', 0, 142)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (548, N'Сражение под Прохоровкой', 1, 142)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (549, N'Смоленское сражение', 0, 142)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (554, N'Байт', 0, 144)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (555, N'Каталог', 1, 144)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (556, N'Диск', 0, 144)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (557, N'Для хранения часто изменяющейся информации в процессе решения задачи', 0, 145)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (558, N'Для долговременного хранения информации после выключения компьютера', 1, 145)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (559, N'Для постоянного хранения информации о работе компьютера', 0, 145)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (560, N'Некоторые истинные высказывания, которые должны быть направлены на достижение поставленной цели', 0, 146)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (561, N'Отражение предметного мира с помощью знаков и сигналов, предназначенное для конкретного исполнителя', 0, 146)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (562, N'Понятное и точное предписание исполнителю совершить последовательность действий, направленных на решение поставленной задачи или цели', 1, 146)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (563, N'Проводник', 1, 147)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (564, N'WinRar', 0, 147)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (565, N'WinZip', 0, 147)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (566, N'восточная Азия', 0, 148)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (567, N'Западная Европа', 0, 148)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (568, N'Восточно-Европейская равнина', 1, 148)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (569, N'Прибалтика', 0, 148)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (570, N'погосты', 1, 149)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (571, N'остроги', 0, 149)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (572, N'пашни', 0, 149)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (573, N'пороги', 0, 149)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (574, N'снижению авторитета русской церкви', 0, 150)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (575, N'активизации волжской торговли', 0, 150)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (576, N'возвышению Москвы', 0, 150)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (577, N'усилению раздробленности', 1, 150)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (578, N'Святослав', 0, 151)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (579, N'Владимир Святославич', 0, 151)
INSERT [dbo].[Answer] ([Id], [Text_Answer], [Correct], [IdQuestion]) VALUES (580, N'Ярослав Мудрый', 1, 151)
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Parameters_Test] ON 

INSERT [dbo].[Parameters_Test] ([Id], [Id_Test], [Sequence], [AbilityReturn], [TimeLimit]) VALUES (97, 98, 1, 1, NULL)
INSERT [dbo].[Parameters_Test] ([Id], [Id_Test], [Sequence], [AbilityReturn], [TimeLimit]) VALUES (98, 99, 1, 1, NULL)
INSERT [dbo].[Parameters_Test] ([Id], [Id_Test], [Sequence], [AbilityReturn], [TimeLimit]) VALUES (100, 101, 1, 1, NULL)
INSERT [dbo].[Parameters_Test] ([Id], [Id_Test], [Sequence], [AbilityReturn], [TimeLimit]) VALUES (101, 102, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Parameters_Test] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (133, 98, N'Укажите единицу измерения атмосферного давления', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (134, 98, N'Самая жаркая планета, которая находится ближе всего по отношению к Солнцу.', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (135, 98, N'Что делает биссектриса треугольника?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (136, 98, N'Кто автор строк: «Отговорила роща золотая березовым, веселым языком, и журавли, печально пролетая, уж не жалеют больше ни о ком.»?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (137, 98, N'Сколько пар хромосом включает геном человека?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (138, 99, N'Какие океаны омывают побережье Африки?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (139, 99, N'Выберете правильную химическую формулу пищевой соды.', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (140, 99, N'Кто возглавил восстание декабристов, которое состоялось в Санкт-Петербурге в 1825 году?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (141, 99, N'Чем отличаются крокодилы от аллигаторов?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (142, 99, N'В 1943 году состоялось масштабное танковое сражение Второй мировой войны, которое получило название ...', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (144, 101, N'Как называется группа файлов, которая хранится отдельной группой и имеет собственное имя ?', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (145, 101, N'Внешняя память необходима для', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (146, 101, N'Алгоритм — это', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (147, 101, N'Какие программные продукты можно использовать для выполнения следующих типовых файловых операций (создания папок, копирования файлов и папок; перемещения файлов и папок; удаления файлов)', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (148, 102, N'Территория расселения восточных славян...', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (149, 102, N'Места сбора дани, установленные согласно государственной реформе княгини Ольги, назывались...', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (150, 102, N'В середине XIII в. установление на Руси монгольского ига привело к...', 1)
INSERT [dbo].[Question] ([Id], [Id_Test], [Text_question], [id_type]) VALUES (151, 102, N'Назовите имя исторического деятеля, о котором идет речь в тексте: «Князь много сделал для распространения христианства на Руси. Он строил новые церкви (в том числе выдающиеся соборы святой Софии в Киеве и Новгороде), открывал при них школы, поощрял перевод церковных книг с греческого языка на славянский.»', 1)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Rating] ON 

INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (41, N'Черепанов', N'Денис', N'Васильевич', 3, 6, 102)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (42, N'Черепанов', N'Денис', N'Васильевич', 3, 9, 101)
INSERT [dbo].[Rating] ([Id], [Surname], [Name], [Patronymic], [Scores], [NumberClass], [Id_Test]) VALUES (43, N'Черепанов', N'Денис', N'Васильевич', 2, 9, 98)
SET IDENTITY_INSERT [dbo].[Rating] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (1, N'Тест', N'без', N'автора', N'Firmai', N'123', 2)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (2, N'Черепанов', N'Денис', N'Васильевич', N'AdminFir', N'123', 1)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (11, N'Хафизов', N'Валерий', N'Русланович', N'hafiz', N'123', 2)
INSERT [dbo].[Teacher] ([Id], [Surname], [Name], [Patronymic], [Login], [Password], [Id_Type]) VALUES (12, N'Бажин', N'Алексей', N'Анатольевич', N'baj', N'123', 2)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Test] ON 

INSERT [dbo].[Test] ([Id], [Name], [id_Teacher], [Description], [VisibleTest], [DateCreate], [DateEdit]) VALUES (98, N'Тест для всезнаек', 1, N'Тест для всезнаек «20 вопросов из школьной программы» некоторым может показаться сложным, а другие справятся с ним, то что называется «на ура». Попробуйте свои силы! ', 1, CAST(N'2023-05-22T20:55:26.107' AS DateTime), CAST(N'2023-05-22T20:58:46.427' AS DateTime))
INSERT [dbo].[Test] ([Id], [Name], [id_Teacher], [Description], [VisibleTest], [DateCreate], [DateEdit]) VALUES (99, N'Тест для всезнаек часть 2', 1, N'Вторая часть теста для всезнаек', 1, CAST(N'2023-05-22T21:03:02.657' AS DateTime), CAST(N'2023-05-22T21:05:44.830' AS DateTime))
INSERT [dbo].[Test] ([Id], [Name], [id_Teacher], [Description], [VisibleTest], [DateCreate], [DateEdit]) VALUES (101, N'Тест по информатике 9 класс', 11, N'', 1, CAST(N'2023-05-23T16:12:58.190' AS DateTime), CAST(N'2023-05-23T16:15:13.003' AS DateTime))
INSERT [dbo].[Test] ([Id], [Name], [id_Teacher], [Description], [VisibleTest], [DateCreate], [DateEdit]) VALUES (102, N'Итоговый контроль по истории 6 класс', 12, N'', 1, CAST(N'2023-05-23T16:19:03.050' AS DateTime), CAST(N'2023-05-23T16:21:02.300' AS DateTime))
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
