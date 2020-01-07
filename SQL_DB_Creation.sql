USE [master]
GO
/****** Object:  Database [ARM_Of_Phone_Seller]    Script Date: 17.12.2019 15:00:45 ******/
CREATE DATABASE [ARM_Of_Phone_Seller]
 CONTAINMENT = NONE
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARM_Of_Phone_Seller].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET  MULTI_USER 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET QUERY_STORE = OFF
GO
USE [ARM_Of_Phone_Seller]
GO
/****** Object:  Table [dbo].[Товар]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товар](
	[ID_Модели] [int] IDENTITY(1,1) NOT NULL,
	[Название_модели] [nvarchar](max) NOT NULL,
	[IMEI] [nvarchar](max) NULL,
	[Срок_гарантии] [real] NOT NULL,
	[Стоимость] [real] NOT NULL,
	[Номер_сертификата] [nvarchar](max) NULL,
	[Год_выпуска_модели] [date] NULL,
 CONSTRAINT [PK_Товар_1] PRIMARY KEY CLUSTERED 
(
	[ID_Модели] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Продажа]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Продажа](
	[Номер_договора] [int] IDENTITY(1,1) NOT NULL,
	[Дата_заключения_договора] [date] NOT NULL,
	[Срок_действия_договора] [real] NOT NULL,
	[Окончание_гарантийного_срока] [date] NOT NULL,
	[Дата_продажи] [date] NOT NULL,
	[Процент_НДС] [real] NOT NULL,
	[Стоимость_постгарантийного_обсуживания] [real] NOT NULL,
	[Сумма_продажи] [real] NOT NULL,
	[ID_Специалиста] [int] NOT NULL,
	[ID_Клиента] [int] NOT NULL,
	[ID_Модели] [int] NOT NULL,
 CONSTRAINT [PK_Продажа] PRIMARY KEY CLUSTERED 
(
	[Номер_договора] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Специалист]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Специалист](
	[ID_Специалиста] [int] IDENTITY(1,1) NOT NULL,
	[Логин] [nvarchar](50) NOT NULL,
	[Пароль] [nvarchar](50) NOT NULL,
	[Телефон] [bigint] NOT NULL,
	[Статус] [nvarchar](max) NOT NULL,
	[Фамилия] [nvarchar](50) NOT NULL,
	[Имя] [nvarchar](50) NOT NULL,
	[Отчество] [nvarchar](50) NULL,
	[Дата_рождения] [date] NOT NULL,
	[Основание_работы] [nvarchar](max) NOT NULL,
	[Администратор] [bit] NOT NULL,
 CONSTRAINT [PK_Специалист] PRIMARY KEY CLUSTERED 
(
	[ID_Специалиста] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Журнал продаж]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Журнал продаж]
AS
SELECT dbo.Продажа.Дата_продажи AS [Дата продажи], dbo.Специалист.Фамилия, dbo.Специалист.Имя, dbo.Товар.Название_модели AS [Название модели], dbo.Продажа.Сумма_продажи AS [Сумма продажи]
FROM     dbo.Продажа INNER JOIN
                  dbo.Специалист ON dbo.Продажа.ID_Специалиста = dbo.Специалист.ID_Специалиста INNER JOIN
                  dbo.Товар ON dbo.Продажа.ID_Модели = dbo.Товар.ID_Модели
GO
/****** Object:  Table [dbo].[Характеристики]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Характеристики](
	[ID_Характеристики] [int] IDENTITY(1,1) NOT NULL,
	[ID_Модели] [int] NOT NULL,
	[ОЗУ] [float] NULL,
	[Количество_встроенной_памяти] [float] NULL,
	[Слот_MicroSD] [bit] NULL,
	[ОС] [nvarchar](max) NULL,
	[Версия_ОС] [nvarchar](max) NULL,
	[Разрешение_камеры] [float] NULL,
	[Емкость_аккумулятора] [int] NULL,
	[Количество_SIM] [int] NOT NULL,
	[Длинна] [float] NULL,
	[Ширина] [float] NULL,
	[Толщина] [float] NULL,
	[Вес] [float] NULL,
 CONSTRAINT [PK_Характеристики_1] PRIMARY KEY CLUSTERED 
(
	[ID_Характеристики] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Модели и характеристики]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Модели и характеристики]
AS
SELECT dbo.Товар.ID_Модели, dbo.Товар.Название_модели AS [Название модели], dbo.Товар.Год_выпуска_модели AS [Год выпуска], dbo.Характеристики.ОЗУ, 
                  dbo.Характеристики.Количество_встроенной_памяти AS [Количество встроенной памяти], dbo.Характеристики.Слот_MicroSD AS [Слот MicroSD], dbo.Характеристики.ОС, dbo.Характеристики.Версия_ОС AS [Версия ОС], 
                  dbo.Характеристики.Разрешение_камеры AS [Разрешение камеры], dbo.Характеристики.Емкость_аккумулятора AS [Емкость аккумулятора], dbo.Характеристики.Количество_SIM, dbo.Характеристики.Длинна, 
                  dbo.Характеристики.Ширина, dbo.Характеристики.Толщина, dbo.Характеристики.Вес
FROM     dbo.Товар INNER JOIN
                  dbo.Характеристики ON dbo.Товар.ID_Модели = dbo.Характеристики.ID_Модели
GO
/****** Object:  Table [dbo].[Клиент]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Клиент](
	[ID_Клиента] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [nvarchar](50) NOT NULL,
	[Имя] [nvarchar](50) NOT NULL,
	[Отчество] [nvarchar](50) NOT NULL,
	[Номер_паспорта] [nvarchar](9) NOT NULL,
 CONSTRAINT [PK_Клиент] PRIMARY KEY CLUSTERED 
(
	[ID_Клиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Распределение_по_цветам]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Распределение_по_цветам](
	[ID_Распределения] [int] IDENTITY(1,1) NOT NULL,
	[Количество] [int] NOT NULL,
	[ID_Модели] [int] NOT NULL,
	[ID_Цвета] [int] NOT NULL,
 CONSTRAINT [PK_Распределение_по_цветам] PRIMARY KEY CLUSTERED 
(
	[ID_Распределения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Цвета]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Цвета](
	[ID_Цвета] [int] IDENTITY(1,1) NOT NULL,
	[Название_цвета] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Модели] PRIMARY KEY CLUSTERED 
(
	[ID_Цвета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Продажа]  WITH CHECK ADD  CONSTRAINT [FK_Продажа_Клиент] FOREIGN KEY([ID_Клиента])
REFERENCES [dbo].[Клиент] ([ID_Клиента])
GO
ALTER TABLE [dbo].[Продажа] CHECK CONSTRAINT [FK_Продажа_Клиент]
GO
ALTER TABLE [dbo].[Продажа]  WITH CHECK ADD  CONSTRAINT [FK_Продажа_Специалист] FOREIGN KEY([ID_Специалиста])
REFERENCES [dbo].[Специалист] ([ID_Специалиста])
GO
ALTER TABLE [dbo].[Продажа] CHECK CONSTRAINT [FK_Продажа_Специалист]
GO
ALTER TABLE [dbo].[Продажа]  WITH CHECK ADD  CONSTRAINT [FK_Продажа_Товар] FOREIGN KEY([ID_Модели])
REFERENCES [dbo].[Товар] ([ID_Модели])
GO
ALTER TABLE [dbo].[Продажа] CHECK CONSTRAINT [FK_Продажа_Товар]
GO
ALTER TABLE [dbo].[Распределение_по_цветам]  WITH CHECK ADD  CONSTRAINT [FK_Распределение_по_цветам_Товар] FOREIGN KEY([ID_Модели])
REFERENCES [dbo].[Товар] ([ID_Модели])
GO
ALTER TABLE [dbo].[Распределение_по_цветам] CHECK CONSTRAINT [FK_Распределение_по_цветам_Товар]
GO
ALTER TABLE [dbo].[Распределение_по_цветам]  WITH CHECK ADD  CONSTRAINT [FK_Распределение_по_цветам_Цвета1] FOREIGN KEY([ID_Цвета])
REFERENCES [dbo].[Цвета] ([ID_Цвета])
GO
ALTER TABLE [dbo].[Распределение_по_цветам] CHECK CONSTRAINT [FK_Распределение_по_цветам_Цвета1]
GO
ALTER TABLE [dbo].[Характеристики]  WITH CHECK ADD  CONSTRAINT [FK_Характеристики_Товар] FOREIGN KEY([ID_Модели])
REFERENCES [dbo].[Товар] ([ID_Модели])
GO
ALTER TABLE [dbo].[Характеристики] CHECK CONSTRAINT [FK_Характеристики_Товар]
GO
/****** Object:  StoredProcedure [dbo].[InsertEmptyEntry]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[InsertEmptyEntry]
as
begin
insert into Товар values('Не задано', NULL, 12, 0, 'Не задано', NULL)
insert into Характеристики values((SELECT top 1 ID_Модели FROM Товар ORDER BY ID_Модели DESC), NULL,NULL,'false',NULL,NULL,NULL,NULL,'1',NULL,NULL,NULL,NULL)
end
GO
/****** Object:  StoredProcedure [dbo].[SearchByСharacteristics]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SearchByСharacteristics]
@SearchingValue nvarchar(max) as
begin
SELECT 
Товар.ID_Модели, 
Товар.Название_модели AS [Название модели], 
Товар.Год_выпуска_модели AS [Год выпуска], 
Характеристики.ОЗУ, 
Характеристики.Количество_встроенной_памяти AS [Количество встроенной памяти], 
Характеристики.Слот_MicroSD AS [Слот MicroSD], 
Характеристики.ОС, 
Характеристики.Версия_ОС AS [Версия ОС], 
Характеристики.Разрешение_камеры AS [Разрешение камеры], 
Характеристики.Емкость_аккумулятора AS [Емкость аккумулятора], 
Характеристики.Количество_SIM, 
Характеристики.Длинна, 
Характеристики.Ширина, 
Характеристики.Толщина, 
Характеристики.Вес
FROM     
Товар INNER JOIN Характеристики ON Товар.ID_Модели = Характеристики.ID_Модели
where 
Товар.Название_модели like @SearchingValue 
or Товар.Год_выпуска_модели like @SearchingValue
or Характеристики.ОЗУ like @SearchingValue
or Характеристики.Количество_встроенной_памяти like @SearchingValue
or Характеристики.Слот_MicroSD like @SearchingValue
or Характеристики.ОС like @SearchingValue
or Характеристики.Версия_ОС like @SearchingValue
or Характеристики.Разрешение_камеры like @SearchingValue
or Характеристики.Емкость_аккумулятора like @SearchingValue
or Характеристики.Количество_SIM like @SearchingValue
or Характеристики.Длинна like @SearchingValue
or Характеристики.Ширина like @SearchingValue
or Характеристики.Толщина like @SearchingValue
or Характеристики.Вес like @SearchingValue
end
GO
/****** Object:  StoredProcedure [dbo].[SearchInJournal]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SearchInJournal]
@SearchingValue nvarchar(max) as
begin
SELECT 
Продажа.Номер_Договора, 
Продажа.Дата_заключения_договора, 
Продажа.Срок_действия_договора, 
Продажа.Окончание_гарантийного_срока, 
Продажа.Дата_продажи, 
Продажа.Процент_НДС, 
Продажа.Стоимость_постгарантийного_обсуживания, 
Продажа.Сумма_продажи, 
Специалист.Фамилия AS Фамилия_Специалиста, 
Клиент.Фамилия AS Фамилия_Клиента, 
Товар.Название_модели 
FROM 
Продажа INNER JOIN Клиент ON Продажа.ID_Клиента = Клиент.ID_Клиента INNER JOIN Специалист ON Продажа.ID_Специалиста = Специалист.ID_Специалиста INNER JOIN Товар ON Продажа.ID_Модели = Товар.ID_Модели
WHERE
Продажа.Дата_заключения_договора like '%'+@SearchingValue+'%'
or Продажа.Срок_действия_договора like '%'+@SearchingValue+'%'
or Продажа.Окончание_гарантийного_срока like '%'+@SearchingValue+'%'
or Продажа.Дата_продажи like '%'+@SearchingValue+'%'
or Продажа.Процент_НДС like '%'+@SearchingValue+'%'
or Продажа.Стоимость_постгарантийного_обсуживания like '%'+@SearchingValue+'%'
or Продажа.Сумма_продажи like '%'+@SearchingValue+'%'
or Специалист.Фамилия like '%'+@SearchingValue+'%'
or Клиент.Фамилия like '%'+@SearchingValue+'%'
or Товар.Название_модели like '%'+@SearchingValue+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateLine_Модели_И_Их_Характеристики]    Script Date: 17.12.2019 15:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[UpdateLine_Модели_И_Их_Характеристики]
@ID_Модели int,
@Название_модели nvarchar(max),
@Год_выпуска date null,
@ОЗУ float null,
@Количество_встроенной_памяти float null,
@Слот_MicroSD bit,
@ОС nvarchar(max) null,
@Версия_ОС nvarchar(max) null,
@Разрешение_камеры float null,
@Емкость_аккумулятора int null,
@Количество_SIM int,
@Длинна float null,
@Ширина float null,
@Толщина float null,
@Вес float null
as
begin
update Характеристики
SET 
	ОЗУ = @ОЗУ,
	Количество_встроенной_памяти = @Количество_встроенной_памяти,
	Слот_MicroSD = @Слот_MicroSD,
	ОС = @ОС,
	Версия_ОС = @Версия_ОС,
	Разрешение_камеры = @Разрешение_камеры,
	Емкость_аккумулятора = @Емкость_аккумулятора,
	Количество_SIM = @Количество_SIM,
	Длинна = @Длинна,
	Ширина = @Ширина,
	Толщина = @Толщина,
	Вес = @Вес
		where ID_Модели = @ID_Модели
update Товар
set 
	Название_модели = @Название_модели,
	Год_выпуска_модели = @Год_выпуска
	where ID_Модели = @ID_Модели
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 1
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Продажа"
            Begin Extent = 
               Top = 0
               Left = 437
               Bottom = 336
               Right = 849
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Специалист"
            Begin Extent = 
               Top = 0
               Left = 72
               Bottom = 329
               Right = 306
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Товар"
            Begin Extent = 
               Top = 0
               Left = 988
               Bottom = 245
               Right = 1209
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
      PaneHidden = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1776
         Width = 1200
         Width = 1200
         Width = 1908
         Width = 2304
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Журнал продаж'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Журнал продаж'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[45] 4[16] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1[56] 3) )"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1[49] 4) )"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 1
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Товар"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 257
               Right = 323
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Характеристики"
            Begin Extent = 
               Top = 0
               Left = 433
               Bottom = 389
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
      PaneHidden = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 2196
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3792
         Alias = 3984
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Модели и характеристики'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Модели и характеристики'
GO
USE [master]
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET  READ_WRITE 
GO
