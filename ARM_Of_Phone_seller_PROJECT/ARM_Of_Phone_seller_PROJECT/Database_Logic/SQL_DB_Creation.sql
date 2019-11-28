﻿USE [master]
GO
/****** Object:  Database [ARM_Of_Phone_Seller]    Script Date: 27.11.2019 9:19:45 ******/
CREATE DATABASE [ARM_Of_Phone_Seller]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARM_Of_Phone_Seller', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ARM_Of_Phone_Seller.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ARM_Of_Phone_Seller_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ARM_Of_Phone_Seller_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [ARM_Of_Phone_Seller] SET AUTO_CLOSE OFF 
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
/****** Object:  Table [dbo].[Распределение_по_цветам]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Распределение_по_цветам](
	[ID_Распределения] [int] NOT NULL,
	[Количество] [int] NOT NULL,
	[ID_Модели] [int] NOT NULL,
	[ID_Цвета] [int] NOT NULL,
 CONSTRAINT [PK_Распределение_по_цветам] PRIMARY KEY CLUSTERED 
(
	[ID_Распределения] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Цвета]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Цвета](
	[ID_Цвета] [int] NOT NULL,
	[Название_цвета] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Модели] PRIMARY KEY CLUSTERED 
(
	[ID_Цвета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товар]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товар](
	[ID_Модели] [int] NOT NULL,
	[Название_модели] [nvarchar](max) NOT NULL,
	[IMEI] [nvarchar](max) NULL,
	[Срок_гарантии] [real] NOT NULL,
	[Стоимость] [real] NOT NULL,
	[Номер_сертификата] [nvarchar](max) NOT NULL,
	[Год_выпуска_модели] [date] NULL,
 CONSTRAINT [PK_Товар_1] PRIMARY KEY CLUSTERED 
(
	[ID_Модели] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[Модели_и их_характеристики]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Модели_и их_характеристики]
AS
SELECT dbo.Товар.Название_модели AS [Название модели], dbo.Характеристики_мобильных_телефонов.Название_характеристики AS [Название характеристики], 
                  dbo.Распределение_по_характеристикам.Значение_характеристики
FROM     dbo.Распределение_по_характеристикам INNER JOIN
                  dbo.Распределение_по_цветам ON dbo.Распределение_по_характеристикам.ID_Распределения = dbo.Распределение_по_цветам.ID_Распределения INNER JOIN
                  dbo.Товар ON dbo.Распределение_по_характеристикам.ID_Модели = dbo.Товар.ID_Модели AND dbo.Распределение_по_цветам.ID_Модели = dbo.Товар.ID_Модели INNER JOIN
                  dbo.Характеристики_мобильных_телефонов ON dbo.Распределение_по_характеристикам.ID_Характеристики = dbo.Характеристики_мобильных_телефонов.ID_Характеристики INNER JOIN
                  dbo.Цвета ON dbo.Распределение_по_цветам.ID_Цвета = dbo.Цвета.ID_Цвета
WHERE  (dbo.Товар.Название_модели = N'Nokia 3310')
GO
/****** Object:  View [dbo].[Наличие_моделей_по_цветам]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Наличие_моделей_по_цветам]
AS
SELECT dbo.Товар.Название_модели AS [Название модели], dbo.Распределение_по_цветам.Количество, dbo.Цвета.Название_цвета AS Цвет
FROM     dbo.Товар INNER JOIN
                  dbo.Распределение_по_цветам ON dbo.Товар.ID_Модели = dbo.Распределение_по_цветам.ID_Модели INNER JOIN
                  dbo.Цвета ON dbo.Распределение_по_цветам.ID_Цвета = dbo.Цвета.ID_Цвета INNER JOIN
                  dbo.Распределение_по_характеристикам ON dbo.Товар.ID_Модели = dbo.Распределение_по_характеристикам.ID_Модели INNER JOIN
                  dbo.Характеристики_мобильных_телефонов ON dbo.Распределение_по_характеристикам.ID_Характеристики = dbo.Характеристики_мобильных_телефонов.ID_Характеристики
GO
/****** Object:  Table [dbo].[Специалист]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Специалист](
	[ID_Специалиста] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Продажа]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Продажа](
	[Номер_договора] [nvarchar](50) NOT NULL,
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
/****** Object:  View [dbo].[Журнал_продаж]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Журнал_продаж]
AS
SELECT dbo.Продажа.Дата_продажи AS [Дата продажи], dbo.Специалист.Фамилия, dbo.Специалист.Имя, dbo.Товар.Название_модели AS [Название модели], dbo.Продажа.Сумма_продажи AS [Сумма продажи]
FROM     dbo.Продажа INNER JOIN
                  dbo.Специалист ON dbo.Продажа.ID_Специалиста = dbo.Специалист.ID_Специалиста INNER JOIN
                  dbo.Товар ON dbo.Продажа.ID_Модели = dbo.Товар.ID_Модели
GO
/****** Object:  View [dbo].[Журнал продаж]    Script Date: 27.11.2019 9:19:46 ******/
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
/****** Object:  View [dbo].[Просмотр общей информации о моделях]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Просмотр общей информации о моделях]
AS
SELECT dbo.Товар.Название_модели AS Модель, dbo.Характеристики_мобильных_телефонов.Название_характеристики AS Характеристика, 
                  dbo.Распределение_по_характеристикам.Значение_характеристики AS [Значение характеристики], dbo.Распределение_по_цветам.Количество, dbo.Цвета.Название_цвета AS Цвет
FROM     dbo.Распределение_по_характеристикам INNER JOIN
                  dbo.Характеристики_мобильных_телефонов ON dbo.Распределение_по_характеристикам.ID_Характеристики = dbo.Характеристики_мобильных_телефонов.ID_Характеристики INNER JOIN
                  dbo.Товар ON dbo.Распределение_по_характеристикам.ID_Модели = dbo.Товар.ID_Модели INNER JOIN
                  dbo.Цвета INNER JOIN
                  dbo.Распределение_по_цветам ON dbo.Цвета.ID_Цвета = dbo.Распределение_по_цветам.ID_Цвета ON dbo.Товар.ID_Модели = dbo.Распределение_по_цветам.ID_Модели
GO
/****** Object:  Table [dbo].[Клиент]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Клиент](
	[ID_Клиента] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Характеристики]    Script Date: 27.11.2019 9:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Характеристики](
	[ID_Характеристики] [int] NOT NULL,
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
               Left = 375
               Bottom = 336
               Right = 787
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Специалист"
            Begin Extent = 
               Top = 0
               Left = 46
               Bottom = 329
               Right = 280
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Товар"
            Begin Extent = 
               Top = 0
               Left = 926
               Bottom = 245
               Right = 1147
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Журнал_продаж'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Журнал_продаж'
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
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Распределение_по_характеристикам"
            Begin Extent = 
               Top = 0
               Left = 328
               Bottom = 163
               Right = 606
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Распределение_по_цветам"
            Begin Extent = 
               Top = 0
               Left = 987
               Bottom = 163
               Right = 1210
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Товар"
            Begin Extent = 
               Top = 83
               Left = 652
               Bottom = 313
               Right = 940
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Характеристики_мобильных_телефонов"
            Begin Extent = 
               Top = 106
               Left = 0
               Bottom = 225
               Right = 278
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Цвета"
            Begin Extent = 
               Top = 155
               Left = 1265
               Bottom = 274
               Right = 1473
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 2100
         Width = 3012
         Width = 2820
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2688
         Alias = 2880
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1356
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Модели_и их_характеристики'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Модели_и их_характеристики'
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
         Configuration = "(H (1 [50] 4 [25] 3))"
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
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Товар"
            Begin Extent = 
               Top = 0
               Left = 650
               Bottom = 241
               Right = 903
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Распределение_по_цветам"
            Begin Extent = 
               Top = 0
               Left = 948
               Bottom = 163
               Right = 1171
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Цвета"
            Begin Extent = 
               Top = 0
               Left = 1215
               Bottom = 118
               Right = 1418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Характеристики_мобильных_телефонов"
            Begin Extent = 
               Top = 0
               Left = 0
               Bottom = 119
               Right = 278
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Распределение_по_характеристикам"
            Begin Extent = 
               Top = 0
               Left = 327
               Bottom = 163
               Right = 604
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1824
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
      Begin ColumnWidths' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Наличие_моделей_по_цветам'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 11
         Column = 1440
         Alias = 900
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Наличие_моделей_по_цветам'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Наличие_моделей_по_цветам'
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
         Configuration = "(H (1 [50] 4 [25] 3))"
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
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Цвета"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 126
               Right = 256
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Характеристики_мобильных_телефонов"
            Begin Extent = 
               Top = 0
               Left = 1205
               Bottom = 119
               Right = 1483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Распределение_по_цветам"
            Begin Extent = 
               Top = 0
               Left = 308
               Bottom = 163
               Right = 531
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Распределение_по_характеристикам"
            Begin Extent = 
               Top = 0
               Left = 863
               Bottom = 163
               Right = 1140
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Товар"
            Begin Extent = 
               Top = 0
               Left = 574
               Bottom = 237
               Right = 820
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1200
         Width = 2064
         Width = 2340
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidth' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Просмотр общей информации о моделях'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N's = 11
         Column = 2472
         Alias = 3816
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Просмотр общей информации о моделях'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Просмотр общей информации о моделях'
GO
USE [master]
GO
ALTER DATABASE [ARM_Of_Phone_Seller] SET  READ_WRITE 
GO