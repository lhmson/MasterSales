USE [master]
GO
/****** Object:  Database [QLKinhDoanh]    Script Date: 14/01/2021 12:04:20 AM ******/
CREATE DATABASE [QLKinhDoanh]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLKinhDoanh', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QLKinhDoanh.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLKinhDoanh_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\QLKinhDoanh_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLKinhDoanh] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLKinhDoanh].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLKinhDoanh] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLKinhDoanh] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLKinhDoanh] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLKinhDoanh] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLKinhDoanh] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLKinhDoanh] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLKinhDoanh] SET  MULTI_USER 
GO
ALTER DATABASE [QLKinhDoanh] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLKinhDoanh] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLKinhDoanh] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLKinhDoanh] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLKinhDoanh] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLKinhDoanh] SET QUERY_STORE = OFF
GO
USE [QLKinhDoanh]
GO
/****** Object:  Table [dbo].[BANGLAMTHEM]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGLAMTHEM](
	[id] [varchar](20) NOT NULL,
	[MaTrgPB] [varchar](20) NULL,
	[NgayLap] [smalldatetime] NULL,
	[Thang] [int] NOT NULL,
	[MaPhong] [varchar](20) NULL,
	[HeSo] [money] NULL,
	[isDeleted] [bit] NULL,
	[Nam] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BANGLUONGTL]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGLUONGTL](
	[id] [varchar](20) NOT NULL,
	[MaKeToan] [varchar](20) NULL,
	[NgayLap] [smalldatetime] NULL,
	[Thang] [int] NULL,
	[MaPhong] [varchar](20) NULL,
	[isDeleted] [bit] NULL,
	[Nam] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BANGTHUONG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BANGTHUONG](
	[id] [varchar](20) NOT NULL,
	[MaTrgPB] [varchar](20) NULL,
	[NgayLap] [smalldatetime] NULL,
	[Thang] [int] NULL,
	[MaPhong] [varchar](20) NULL,
	[isDeleted] [bit] NULL,
	[Nam] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCNANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCNANG](
	[id] [varchar](20) NOT NULL,
	[TenChucNang] [nvarchar](50) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[id] [varchar](20) NOT NULL,
	[TenChucVu] [nvarchar](50) NULL,
	[MaPhongBan] [varchar](20) NOT NULL,
	[PhuCap] [money] NULL,
	[isTrgPB] [bit] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_BANGLAMTHEM]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BANGLAMTHEM](
	[id] [varchar](20) NOT NULL,
	[MaLamThem] [varchar](20) NULL,
	[MaNV] [varchar](20) NULL,
	[SoBuoi] [int] NULL,
	[TienLamThem] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_BANGLUONGTL]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BANGLUONGTL](
	[id] [varchar](20) NOT NULL,
	[MaLuongTL] [varchar](20) NULL,
	[MaNV] [varchar](20) NULL,
	[LuongCB] [money] NULL,
	[TienThuong] [money] NULL,
	[LuongLamThem] [money] NULL,
	[PhuCap] [money] NULL,
	[TongLuong] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_BANGTHUONG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_BANGTHUONG](
	[id] [varchar](20) NOT NULL,
	[MaThuong] [varchar](20) NULL,
	[MaNV] [varchar](20) NULL,
	[MaMucThuong] [varchar](20) NULL,
	[TienThuong] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_HOADON]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_HOADON](
	[id] [varchar](20) NOT NULL,
	[MaHD] [varchar](20) NULL,
	[MaMH] [varchar](20) NULL,
	[SLMua] [int] NULL,
	[DonGia] [money] NULL,
	[TongTien] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CT_PHIEUDATHANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CT_PHIEUDATHANG](
	[id] [varchar](20) NOT NULL,
	[MaPhieuDH] [varchar](20) NULL,
	[MaMH] [varchar](20) NULL,
	[SLDat] [int] NULL,
	[DonGia] [money] NULL,
	[TongTien] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DANHGIAKYNANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHGIAKYNANG](
	[id] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[MaKyNang] [varchar](20) NOT NULL,
	[LoaiDanhGia] [nvarchar](50) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[id] [varchar](20) NOT NULL,
	[MaPhieuDH] [varchar](20) NULL,
	[NgayLap] [smalldatetime] NULL,
	[NgayXuat] [smalldatetime] NULL,
	[MaKH] [varchar](20) NULL,
	[MaNV] [varchar](20) NULL,
	[ThanhTien] [money] NULL,
	[TrangThai] [int] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOPDONG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOPDONG](
	[id] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[NgayHD] [smalldatetime] NULL,
	[NgayKT] [smalldatetime] NULL,
	[MaLoaiHD] [varchar](20) NOT NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[id] [varchar](20) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [varchar](20) NULL,
	[Avatar] [varchar](1000) NULL,
	[TenDangNhap] [varchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KYNANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KYNANG](
	[id] [varchar](20) NOT NULL,
	[TenKyNang] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LICHSUCHUCVU]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LICHSUCHUCVU](
	[id] [varchar](20) NOT NULL,
	[MaNV] [varchar](20) NOT NULL,
	[MaChucVu] [varchar](20) NOT NULL,
	[NgayBD] [smalldatetime] NULL,
	[NgayKT] [smalldatetime] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIHOPDONG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIHOPDONG](
	[id] [varchar](20) NOT NULL,
	[TenLoaiHD] [nvarchar](50) NULL,
	[ThoiHan] [int] NULL,
	[Luong] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MATHANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MATHANG](
	[id] [varchar](20) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
	[DonVi] [nvarchar](50) NULL,
	[HinhAnh] [varchar](1000) NULL,
	[MaNCC] [varchar](20) NULL,
	[MaNhomMH] [varchar](20) NULL,
	[DonGia] [money] NULL,
	[isDeleted] [bit] NULL,
	[MoTa] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MUCTHUONG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MUCTHUONG](
	[id] [varchar](20) NOT NULL,
	[TenMucThuong] [nvarchar](50) NOT NULL,
	[TienThuong] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[id] [varchar](20) NOT NULL,
	[TenNCC] [nvarchar](50) NULL,
	[SDT] [varchar](20) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[id] [varchar](20) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [smalldatetime] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NoiSinh] [nvarchar](50) NULL,
	[MaTrinhDo] [varchar](20) NOT NULL,
	[NgayKetThuc] [smalldatetime] NULL,
	[MaChucVu] [varchar](20) NOT NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHOMMATHANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMMATHANG](
	[id] [varchar](20) NOT NULL,
	[TenNhomMH] [nvarchar](50) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MaChucNang] [varchar](20) NOT NULL,
	[MaChucVu] [varchar](20) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC,
	[MaChucNang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEUDATHANG]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDATHANG](
	[id] [varchar](20) NOT NULL,
	[MaKH] [varchar](20) NULL,
	[NgayDat] [smalldatetime] NULL,
	[ThanhTien] [money] NULL,
	[TrangThai] [int] NULL,
	[isDeleted] [bit] NULL,
	[DiaChiNhan] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONGBAN]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONGBAN](
	[id] [varchar](20) NOT NULL,
	[TenPhong] [nvarchar](50) NULL,
	[MaTrgPB] [varchar](20) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[id] [varchar](20) NOT NULL,
	[TenDangNhap] [varchar](20) NULL,
	[MatKhau] [varchar](50) NULL,
	[Avatar] [varchar](1000) NULL,
	[MaNV] [varchar](20) NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[id] [nvarchar](50) NOT NULL,
	[GiaTri] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRINHDO]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRINHDO](
	[id] [varchar](20) NOT NULL,
	[TenTrinhDo] [nvarchar](50) NOT NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TuVanKH]    Script Date: 14/01/2021 12:04:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TuVanKH](
	[id] [varchar](20) NOT NULL,
	[MaKH] [varchar](20) NULL,
	[CauHoi] [nvarchar](1000) NULL,
	[TraLoi] [nvarchar](1000) NULL,
	[isDeleted] [bit] NULL,
	[NgayDat] [smalldatetime] NULL,
	[NgayTraLoi] [smalldatetime] NULL,
	[NguoiTraLoi] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BANGLAMTHEM] ([id], [MaTrgPB], [NgayLap], [Thang], [MaPhong], [HeSo], [isDeleted], [Nam]) VALUES (N'BLT0000001', N'NV00001', CAST(N'2021-01-13T22:40:00' AS SmallDateTime), 1, N'PB001', 100000.0000, 0, 2021)
INSERT [dbo].[BANGLUONGTL] ([id], [MaKeToan], [NgayLap], [Thang], [MaPhong], [isDeleted], [Nam]) VALUES (N'BLTL00000001', NULL, CAST(N'2021-01-13T22:40:00' AS SmallDateTime), 1, N'PB001', 0, 2021)
INSERT [dbo].[BANGTHUONG] ([id], [MaTrgPB], [NgayLap], [Thang], [MaPhong], [isDeleted], [Nam]) VALUES (N'BT00000001', N'NV00001', CAST(N'2021-01-13T22:40:00' AS SmallDateTime), 1, N'PB001', 0, 2021)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN001', N'Quản lí tuyển dụng', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN002', N'Quản lí lương thưởng', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN003', N'Quản lí lịch sử làm việc', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN004', N'Quản lí đào tào kĩ năng', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN005', N'Tra cứu nhân viên', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN006', N'Xử lí bán hàng', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN007', N'Quản lí khách hàng', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN008', N'Lập báo cáo kinh doanh', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN009', N'Quản lí phân quyền', 0)
INSERT [dbo].[CHUCNANG] ([id], [TenChucNang], [isDeleted]) VALUES (N'CN010', N'Thay đổi quy định', 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV001', N'Giám đốc điều hành', N'PB001', 5600000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV002', N'Trưởng phòng nhân sự', N'PB002', 4600000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV003', N'Trưởng phòng kinh doanh', N'PB003', 5200000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV004', N'Trưởng phòng kĩ thuật', N'PB004', 4350000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV005', N'Trưởng phòng kế toán', N'PB005', 2350000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV006', N'Trưởng phòng đào tạo', N'PB006', 3600000.0000, 1, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV007', N'Nhân viên nhân sự', N'PB002', 2600000.0000, 0, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV008', N'Nhân viên kinh doanh', N'PB003', 3200000.0000, 0, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV009', N'Nhân viên kĩ thuật', N'PB004', 2350000.0000, 0, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV010', N'Nhân viên kế toán', N'PB005', 1200000.0000, 0, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV011', N'Nhân viên đào tạo', N'PB006', 1600000.0000, 0, 0)
INSERT [dbo].[CHUCVU] ([id], [TenChucVu], [MaPhongBan], [PhuCap], [isTrgPB], [isDeleted]) VALUES (N'CV012', N'Giám sát viên', N'PB001', 4000000.0000, 0, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000001', N'BLT0000001', N'NV00001', 3, 450000.0000, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000002', N'BLT0000001', N'NV00009', 1, 150000.0000, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000003', N'BLT0000001', N'NV00010', 4, 400000.0000, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000004', N'BLT0000001', N'NV00012', 2, 300000.0000, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000005', N'BLT0000001', N'NV00013', 2, 300000.0000, 0)
INSERT [dbo].[CT_BANGLAMTHEM] ([id], [MaLamThem], [MaNV], [SoBuoi], [TienLamThem], [isDeleted]) VALUES (N'CTBLT0000000006', N'BLT0000001', N'NV00014', 3, 450000.0000, 0)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000001', N'BLTL00000001', N'NV00001', 5000000.0000, 2000000.0000, 0.0000, 5600000.0000, 11250000.0000, NULL)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000002', N'BLTL00000001', N'NV00009', 8000000.0000, 2000000.0000, 0.0000, 4000000.0000, 12350000.0000, NULL)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000003', N'BLTL00000001', N'NV00010', 9000000.0000, 2000000.0000, 0.0000, 4000000.0000, 13600000.0000, NULL)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000004', N'BLTL00000001', N'NV00012', 9000000.0000, 2000000.0000, 0.0000, 4000000.0000, 10500000.0000, NULL)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000005', N'BLTL00000001', N'NV00013', 9000000.0000, 2000000.0000, 0.0000, 4000000.0000, 13500000.0000, NULL)
INSERT [dbo].[CT_BANGLUONGTL] ([id], [MaLuongTL], [MaNV], [LuongCB], [TienThuong], [LuongLamThem], [PhuCap], [TongLuong], [isDeleted]) VALUES (N'CTBLTL0000000006', N'BLTL00000001', N'NV00014', 5000000.0000, 2000000.0000, 0.0000, 4000000.0000, 9650000.0000, NULL)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000001', N'BT00000001', N'NV00001', N'MT3', 200000.0000, 0)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000002', N'BT00000001', N'NV00009', N'MT3', 200000.0000, 0)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000003', N'BT00000001', N'NV00010', N'MT3', 200000.0000, 0)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000004', N'BT00000001', N'NV00012', N'MT2', 1200000.0000, 0)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000005', N'BT00000001', N'NV00013', N'MT3', 200000.0000, 0)
INSERT [dbo].[CT_BANGTHUONG] ([id], [MaThuong], [MaNV], [MaMucThuong], [TienThuong], [isDeleted]) VALUES (N'CTBT0000000006', N'BT00000001', N'NV00014', N'MT3', 200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000001', N'HD00000001', N'MH16', 1, 340000.0000, 340000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000002', N'HD00000001', N'MH12', 1, 3200000.0000, 3200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000003', N'HD00000001', N'MH17', 1, 220000.0000, 220000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000004', N'HD00000001', N'MH14', 2, 15800000.0000, 31600000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000005', N'HD00000002', N'MH15', 3, 6750000.0000, 20250000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000006', N'HD00000002', N'MH18', 1, 4900000.0000, 4900000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000007', N'HD00000002', N'MH17', 1, 220000.0000, 220000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000008', N'HD00000002', N'MH22', 1, 34000000.0000, 34000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000009', N'HD00000003', N'MH24', 2, 750000.0000, 750000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000010', N'HD00000003', N'MH5', 1, 9000000.0000, 9000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000011', N'HD00000004', N'MH1', 1, 10000000.0000, 10000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000012', N'HD00000004', N'MH2', 1, 12000000.0000, 12000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000013', N'HD00000005', N'MH14', 1, 15800000.0000, 15800000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000014', N'HD00000005', N'MH22', 1, 34000000.0000, 34000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000015', N'HD00000005', N'MH21', 1, 18200000.0000, 18200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000016', N'HD00000006', N'MH28', 2, 45000000.0000, 45000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000017', N'HD00000007', N'MH3', 2, 14000000.0000, 14000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000018', N'HD00000008', N'MH8', 2, 19200000.0000, 19200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000019', N'HD00000009', N'MH14', 1, 15800000.0000, 15800000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000020', N'HD00000010', N'MH22', 1, 34000000.0000, 34000000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000021', N'HD00000011', N'MH16', 1, 340000.0000, 340000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000022', N'HD00000011', N'MH13', 1, 150000.0000, 150000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000023', N'HD00000012', N'MH13', 1, 150000.0000, 150000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000024', N'HD00000013', N'MH11', 1, 5600000.0000, 5600000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000025', N'HD00000014', N'MH14', 1, 15800000.0000, 15800000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000026', N'HD00000015', N'MH12', 1, 3200000.0000, 3200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000027', N'HD00000016', N'MH16', 1, 340000.0000, 340000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000028', N'HD00000017', N'MH18', 1, 4900000.0000, 4900000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000029', N'HD00000018', N'MH18', 1, 4900000.0000, 4900000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000030', N'HD00000019', N'MH17', 1, 220000.0000, 220000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000031', N'HD00000020', N'MH15', 1, 6750000.0000, 6750000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000032', N'HD00000021', N'MH15', 1, 6750000.0000, 6750000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000033', N'HD00000022', N'MH13', 1, 150000.0000, 150000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000034', N'HD00000022', N'MH17', 1, 220000.0000, 220000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000035', N'HD00000022', N'MH10', 1, 2300000.0000, 2300000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000036', N'HD00000023', N'MH19', 1, 17500000.0000, 17500000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000037', N'HD00000023', N'MH21', 1, 18200000.0000, 18200000.0000, 0)
INSERT [dbo].[CT_HOADON] ([id], [MaHD], [MaMH], [SLMua], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTHD000038', N'HD00000024', N'MH11', 1, 5600000.0000, 5600000.0000, 0)
INSERT [dbo].[CT_PHIEUDATHANG] ([id], [MaPhieuDH], [MaMH], [SLDat], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTPDH1', N'PDH1', N'MH1', 1, 10000000.0000, 10000000.0000, 0)
INSERT [dbo].[CT_PHIEUDATHANG] ([id], [MaPhieuDH], [MaMH], [SLDat], [DonGia], [TongTien], [isDeleted]) VALUES (N'CTPDH2', N'PDH1', N'MH2', 1, 12000000.0000, 12000000.0000, 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00001', N'NV00001', N'KN001', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00002', N'NV00001', N'KN002', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00003', N'NV00001', N'KN006', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00004', N'NV00002', N'KN002', N'Giỏi', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00005', N'NV00002', N'KN005', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00006', N'NV00003', N'KN003', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00007', N'NV00003', N'KN004', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00008', N'NV00004', N'KN001', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00009', N'NV00004', N'KN004', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00010', N'NV00005', N'KN002', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00011', N'NV00006', N'KN007', N'Giỏi', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00012', N'NV00003', N'KN002', N'Giỏi', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00013', N'NV00004', N'KN007', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00014', N'NV00004', N'KN006', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00015', N'NV00004', N'KN005', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00016', N'NV00007', N'KN004', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00017', N'NV00007', N'KN001', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00018', N'NV00007', N'KN002', N'Xuất sắc', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00019', N'NV00008', N'KN007', N'Giỏi', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00020', N'NV00008', N'KN005', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00021', N'NV00008', N'KN001', N'Khá', 0)
INSERT [dbo].[DANHGIAKYNANG] ([id], [MaNV], [MaKyNang], [LoaiDanhGia], [isDeleted]) VALUES (N'DGKN00022', N'NV00009', N'KN003', N'Giỏi', 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000001', NULL, CAST(N'2021-01-13T23:18:00' AS SmallDateTime), CAST(N'2021-01-13T23:18:00' AS SmallDateTime), NULL, N'NV00001', 35360000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000002', NULL, CAST(N'2021-01-12T23:19:00' AS SmallDateTime), CAST(N'2021-01-12T23:19:00' AS SmallDateTime), NULL, N'NV00001', 59370000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000003', NULL, CAST(N'2021-01-11T23:20:00' AS SmallDateTime), CAST(N'2021-01-11T23:20:00' AS SmallDateTime), NULL, N'NV00001', 9750000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000004', N'PDH1', CAST(N'2021-01-10T23:20:00' AS SmallDateTime), CAST(N'2021-01-10T23:20:00' AS SmallDateTime), NULL, N'NV00001', 22000000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000005', NULL, CAST(N'2021-01-09T23:20:00' AS SmallDateTime), CAST(N'2021-01-09T23:20:00' AS SmallDateTime), NULL, N'NV00001', 68000000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000006', NULL, CAST(N'2021-01-08T23:21:00' AS SmallDateTime), CAST(N'2021-01-08T23:21:00' AS SmallDateTime), NULL, N'NV00001', 45000000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000007', NULL, CAST(N'2021-01-07T23:21:00' AS SmallDateTime), CAST(N'2021-01-07T23:21:00' AS SmallDateTime), NULL, N'NV00001', 14000000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000008', NULL, CAST(N'2021-01-06T23:22:00' AS SmallDateTime), CAST(N'2021-01-06T23:22:00' AS SmallDateTime), NULL, N'NV00001', 19200000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000009', NULL, CAST(N'2021-01-13T23:22:00' AS SmallDateTime), CAST(N'2021-01-13T23:22:00' AS SmallDateTime), NULL, N'NV00001', 15800000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000010', NULL, CAST(N'2021-01-11T23:22:00' AS SmallDateTime), CAST(N'2021-01-12T23:22:00' AS SmallDateTime), NULL, N'NV00001', 34000000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000011', NULL, CAST(N'2021-01-07T23:28:00' AS SmallDateTime), CAST(N'2021-01-07T23:28:00' AS SmallDateTime), NULL, N'NV00001', 490000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000012', NULL, CAST(N'2021-01-07T23:28:00' AS SmallDateTime), CAST(N'2021-01-10T23:28:00' AS SmallDateTime), NULL, N'NV00001', 150000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000013', NULL, CAST(N'2020-01-13T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 5600000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000014', NULL, CAST(N'2020-02-13T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 15800000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000015', NULL, CAST(N'2020-03-13T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 3200000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000016', NULL, CAST(N'2020-04-19T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 340000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000017', NULL, CAST(N'2020-05-12T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 4900000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000018', NULL, CAST(N'2020-06-09T23:33:00' AS SmallDateTime), CAST(N'2021-01-13T23:33:00' AS SmallDateTime), NULL, N'NV00001', 4900000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000019', NULL, CAST(N'2020-07-13T23:34:00' AS SmallDateTime), CAST(N'2021-01-13T23:34:00' AS SmallDateTime), NULL, N'NV00001', 220000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000020', NULL, CAST(N'2020-08-13T23:34:00' AS SmallDateTime), CAST(N'2021-01-13T23:34:00' AS SmallDateTime), NULL, N'NV00001', 6750000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000021', NULL, CAST(N'2020-09-13T23:34:00' AS SmallDateTime), CAST(N'2021-01-13T23:34:00' AS SmallDateTime), NULL, N'NV00001', 6750000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000022', NULL, CAST(N'2020-11-13T23:37:00' AS SmallDateTime), CAST(N'2021-01-13T23:37:00' AS SmallDateTime), NULL, N'NV00001', 2670000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000023', NULL, CAST(N'2020-12-13T23:37:00' AS SmallDateTime), CAST(N'2021-01-13T23:37:00' AS SmallDateTime), NULL, N'NV00001', 35700000.0000, 1, 0)
INSERT [dbo].[HOADON] ([id], [MaPhieuDH], [NgayLap], [NgayXuat], [MaKH], [MaNV], [ThanhTien], [TrangThai], [isDeleted]) VALUES (N'HD00000024', NULL, CAST(N'2021-01-13T23:43:00' AS SmallDateTime), CAST(N'2021-01-13T23:43:00' AS SmallDateTime), NULL, N'NV00001', 5600000.0000, 1, 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00001', N'NV00001', CAST(N'2017-02-12T00:00:00' AS SmallDateTime), CAST(N'2018-04-05T00:00:00' AS SmallDateTime), N'LHD001', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00002', N'NV00002', CAST(N'2015-04-08T00:00:00' AS SmallDateTime), CAST(N'2018-08-20T00:00:00' AS SmallDateTime), N'LHD002', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00003', N'NV00003', CAST(N'2019-05-12T00:00:00' AS SmallDateTime), CAST(N'2020-04-05T00:00:00' AS SmallDateTime), N'LHD003', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00004', N'NV00004', CAST(N'2020-06-11T00:00:00' AS SmallDateTime), CAST(N'2023-12-18T00:00:00' AS SmallDateTime), N'LHD004', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00005', N'NV00005', CAST(N'2021-07-10T00:00:00' AS SmallDateTime), CAST(N'2025-05-21T00:00:00' AS SmallDateTime), N'LHD005', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00006', N'NV00006', CAST(N'2020-08-02T00:00:00' AS SmallDateTime), CAST(N'2021-08-23T00:00:00' AS SmallDateTime), N'LHD006', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00007', N'NV00007', CAST(N'2021-01-13T22:47:00' AS SmallDateTime), CAST(N'2021-02-13T22:47:00' AS SmallDateTime), N'LHD001', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00008', N'NV00008', CAST(N'2021-01-13T22:49:00' AS SmallDateTime), CAST(N'2023-01-13T22:49:00' AS SmallDateTime), N'LHD006', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00009', N'NV00009', CAST(N'2021-01-13T22:54:00' AS SmallDateTime), CAST(N'2021-04-13T22:54:00' AS SmallDateTime), N'LHD002', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00010', N'NV00010', CAST(N'2021-01-13T22:55:00' AS SmallDateTime), CAST(N'2021-07-13T22:55:00' AS SmallDateTime), N'LHD003', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00011', N'NV00011', CAST(N'2021-01-13T22:57:00' AS SmallDateTime), CAST(N'2024-01-13T22:57:00' AS SmallDateTime), N'LHD007', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00012', N'NV00013', CAST(N'2021-01-13T22:57:00' AS SmallDateTime), CAST(N'2021-07-13T22:57:00' AS SmallDateTime), N'LHD003', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00013', N'NV00012', CAST(N'2021-01-13T22:57:00' AS SmallDateTime), CAST(N'2021-07-13T22:57:00' AS SmallDateTime), N'LHD003', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00014', N'NV00015', CAST(N'2021-01-13T23:00:00' AS SmallDateTime), CAST(N'2024-01-13T23:00:00' AS SmallDateTime), N'LHD007', 0)
INSERT [dbo].[HOPDONG] ([id], [MaNV], [NgayHD], [NgayKT], [MaLoaiHD], [isDeleted]) VALUES (N'HD00015', N'NV00014', CAST(N'2021-01-13T23:00:00' AS SmallDateTime), CAST(N'2021-02-13T23:00:00' AS SmallDateTime), N'LHD001', 0)
INSERT [dbo].[KHACHHANG] ([id], [TenKH], [DiaChi], [SDT], [Avatar], [TenDangNhap], [MatKhau], [isDeleted]) VALUES (N'KH1', N'Thành Nam', N'Q Thủ Đức TPHCM', N'0123456789', NULL, N'kh1', N'kh1', 0)
INSERT [dbo].[KHACHHANG] ([id], [TenKH], [DiaChi], [SDT], [Avatar], [TenDangNhap], [MatKhau], [isDeleted]) VALUES (N'KH2', N'Kim Anh', N'Q Bình Thạnh TPHCM', N'0112233445', NULL, N'kh2', N'kh2', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN001', N'Kỹ năng Giao tiếp', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN002', N'Kỹ năng Tiếng anh', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN003', N'Kỹ năng Sửa chữa máy tính cá nhân', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN004', N'Kỹ năng Mạng máy tính', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN005', N'Kỹ năng Lập trình Web', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN006', N'Kỹ năng Văn nghệ', 0)
INSERT [dbo].[KYNANG] ([id], [TenKyNang], [isDeleted]) VALUES (N'KN007', N'Kỹ năng Vẽ đồ họa', 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00001', N'NV00001', N'CV003', CAST(N'2015-06-12T00:00:00' AS SmallDateTime), CAST(N'2016-05-12T00:00:00' AS SmallDateTime), 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00002', N'NV00002', N'CV002', CAST(N'2019-06-12T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00003', N'NV00003', N'CV003', CAST(N'2019-06-12T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00004', N'NV00004', N'CV004', CAST(N'2019-06-12T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00005', N'NV00005', N'CV005', CAST(N'2019-06-12T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00006', N'NV00006', N'CV006', CAST(N'2019-06-12T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00007', N'NV00001', N'CV002', CAST(N'2016-05-12T00:00:00' AS SmallDateTime), CAST(N'2017-09-24T00:00:00' AS SmallDateTime), 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00008', N'NV00001', N'CV007', CAST(N'2017-09-24T00:00:00' AS SmallDateTime), CAST(N'2018-07-13T00:00:00' AS SmallDateTime), 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00009', N'NV00001', N'CV001', CAST(N'2018-07-13T00:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00010', N'NV00007', N'CV007', CAST(N'2021-01-13T22:47:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00011', N'NV00008', N'CV009', CAST(N'2021-01-13T22:49:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00012', N'NV00009', N'CV012', CAST(N'2021-01-13T22:53:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00013', N'NV00010', N'CV012', CAST(N'2021-01-13T22:55:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00014', N'NV00011', N'CV009', CAST(N'2021-01-13T22:56:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00015', N'NV00012', N'CV012', CAST(N'2021-01-13T22:56:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00016', N'NV00013', N'CV012', CAST(N'2021-01-13T22:57:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00017', N'NV00014', N'CV012', CAST(N'2021-01-13T22:59:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LICHSUCHUCVU] ([id], [MaNV], [MaChucVu], [NgayBD], [NgayKT], [isDeleted]) VALUES (N'LS00018', N'NV00015', N'CV006', CAST(N'2021-01-13T23:00:00' AS SmallDateTime), NULL, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD001', N'Hợp đồng thử việc', 1, 5000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD002', N'Hợp đồng 3 tháng', 3, 8000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD003', N'Hợp đồng 6 tháng', 6, 9000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD004', N'Hợp đồng 9 tháng', 9, 10000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD005', N'Hợp đồng 1 năm', 12, 11000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD006', N'Hợp đồng 2 năm', 24, 11000000.0000, 0)
INSERT [dbo].[LOAIHOPDONG] ([id], [TenLoaiHD], [ThoiHan], [Luong], [isDeleted]) VALUES (N'LHD007', N'Hợp đồng 3 năm', 36, 15000000.0000, 0)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH1', N'Google Pixel - Black', N'Máy', N'img/product-1.png', N'NCC002', N'NMH002', 10000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH10', N'Samsung Galaxy Fit 2', N'Chiếc', N'img/MH10.png', N'NCC003', N'NMH003', 2300000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH11', N'Oppo Reno 5', N'Máy', N'img/MH11.png', N'NCC008', N'NMH002', 5600000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH12', N'Samsung Galaxy Watch', N'Chiếc', N'img/MH12.png', N'NCC003', N'NMH003', 3200000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH13', N'Gậy tự sướng', N'Gậy', N'img/MH13.jpg', N'NCC005', N'NMH005', 150000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH14', N'HP Pavil ion 15 i7', N'Máy', N'img/MH14.png', N'NCC007', N'NMH001', 15800000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH15', N'Redmi 9', N'Máy', N'img/MH15.png', N'NCC002', N'NMH002', 6750000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH16', N'Chuột Bluetooth', N'Cái', N'img/MH16.jpg', N'NCC002', N'NMH005', 340000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH17', N'Sạc dự phòng', N'Máy', N'img/MH17.png', N'NCC003', N'NMH005', 220000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH18', N'Apple Watch', N'Máy', N'img/MH18.png', N'NCC001', N'NMH003', 4900000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH19', N'Iphone 12 mini', N'Máy', N'img/MH19.png', N'NCC001', N'NMH001', 17500000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH2', N'Samsung S7', N'Máy', N'img/product-2.png', N'NCC003', N'NMH002', 12000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH20', N'Airpod', N'Máy', N'img/MH20.png', N'NCC001', N'NMH003', 4200000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH21', N'Acer Swift 3', N'Máy', N'img/MH21.png', N'NCC006', N'NMH001', 18200000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH22', N'Apple Macbook Air 2', N'Máy', N'img/MH22.png', N'NCC001', N'NMH001', 34000000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH23', N'Asus Vivobook', N'Máy', N'img/MH23.png', N'NCC003', N'NMH001', 23000000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH24', N'Headphone Gamming', N'Tai nghe', N'img/MH24.jpg', N'NCC009', N'NMH004', 750000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH25', N'Asus Gamming Rog', N'Máy', N'img/MH25.png', N'NCC009', N'NMH001', 32000000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH26', N'Dell Vostro 3580', N'Máy', N'img/MH26.png', N'NCC004', N'NMH001', 18000000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH27', N'Acer Aspire 3', N'Máy', N'img/MH27.png', N'NCC006', N'NMH001', 21700000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH28', N'Macbook Air 2020', N'Máy', N'img/MH28.png', N'NCC001', N'NMH001', 45000000.0000, 0, N'')
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH3', N'HTC 10 - Black', N'Máy', N'img/product-3.png', N'NCC005', N'NMH002', 14000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH4', N'HTC 10 - White', N'Máy', N'img/product-4.png', N'NCC005', N'NMH002', 8000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH5', N'HTC Desire 626s', N'Máy', N'img/product-5.png', N'NCC005', N'NMH002', 9000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH6', N'Vintage Iphone', N'Máy', N'img/product-6.png', N'NCC001', N'NMH002', 1000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH7', N'Iphone 7', N'Máy', N'img/product-7.png', N'NCC001', N'NMH002', 15000000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH8', N'Laptop Dell Inspiron 5500', N'Máy', N'img/product-8.png', N'NCC004', N'NMH001', 19200000.0000, 0, NULL)
INSERT [dbo].[MATHANG] ([id], [TenMH], [DonVi], [HinhAnh], [MaNCC], [MaNhomMH], [DonGia], [isDeleted], [MoTa]) VALUES (N'MH9', N'Samsung Galaxy Note 10', N'Máy', N'img/MH9.png', N'NCC003', N'NMH002', 9200000.0000, 0, N'')
INSERT [dbo].[MUCTHUONG] ([id], [TenMucThuong], [TienThuong], [isDeleted]) VALUES (N'MT1', N'Mức 1', 2000000.0000, 0)
INSERT [dbo].[MUCTHUONG] ([id], [TenMucThuong], [TienThuong], [isDeleted]) VALUES (N'MT2', N'Mức 2', 1200000.0000, 0)
INSERT [dbo].[MUCTHUONG] ([id], [TenMucThuong], [TienThuong], [isDeleted]) VALUES (N'MT3', N'Mức 3', 200000.0000, 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC001', N'Apple', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC002', N'Google', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC003', N'Samsung', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC004', N'Dell', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC005', N'Htc', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC006', N'Acer', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC007', N'HP', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC008', N'Oppo', N'0123456789', 0)
INSERT [dbo].[NHACUNGCAP] ([id], [TenNCC], [SDT], [isDeleted]) VALUES (N'NCC009', N'Asus', N'0123456789', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00001', N'Lê Sơn', CAST(N'2000-11-15T00:00:00' AS SmallDateTime), N'Nam', N'Đồng Nai', N'TD006', NULL, N'CV001', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00002', N'Phạm Sanh', CAST(N'2000-09-18T00:00:00' AS SmallDateTime), N'Nam', N'Phú Yên', N'TD006', NULL, N'CV002', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00003', N'Kim Thảo', CAST(N'2000-09-28T00:00:00' AS SmallDateTime), N'Nữ', N'Quảng Nam', N'TD006', NULL, N'CV003', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00004', N'Ngô Hậu', CAST(N'2000-08-22T00:00:00' AS SmallDateTime), N'Nam', N'Đồng Nai', N'TD006', NULL, N'CV004', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00005', N'Ngọc Anh', CAST(N'1995-08-07T00:00:00' AS SmallDateTime), N'Nữ', N'TP HCM', N'TD004', NULL, N'CV005', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00006', N'Tiến Linh', CAST(N'2001-05-11T00:00:00' AS SmallDateTime), N'Nam', N'Tây Ninh', N'TD005', NULL, N'CV006', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00007', N'Hồ Vân Thúy Linh', CAST(N'2000-03-18T00:00:00' AS SmallDateTime), N'Nữ', N'Trấn Biên', N'TD006', NULL, N'CV007', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00008', N'Phạm Liễu Ái Nữ Biên', CAST(N'2000-12-20T00:00:00' AS SmallDateTime), N'Nữ', N'Nghệ An', N'TD006', NULL, N'CV009', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00009', N'Hoàng Mai', CAST(N'2000-04-22T00:00:00' AS SmallDateTime), N'Nữ', N'Phú Thọ', N'TD003', NULL, N'CV012', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00010', N'Phạm Giang Hải Long', CAST(N'2003-12-06T00:00:00' AS SmallDateTime), N'Nam', N'Kiên Giang', N'TD002', NULL, N'CV012', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00011', N'Hồ Khánh An', CAST(N'2021-01-13T22:55:00' AS SmallDateTime), N'Nữ', N'TP HCM', N'TD004', NULL, N'CV009', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00012', N'Việt Quang Long', CAST(N'2021-01-23T00:00:00' AS SmallDateTime), N'Nam', N'Châu Đốc', N'TD003', NULL, N'CV012', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00013', N'Phạm Viết Thủy Tiên', CAST(N'2021-01-13T22:56:00' AS SmallDateTime), N'Nữ', N'Phù Đổng', N'TD005', NULL, N'CV012', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00014', N'Phương Anh', CAST(N'2021-01-13T22:58:00' AS SmallDateTime), N'Nữ', N'Nam Định', N'TD006', NULL, N'CV012', 0)
INSERT [dbo].[NHANVIEN] ([id], [HoTen], [NgaySinh], [GioiTinh], [NoiSinh], [MaTrinhDo], [NgayKetThuc], [MaChucVu], [isDeleted]) VALUES (N'NV00015', N'Ngô Hải', CAST(N'2021-01-13T22:59:00' AS SmallDateTime), N'Nam', N'An Giang', N'TD002', NULL, N'CV006', 0)
INSERT [dbo].[NHOMMATHANG] ([id], [TenNhomMH], [isDeleted]) VALUES (N'NMH001', N'Laptop', 0)
INSERT [dbo].[NHOMMATHANG] ([id], [TenNhomMH], [isDeleted]) VALUES (N'NMH002', N'Điện thoại', 0)
INSERT [dbo].[NHOMMATHANG] ([id], [TenNhomMH], [isDeleted]) VALUES (N'NMH003', N'Đồng hồ', 0)
INSERT [dbo].[NHOMMATHANG] ([id], [TenNhomMH], [isDeleted]) VALUES (N'NMH004', N'Loa tai nghe', 0)
INSERT [dbo].[NHOMMATHANG] ([id], [TenNhomMH], [isDeleted]) VALUES (N'NMH005', N'Khác', 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN001', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN003', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN004', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN005', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN006', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN007', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN008', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN009', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN010', N'CV001', NULL, 0)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN001', N'CV002', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV002', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN003', N'CV002', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN004', N'CV002', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN005', N'CV002', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV003', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN006', N'CV003', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV004', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN007', N'CV004', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV005', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN008', N'CV005', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV006', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN004', N'CV006', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN005', N'CV006', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN001', N'CV007', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN003', N'CV007', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN006', N'CV008', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN007', N'CV009', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN002', N'CV010', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN008', N'CV010', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN004', N'CV011', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN005', N'CV011', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN005', N'CV012', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN008', N'CV012', NULL, NULL)
INSERT [dbo].[PHANQUYEN] ([MaChucNang], [MaChucVu], [GhiChu], [isDeleted]) VALUES (N'CN010', N'CV012', NULL, NULL)
INSERT [dbo].[PHIEUDATHANG] ([id], [MaKH], [NgayDat], [ThanhTien], [TrangThai], [isDeleted], [DiaChiNhan]) VALUES (N'PDH1', N'KH1', CAST(N'2020-05-12T00:00:00' AS SmallDateTime), 22000000.0000, 1, 0, NULL)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB001', N'Ban quản trị', N'NV00001', 0)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB002', N'Phòng nhân sự', N'NV00002', 0)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB003', N'Phòng kinh doanh', N'NV00003', 0)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB004', N'Phòng kĩ thuật', N'NV00004', 0)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB005', N'Phòng kế toán', N'NV00005', 0)
INSERT [dbo].[PHONGBAN] ([id], [TenPhong], [MaTrgPB], [isDeleted]) VALUES (N'PB006', N'Phòng đào tạo', N'NV00006', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00001', N'admin', N'admin', NULL, N'NV00001', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00002', N'sanhpham', N'sanhpham', NULL, N'NV00002', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00003', N'kimthao', N'kimthao', NULL, N'NV00003', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00004', N'ngohau', N'ngohau', NULL, N'NV00004', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00005', N'ngocanh', N'ngocanh', NULL, N'NV00005', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK00006', N'tienlinh', N'tienlinh', NULL, N'NV00006', 0)
INSERT [dbo].[TAIKHOAN] ([id], [TenDangNhap], [MatKhau], [Avatar], [MaNV], [isDeleted]) VALUES (N'TK007', N'thuytien', N'thuytien', NULL, N'NV00013', 0)
INSERT [dbo].[THAMSO] ([id], [GiaTri]) VALUES (N'HeSoLamThem', 150000.0000)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD001', N'THCS', 0)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD002', N'THPT', 0)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD003', N'Kỹ thuật viên', 0)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD004', N'Trung cấp', 0)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD005', N'Cao đẳng', 0)
INSERT [dbo].[TRINHDO] ([id], [TenTrinhDo], [isDeleted]) VALUES (N'TD006', N'Đại học', 0)
INSERT [dbo].[TuVanKH] ([id], [MaKH], [CauHoi], [TraLoi], [isDeleted], [NgayDat], [NgayTraLoi], [NguoiTraLoi]) VALUES (N'TV1', N'KH1', N'Bạn có người yêu chưa', N'Tui chưa biết nè hihi', 0, CAST(N'2020-01-01T00:00:00' AS SmallDateTime), CAST(N'2020-01-08T00:00:00' AS SmallDateTime), N'NV00005')
INSERT [dbo].[TuVanKH] ([id], [MaKH], [CauHoi], [TraLoi], [isDeleted], [NgayDat], [NgayTraLoi], [NguoiTraLoi]) VALUES (N'TV2', N'KH1', N'Công ty mình có bán poster BTS không? Mình cảm ơn ạ!', N'Không nha bạn ơi! Bên mình không bán sản phẩm này ạ ', 0, CAST(N'2021-01-13T23:46:00' AS SmallDateTime), CAST(N'2021-01-13T23:50:00' AS SmallDateTime), N'NV00001')
INSERT [dbo].[TuVanKH] ([id], [MaKH], [CauHoi], [TraLoi], [isDeleted], [NgayDat], [NgayTraLoi], [NguoiTraLoi]) VALUES (N'TV3', N'KH1', N'Nếu có thì giá cả như thế nào ạ!', N'Không bán bạn ưi!', 0, CAST(N'2021-01-13T23:46:00' AS SmallDateTime), CAST(N'2021-01-13T23:51:00' AS SmallDateTime), N'NV00001')
INSERT [dbo].[TuVanKH] ([id], [MaKH], [CauHoi], [TraLoi], [isDeleted], [NgayDat], [NgayTraLoi], [NguoiTraLoi]) VALUES (N'TV4', N'KH1', N'Sản phẩm SamSung Galaxy Note 10 giá bao nhiêu vậy ạ! Mình cảm ơn nhiều!', NULL, 0, CAST(N'2021-01-13T23:52:00' AS SmallDateTime), NULL, NULL)
ALTER TABLE [dbo].[BANGLAMTHEM]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONGBAN] ([id])
GO
ALTER TABLE [dbo].[BANGLAMTHEM]  WITH CHECK ADD FOREIGN KEY([MaTrgPB])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[BANGLUONGTL]  WITH CHECK ADD FOREIGN KEY([MaKeToan])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[BANGLUONGTL]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONGBAN] ([id])
GO
ALTER TABLE [dbo].[BANGTHUONG]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PHONGBAN] ([id])
GO
ALTER TABLE [dbo].[BANGTHUONG]  WITH CHECK ADD FOREIGN KEY([MaTrgPB])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[CHUCVU]  WITH CHECK ADD FOREIGN KEY([MaPhongBan])
REFERENCES [dbo].[PHONGBAN] ([id])
GO
ALTER TABLE [dbo].[CT_BANGLAMTHEM]  WITH CHECK ADD FOREIGN KEY([MaLamThem])
REFERENCES [dbo].[BANGLAMTHEM] ([id])
GO
ALTER TABLE [dbo].[CT_BANGLAMTHEM]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD FOREIGN KEY([MaLuongTL])
REFERENCES [dbo].[BANGLUONGTL] ([id])
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[CT_BANGTHUONG]  WITH CHECK ADD FOREIGN KEY([MaMucThuong])
REFERENCES [dbo].[MUCTHUONG] ([id])
GO
ALTER TABLE [dbo].[CT_BANGTHUONG]  WITH CHECK ADD FOREIGN KEY([MaThuong])
REFERENCES [dbo].[BANGTHUONG] ([id])
GO
ALTER TABLE [dbo].[CT_BANGTHUONG]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOADON] ([id])
GO
ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD FOREIGN KEY([MaMH])
REFERENCES [dbo].[MATHANG] ([id])
GO
ALTER TABLE [dbo].[CT_PHIEUDATHANG]  WITH CHECK ADD FOREIGN KEY([MaPhieuDH])
REFERENCES [dbo].[PHIEUDATHANG] ([id])
GO
ALTER TABLE [dbo].[CT_PHIEUDATHANG]  WITH CHECK ADD FOREIGN KEY([MaMH])
REFERENCES [dbo].[MATHANG] ([id])
GO
ALTER TABLE [dbo].[DANHGIAKYNANG]  WITH CHECK ADD FOREIGN KEY([MaKyNang])
REFERENCES [dbo].[KYNANG] ([id])
GO
ALTER TABLE [dbo].[DANHGIAKYNANG]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([id])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD FOREIGN KEY([MaPhieuDH])
REFERENCES [dbo].[PHIEUDATHANG] ([id])
GO
ALTER TABLE [dbo].[HOPDONG]  WITH CHECK ADD FOREIGN KEY([MaLoaiHD])
REFERENCES [dbo].[LOAIHOPDONG] ([id])
GO
ALTER TABLE [dbo].[HOPDONG]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[LICHSUCHUCVU]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[CHUCVU] ([id])
GO
ALTER TABLE [dbo].[LICHSUCHUCVU]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([id])
GO
ALTER TABLE [dbo].[MATHANG]  WITH CHECK ADD FOREIGN KEY([MaNhomMH])
REFERENCES [dbo].[NHOMMATHANG] ([id])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[CHUCVU] ([id])
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD FOREIGN KEY([MaTrinhDo])
REFERENCES [dbo].[TRINHDO] ([id])
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD FOREIGN KEY([MaChucNang])
REFERENCES [dbo].[CHUCNANG] ([id])
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[CHUCVU] ([id])
GO
ALTER TABLE [dbo].[PHIEUDATHANG]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([id])
GO
ALTER TABLE [dbo].[PHONGBAN]  WITH CHECK ADD FOREIGN KEY([MaTrgPB])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[TuVanKH]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([id])
GO
ALTER TABLE [dbo].[TuVanKH]  WITH CHECK ADD FOREIGN KEY([NguoiTraLoi])
REFERENCES [dbo].[NHANVIEN] ([id])
GO
ALTER TABLE [dbo].[BANGLAMTHEM]  WITH CHECK ADD CHECK  (([THANG]>=(1) AND [THANG]<=(12)))
GO
ALTER TABLE [dbo].[BANGLAMTHEM]  WITH CHECK ADD CHECK  (([HeSo]>(0)))
GO
ALTER TABLE [dbo].[BANGLUONGTL]  WITH CHECK ADD CHECK  (([THANG]>=(1) AND [THANG]<=(12)))
GO
ALTER TABLE [dbo].[BANGTHUONG]  WITH CHECK ADD CHECK  (([THANG]>=(1) AND [THANG]<=(12)))
GO
ALTER TABLE [dbo].[CHUCVU]  WITH CHECK ADD CHECK  (([PhuCap]>(0)))
GO
ALTER TABLE [dbo].[CT_BANGLAMTHEM]  WITH CHECK ADD CHECK  (([SoBuoi]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLAMTHEM]  WITH CHECK ADD CHECK  (([TienLamThem]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD CHECK  (([LuongCB]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD CHECK  (([LuongLamThem]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD CHECK  (([PhuCap]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD CHECK  (([TienThuong]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGLUONGTL]  WITH CHECK ADD CHECK  (([TongLuong]>=(0)))
GO
ALTER TABLE [dbo].[CT_BANGTHUONG]  WITH CHECK ADD CHECK  (([TienThuong]>=(0)))
GO
ALTER TABLE [dbo].[LOAIHOPDONG]  WITH CHECK ADD CHECK  (([Luong]>=(0)))
GO
ALTER TABLE [dbo].[MUCTHUONG]  WITH CHECK ADD CHECK  (([TienThuong]>=(0)))
GO
USE [master]
GO
ALTER DATABASE [QLKinhDoanh] SET  READ_WRITE 
GO
