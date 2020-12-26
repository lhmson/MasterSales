
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/24/2020 09:27:48
-- Generated from EDMX file: E:\Master Store\MasterStore\MasterSaveDemo\Model\QLSieuThiModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QLSieuThi];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__CT_HOADON__MaHoa__4AB81AF0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HOADON] DROP CONSTRAINT [FK__CT_HOADON__MaHoa__4AB81AF0];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_HOADON__MaMH__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_HOADON] DROP CONSTRAINT [FK__CT_HOADON__MaMH__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUD__MaPhi__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUDNXUATKHO] DROP CONSTRAINT [FK__CT_PHIEUD__MaPhi__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUDN__MaMH__5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUDNXUATKHO] DROP CONSTRAINT [FK__CT_PHIEUDN__MaMH__5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUN__MaPhi__59FA5E80]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUNHAPKHO] DROP CONSTRAINT [FK__CT_PHIEUN__MaPhi__59FA5E80];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUNH__MaMH__59063A47]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUNHAPKHO] DROP CONSTRAINT [FK__CT_PHIEUNH__MaMH__59063A47];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUX__MaPhi__403A8C7D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUXUATKHO] DROP CONSTRAINT [FK__CT_PHIEUX__MaPhi__403A8C7D];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_PHIEUXU__MaMH__3F466844]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_PHIEUXUATKHO] DROP CONSTRAINT [FK__CT_PHIEUXU__MaMH__3F466844];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_THEKHO__MaThe__60A75C0F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_THEKHO] DROP CONSTRAINT [FK__CT_THEKHO__MaThe__60A75C0F];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_THONGK__MaTho__656C112C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_THONGKENGAY] DROP CONSTRAINT [FK__CT_THONGK__MaTho__656C112C];
GO
IF OBJECT_ID(N'[dbo].[FK__CT_THONGKE__MaMH__66603565]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CT_THONGKENGAY] DROP CONSTRAINT [FK__CT_THONGKE__MaMH__66603565];
GO
IF OBJECT_ID(N'[dbo].[FK__HOADON__MaNguoiL__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOADON] DROP CONSTRAINT [FK__HOADON__MaNguoiL__46E78A0C];
GO
IF OBJECT_ID(N'[dbo].[FK__HOADON__MaQuay__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HOADON] DROP CONSTRAINT [FK__HOADON__MaQuay__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__MATHANG__MaNCC__36B12243]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MATHANG] DROP CONSTRAINT [FK__MATHANG__MaNCC__36B12243];
GO
IF OBJECT_ID(N'[dbo].[FK__MATHANG__MaNSX__37A5467C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MATHANG] DROP CONSTRAINT [FK__MATHANG__MaNSX__37A5467C];
GO
IF OBJECT_ID(N'[dbo].[FK__NGUOIDUNG__MaNho__2A4B4B5E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[NGUOIDUNG] DROP CONSTRAINT [FK__NGUOIDUNG__MaNho__2A4B4B5E];
GO
IF OBJECT_ID(N'[dbo].[FK__PHANQUYEN__MaChu__300424B4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHANQUYEN] DROP CONSTRAINT [FK__PHANQUYEN__MaChu__300424B4];
GO
IF OBJECT_ID(N'[dbo].[FK__PHANQUYEN__MaNho__2F10007B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHANQUYEN] DROP CONSTRAINT [FK__PHANQUYEN__MaNho__2F10007B];
GO
IF OBJECT_ID(N'[dbo].[FK__PHIEUDNXU__MaQua__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEUDNXUATKHO] DROP CONSTRAINT [FK__PHIEUDNXU__MaQua__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__PHIEUNHAP__MaNCC__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEUNHAPKHO] DROP CONSTRAINT [FK__PHIEUNHAP__MaNCC__5441852A];
GO
IF OBJECT_ID(N'[dbo].[FK__PHIEUNHAP__MaNgu__5629CD9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEUNHAPKHO] DROP CONSTRAINT [FK__PHIEUNHAP__MaNgu__5629CD9C];
GO
IF OBJECT_ID(N'[dbo].[FK__PHIEUXUAT__MaNgu__3C69FB99]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PHIEUXUATKHO] DROP CONSTRAINT [FK__PHIEUXUAT__MaNgu__3C69FB99];
GO
IF OBJECT_ID(N'[dbo].[FK__THEKHO__MaMH__5DCAEF64]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THEKHO] DROP CONSTRAINT [FK__THEKHO__MaMH__5DCAEF64];
GO
IF OBJECT_ID(N'[dbo].[FK__THEKHO__MaNguoiL__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[THEKHO] DROP CONSTRAINT [FK__THEKHO__MaNguoiL__5CD6CB2B];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CT_HOADON]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_HOADON];
GO
IF OBJECT_ID(N'[dbo].[CT_PHIEUDNXUATKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_PHIEUDNXUATKHO];
GO
IF OBJECT_ID(N'[dbo].[CT_PHIEUNHAPKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_PHIEUNHAPKHO];
GO
IF OBJECT_ID(N'[dbo].[CT_PHIEUXUATKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_PHIEUXUATKHO];
GO
IF OBJECT_ID(N'[dbo].[CT_THEKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_THEKHO];
GO
IF OBJECT_ID(N'[dbo].[CT_THONGKENGAY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CT_THONGKENGAY];
GO
IF OBJECT_ID(N'[dbo].[CHUCNANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CHUCNANG];
GO
IF OBJECT_ID(N'[dbo].[HOADON]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HOADON];
GO
IF OBJECT_ID(N'[dbo].[MATHANG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MATHANG];
GO
IF OBJECT_ID(N'[dbo].[NGUOIDUNG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NGUOIDUNG];
GO
IF OBJECT_ID(N'[dbo].[NHACUNGCAP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NHACUNGCAP];
GO
IF OBJECT_ID(N'[dbo].[NHANVIEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NHANVIEN];
GO
IF OBJECT_ID(N'[dbo].[NHASANXUAT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NHASANXUAT];
GO
IF OBJECT_ID(N'[dbo].[NHOMNGUOIDUNG]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NHOMNGUOIDUNG];
GO
IF OBJECT_ID(N'[dbo].[PHANQUYEN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHANQUYEN];
GO
IF OBJECT_ID(N'[dbo].[PHIEUDNXUATKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHIEUDNXUATKHO];
GO
IF OBJECT_ID(N'[dbo].[PHIEUNHAPKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHIEUNHAPKHO];
GO
IF OBJECT_ID(N'[dbo].[PHIEUXUATKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PHIEUXUATKHO];
GO
IF OBJECT_ID(N'[dbo].[QUAY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[QUAY];
GO
IF OBJECT_ID(N'[dbo].[THAMSO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THAMSO];
GO
IF OBJECT_ID(N'[dbo].[THEKHO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THEKHO];
GO
IF OBJECT_ID(N'[dbo].[THONGBAO]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THONGBAO];
GO
IF OBJECT_ID(N'[dbo].[THONGKENGAY]', 'U') IS NOT NULL
    DROP TABLE [dbo].[THONGKENGAY];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CHUCNANGs'
CREATE TABLE [dbo].[CHUCNANGs] (
    [MaChucNang] int  NOT NULL,
    [TenChucNang] nvarchar(50)  NOT NULL,
    [TenThanhPhanSuDung] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CT_HOADON'
CREATE TABLE [dbo].[CT_HOADON] (
    [MaChiTietHoaDon] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL,
    [MaHoaDon] varchar(10)  NOT NULL,
    [SoLuong] int  NOT NULL,
    [DonGiaBan] decimal(19,4)  NOT NULL,
    [GhiChu] nvarchar(50)  NULL
);
GO

-- Creating table 'CT_PHIEUDNXUATKHO'
CREATE TABLE [dbo].[CT_PHIEUDNXUATKHO] (
    [MaCTPhieuDNXK] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL,
    [MaPhieuDNXK] varchar(10)  NOT NULL,
    [DonGia] decimal(19,4)  NOT NULL,
    [SoLuong] int  NOT NULL,
    [GhiChu] nvarchar(50)  NULL
);
GO

-- Creating table 'CT_PHIEUNHAPKHO'
CREATE TABLE [dbo].[CT_PHIEUNHAPKHO] (
    [MaCTPhieuNK] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL,
    [DonGiaNhap] decimal(19,4)  NOT NULL,
    [SoLuong] int  NOT NULL,
    [MaPhieuNhapKho] varchar(10)  NOT NULL
);
GO

-- Creating table 'CT_PHIEUXUATKHO'
CREATE TABLE [dbo].[CT_PHIEUXUATKHO] (
    [MaCTPhieuXK] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL,
    [MaPhieuXK] varchar(10)  NOT NULL,
    [DonGia] decimal(19,4)  NOT NULL,
    [SoLuong] int  NOT NULL,
    [GhiChu] nvarchar(50)  NULL
);
GO

-- Creating table 'CT_THEKHO'
CREATE TABLE [dbo].[CT_THEKHO] (
    [MaCTTheKho] varchar(10)  NOT NULL,
    [NgayNhapXuat] datetime  NOT NULL,
    [MaPhieuNhapXuat] varchar(10)  NOT NULL,
    [DienGiai] nvarchar(50)  NULL,
    [MaTheKho] varchar(10)  NOT NULL
);
GO

-- Creating table 'CT_THONGKENGAY'
CREATE TABLE [dbo].[CT_THONGKENGAY] (
    [MaCTTK] varchar(10)  NOT NULL,
    [MaThongKe] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL,
    [Nhap] int  NOT NULL,
    [Xuat] int  NOT NULL,
    [Ton] int  NOT NULL
);
GO

-- Creating table 'HOADONs'
CREATE TABLE [dbo].[HOADONs] (
    [MaHoaDon] varchar(10)  NOT NULL,
    [NgayLap] datetime  NOT NULL,
    [ThoiGian] time  NOT NULL,
    [MaQuay] varchar(10)  NOT NULL,
    [TongTien] decimal(19,4)  NOT NULL,
    [MaNguoiLap] varchar(10)  NOT NULL
);
GO

-- Creating table 'MATHANGs'
CREATE TABLE [dbo].[MATHANGs] (
    [MaMH] varchar(10)  NOT NULL,
    [TenMH] nvarchar(max)  NOT NULL,
    [MaNCC] varchar(10)  NOT NULL,
    [MaNSX] varchar(10)  NOT NULL,
    [GiaNhap] decimal(19,4)  NOT NULL,
    [GiaBan] decimal(19,4)  NOT NULL,
    [SoLuongTonGian] int  NOT NULL,
    [DonViTinh] nvarchar(max)  NOT NULL,
    [image] nvarchar(max)  NULL
);
GO

-- Creating table 'NGUOIDUNGs'
CREATE TABLE [dbo].[NGUOIDUNGs] (
    [MaNguoiDung] varchar(10)  NOT NULL,
    [TenDangNhap] varchar(50)  NOT NULL,
    [MatKhau] varchar(50)  NOT NULL,
    [MaNhom] int  NOT NULL
);
GO

-- Creating table 'NHACUNGCAPs'
CREATE TABLE [dbo].[NHACUNGCAPs] (
    [MaNCC] varchar(10)  NOT NULL,
    [TenNCC] nvarchar(max)  NOT NULL,
    [DiaChi] nvarchar(max)  NOT NULL,
    [SDT] nvarchar(max)  NOT NULL,
    [Fax] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NHANVIENs'
CREATE TABLE [dbo].[NHANVIENs] (
    [MaNguoiDung] varchar(10)  NOT NULL,
    [HoTen] nvarchar(max)  NOT NULL,
    [DiaChi] nvarchar(max)  NOT NULL,
    [SDT] nvarchar(max)  NOT NULL,
    [GioiTinh] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NHASANXUATs'
CREATE TABLE [dbo].[NHASANXUATs] (
    [MaNSX] varchar(10)  NOT NULL,
    [TenNSX] nvarchar(max)  NOT NULL,
    [DiaChi] nvarchar(max)  NOT NULL,
    [SDT] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NHOMNGUOIDUNGs'
CREATE TABLE [dbo].[NHOMNGUOIDUNGs] (
    [MaNhom] int  NOT NULL,
    [TenNhom] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'PHANQUYENs'
CREATE TABLE [dbo].[PHANQUYENs] (
    [MaNhom] int  NOT NULL,
    [MaChucNang] int  NOT NULL,
    [GhiChu] nvarchar(50)  NULL
);
GO

-- Creating table 'PHIEUDNXUATKHOes'
CREATE TABLE [dbo].[PHIEUDNXUATKHOes] (
    [MaPhieuDNXK] varchar(10)  NOT NULL,
    [NgayLap] datetime  NOT NULL,
    [MaQuay] varchar(10)  NOT NULL
);
GO

-- Creating table 'PHIEUNHAPKHOes'
CREATE TABLE [dbo].[PHIEUNHAPKHOes] (
    [MaPhieuNhapKho] varchar(10)  NOT NULL,
    [NgayLap] datetime  NOT NULL,
    [MaNCC] varchar(10)  NOT NULL,
    [TongTien] decimal(19,4)  NOT NULL,
    [MaNguoiLap] varchar(10)  NOT NULL,
    [Duyet] int  NOT NULL
);
GO

-- Creating table 'PHIEUXUATKHOes'
CREATE TABLE [dbo].[PHIEUXUATKHOes] (
    [MaPhieuXK] varchar(10)  NOT NULL,
    [NgayLap] datetime  NOT NULL,
    [MaNguoiLap] varchar(10)  NOT NULL
);
GO

-- Creating table 'QUAYs'
CREATE TABLE [dbo].[QUAYs] (
    [MaQuay] varchar(10)  NOT NULL,
    [TenQuay] nvarchar(max)  NOT NULL,
    [DangSuDung] int  NOT NULL
);
GO

-- Creating table 'THAMSOes'
CREATE TABLE [dbo].[THAMSOes] (
    [MaThamSo] int  NOT NULL,
    [TenThamSo] nvarchar(50)  NOT NULL,
    [GiaTri] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'THEKHOes'
CREATE TABLE [dbo].[THEKHOes] (
    [MaTheKho] varchar(10)  NOT NULL,
    [NgayLap] datetime  NOT NULL,
    [MaNguoiLap] varchar(10)  NOT NULL,
    [MaMH] varchar(10)  NOT NULL
);
GO

-- Creating table 'THONGBAOs'
CREATE TABLE [dbo].[THONGBAOs] (
    [MaThongBao] varchar(10)  NOT NULL,
    [LoaiThongBao] int  NOT NULL,
    [MaPhieuNhapXuat] varchar(10)  NOT NULL,
    [DaXem] int  NOT NULL
);
GO

-- Creating table 'THONGKENGAYs'
CREATE TABLE [dbo].[THONGKENGAYs] (
    [MaThongKe] varchar(10)  NOT NULL,
    [Ngay] datetime  NOT NULL,
    [TongDoanhThu] decimal(19,4)  NOT NULL,
    [TongChi] decimal(19,4)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaChucNang] in table 'CHUCNANGs'
ALTER TABLE [dbo].[CHUCNANGs]
ADD CONSTRAINT [PK_CHUCNANGs]
    PRIMARY KEY CLUSTERED ([MaChucNang] ASC);
GO

-- Creating primary key on [MaChiTietHoaDon] in table 'CT_HOADON'
ALTER TABLE [dbo].[CT_HOADON]
ADD CONSTRAINT [PK_CT_HOADON]
    PRIMARY KEY CLUSTERED ([MaChiTietHoaDon] ASC);
GO

-- Creating primary key on [MaCTPhieuDNXK] in table 'CT_PHIEUDNXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUDNXUATKHO]
ADD CONSTRAINT [PK_CT_PHIEUDNXUATKHO]
    PRIMARY KEY CLUSTERED ([MaCTPhieuDNXK] ASC);
GO

-- Creating primary key on [MaCTPhieuNK] in table 'CT_PHIEUNHAPKHO'
ALTER TABLE [dbo].[CT_PHIEUNHAPKHO]
ADD CONSTRAINT [PK_CT_PHIEUNHAPKHO]
    PRIMARY KEY CLUSTERED ([MaCTPhieuNK] ASC);
GO

-- Creating primary key on [MaCTPhieuXK] in table 'CT_PHIEUXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUXUATKHO]
ADD CONSTRAINT [PK_CT_PHIEUXUATKHO]
    PRIMARY KEY CLUSTERED ([MaCTPhieuXK] ASC);
GO

-- Creating primary key on [MaCTTheKho] in table 'CT_THEKHO'
ALTER TABLE [dbo].[CT_THEKHO]
ADD CONSTRAINT [PK_CT_THEKHO]
    PRIMARY KEY CLUSTERED ([MaCTTheKho] ASC);
GO

-- Creating primary key on [MaCTTK] in table 'CT_THONGKENGAY'
ALTER TABLE [dbo].[CT_THONGKENGAY]
ADD CONSTRAINT [PK_CT_THONGKENGAY]
    PRIMARY KEY CLUSTERED ([MaCTTK] ASC);
GO

-- Creating primary key on [MaHoaDon] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [PK_HOADONs]
    PRIMARY KEY CLUSTERED ([MaHoaDon] ASC);
GO

-- Creating primary key on [MaMH] in table 'MATHANGs'
ALTER TABLE [dbo].[MATHANGs]
ADD CONSTRAINT [PK_MATHANGs]
    PRIMARY KEY CLUSTERED ([MaMH] ASC);
GO

-- Creating primary key on [MaNguoiDung] in table 'NGUOIDUNGs'
ALTER TABLE [dbo].[NGUOIDUNGs]
ADD CONSTRAINT [PK_NGUOIDUNGs]
    PRIMARY KEY CLUSTERED ([MaNguoiDung] ASC);
GO

-- Creating primary key on [MaNCC] in table 'NHACUNGCAPs'
ALTER TABLE [dbo].[NHACUNGCAPs]
ADD CONSTRAINT [PK_NHACUNGCAPs]
    PRIMARY KEY CLUSTERED ([MaNCC] ASC);
GO

-- Creating primary key on [MaNguoiDung] in table 'NHANVIENs'
ALTER TABLE [dbo].[NHANVIENs]
ADD CONSTRAINT [PK_NHANVIENs]
    PRIMARY KEY CLUSTERED ([MaNguoiDung] ASC);
GO

-- Creating primary key on [MaNSX] in table 'NHASANXUATs'
ALTER TABLE [dbo].[NHASANXUATs]
ADD CONSTRAINT [PK_NHASANXUATs]
    PRIMARY KEY CLUSTERED ([MaNSX] ASC);
GO

-- Creating primary key on [MaNhom] in table 'NHOMNGUOIDUNGs'
ALTER TABLE [dbo].[NHOMNGUOIDUNGs]
ADD CONSTRAINT [PK_NHOMNGUOIDUNGs]
    PRIMARY KEY CLUSTERED ([MaNhom] ASC);
GO

-- Creating primary key on [MaNhom], [MaChucNang] in table 'PHANQUYENs'
ALTER TABLE [dbo].[PHANQUYENs]
ADD CONSTRAINT [PK_PHANQUYENs]
    PRIMARY KEY CLUSTERED ([MaNhom], [MaChucNang] ASC);
GO

-- Creating primary key on [MaPhieuDNXK] in table 'PHIEUDNXUATKHOes'
ALTER TABLE [dbo].[PHIEUDNXUATKHOes]
ADD CONSTRAINT [PK_PHIEUDNXUATKHOes]
    PRIMARY KEY CLUSTERED ([MaPhieuDNXK] ASC);
GO

-- Creating primary key on [MaPhieuNhapKho] in table 'PHIEUNHAPKHOes'
ALTER TABLE [dbo].[PHIEUNHAPKHOes]
ADD CONSTRAINT [PK_PHIEUNHAPKHOes]
    PRIMARY KEY CLUSTERED ([MaPhieuNhapKho] ASC);
GO

-- Creating primary key on [MaPhieuXK] in table 'PHIEUXUATKHOes'
ALTER TABLE [dbo].[PHIEUXUATKHOes]
ADD CONSTRAINT [PK_PHIEUXUATKHOes]
    PRIMARY KEY CLUSTERED ([MaPhieuXK] ASC);
GO

-- Creating primary key on [MaQuay] in table 'QUAYs'
ALTER TABLE [dbo].[QUAYs]
ADD CONSTRAINT [PK_QUAYs]
    PRIMARY KEY CLUSTERED ([MaQuay] ASC);
GO

-- Creating primary key on [MaThamSo] in table 'THAMSOes'
ALTER TABLE [dbo].[THAMSOes]
ADD CONSTRAINT [PK_THAMSOes]
    PRIMARY KEY CLUSTERED ([MaThamSo] ASC);
GO

-- Creating primary key on [MaTheKho] in table 'THEKHOes'
ALTER TABLE [dbo].[THEKHOes]
ADD CONSTRAINT [PK_THEKHOes]
    PRIMARY KEY CLUSTERED ([MaTheKho] ASC);
GO

-- Creating primary key on [MaThongBao] in table 'THONGBAOs'
ALTER TABLE [dbo].[THONGBAOs]
ADD CONSTRAINT [PK_THONGBAOs]
    PRIMARY KEY CLUSTERED ([MaThongBao] ASC);
GO

-- Creating primary key on [MaThongKe] in table 'THONGKENGAYs'
ALTER TABLE [dbo].[THONGKENGAYs]
ADD CONSTRAINT [PK_THONGKENGAYs]
    PRIMARY KEY CLUSTERED ([MaThongKe] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaChucNang] in table 'PHANQUYENs'
ALTER TABLE [dbo].[PHANQUYENs]
ADD CONSTRAINT [FK__PHANQUYEN__MaChu__4316F928]
    FOREIGN KEY ([MaChucNang])
    REFERENCES [dbo].[CHUCNANGs]
        ([MaChucNang])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHANQUYEN__MaChu__4316F928'
CREATE INDEX [IX_FK__PHANQUYEN__MaChu__4316F928]
ON [dbo].[PHANQUYENs]
    ([MaChucNang]);
GO

-- Creating foreign key on [MaHoaDon] in table 'CT_HOADON'
ALTER TABLE [dbo].[CT_HOADON]
ADD CONSTRAINT [FK__CT_HOADON__MaHoa__5DCAEF64]
    FOREIGN KEY ([MaHoaDon])
    REFERENCES [dbo].[HOADONs]
        ([MaHoaDon])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_HOADON__MaHoa__5DCAEF64'
CREATE INDEX [IX_FK__CT_HOADON__MaHoa__5DCAEF64]
ON [dbo].[CT_HOADON]
    ([MaHoaDon]);
GO

-- Creating foreign key on [MaMH] in table 'CT_HOADON'
ALTER TABLE [dbo].[CT_HOADON]
ADD CONSTRAINT [FK__CT_HOADON__MaMH__5CD6CB2B]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_HOADON__MaMH__5CD6CB2B'
CREATE INDEX [IX_FK__CT_HOADON__MaMH__5CD6CB2B]
ON [dbo].[CT_HOADON]
    ([MaMH]);
GO

-- Creating foreign key on [MaPhieuDNXK] in table 'CT_PHIEUDNXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUDNXUATKHO]
ADD CONSTRAINT [FK__CT_PHIEUD__MaPhi__6477ECF3]
    FOREIGN KEY ([MaPhieuDNXK])
    REFERENCES [dbo].[PHIEUDNXUATKHOes]
        ([MaPhieuDNXK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUD__MaPhi__6477ECF3'
CREATE INDEX [IX_FK__CT_PHIEUD__MaPhi__6477ECF3]
ON [dbo].[CT_PHIEUDNXUATKHO]
    ([MaPhieuDNXK]);
GO

-- Creating foreign key on [MaMH] in table 'CT_PHIEUDNXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUDNXUATKHO]
ADD CONSTRAINT [FK__CT_PHIEUDN__MaMH__6383C8BA]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUDN__MaMH__6383C8BA'
CREATE INDEX [IX_FK__CT_PHIEUDN__MaMH__6383C8BA]
ON [dbo].[CT_PHIEUDNXUATKHO]
    ([MaMH]);
GO

-- Creating foreign key on [MaPhieuNhapKho] in table 'CT_PHIEUNHAPKHO'
ALTER TABLE [dbo].[CT_PHIEUNHAPKHO]
ADD CONSTRAINT [FK__CT_PHIEUN__MaPhi__6D0D32F4]
    FOREIGN KEY ([MaPhieuNhapKho])
    REFERENCES [dbo].[PHIEUNHAPKHOes]
        ([MaPhieuNhapKho])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUN__MaPhi__6D0D32F4'
CREATE INDEX [IX_FK__CT_PHIEUN__MaPhi__6D0D32F4]
ON [dbo].[CT_PHIEUNHAPKHO]
    ([MaPhieuNhapKho]);
GO

-- Creating foreign key on [MaMH] in table 'CT_PHIEUNHAPKHO'
ALTER TABLE [dbo].[CT_PHIEUNHAPKHO]
ADD CONSTRAINT [FK__CT_PHIEUNH__MaMH__6C190EBB]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUNH__MaMH__6C190EBB'
CREATE INDEX [IX_FK__CT_PHIEUNH__MaMH__6C190EBB]
ON [dbo].[CT_PHIEUNHAPKHO]
    ([MaMH]);
GO

-- Creating foreign key on [MaPhieuXK] in table 'CT_PHIEUXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUXUATKHO]
ADD CONSTRAINT [FK__CT_PHIEUX__MaPhi__534D60F1]
    FOREIGN KEY ([MaPhieuXK])
    REFERENCES [dbo].[PHIEUXUATKHOes]
        ([MaPhieuXK])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUX__MaPhi__534D60F1'
CREATE INDEX [IX_FK__CT_PHIEUX__MaPhi__534D60F1]
ON [dbo].[CT_PHIEUXUATKHO]
    ([MaPhieuXK]);
GO

-- Creating foreign key on [MaMH] in table 'CT_PHIEUXUATKHO'
ALTER TABLE [dbo].[CT_PHIEUXUATKHO]
ADD CONSTRAINT [FK__CT_PHIEUXU__MaMH__52593CB8]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_PHIEUXU__MaMH__52593CB8'
CREATE INDEX [IX_FK__CT_PHIEUXU__MaMH__52593CB8]
ON [dbo].[CT_PHIEUXUATKHO]
    ([MaMH]);
GO

-- Creating foreign key on [MaTheKho] in table 'CT_THEKHO'
ALTER TABLE [dbo].[CT_THEKHO]
ADD CONSTRAINT [FK__CT_THEKHO__MaThe__73BA3083]
    FOREIGN KEY ([MaTheKho])
    REFERENCES [dbo].[THEKHOes]
        ([MaTheKho])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_THEKHO__MaThe__73BA3083'
CREATE INDEX [IX_FK__CT_THEKHO__MaThe__73BA3083]
ON [dbo].[CT_THEKHO]
    ([MaTheKho]);
GO

-- Creating foreign key on [MaThongKe] in table 'CT_THONGKENGAY'
ALTER TABLE [dbo].[CT_THONGKENGAY]
ADD CONSTRAINT [FK__CT_THONGK__MaTho__787EE5A0]
    FOREIGN KEY ([MaThongKe])
    REFERENCES [dbo].[THONGKENGAYs]
        ([MaThongKe])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_THONGK__MaTho__787EE5A0'
CREATE INDEX [IX_FK__CT_THONGK__MaTho__787EE5A0]
ON [dbo].[CT_THONGKENGAY]
    ([MaThongKe]);
GO

-- Creating foreign key on [MaMH] in table 'CT_THONGKENGAY'
ALTER TABLE [dbo].[CT_THONGKENGAY]
ADD CONSTRAINT [FK__CT_THONGKE__MaMH__797309D9]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__CT_THONGKE__MaMH__797309D9'
CREATE INDEX [IX_FK__CT_THONGKE__MaMH__797309D9]
ON [dbo].[CT_THONGKENGAY]
    ([MaMH]);
GO

-- Creating foreign key on [MaNguoiLap] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [FK__HOADON__MaNguoiL__59FA5E80]
    FOREIGN KEY ([MaNguoiLap])
    REFERENCES [dbo].[NHANVIENs]
        ([MaNguoiDung])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HOADON__MaNguoiL__59FA5E80'
CREATE INDEX [IX_FK__HOADON__MaNguoiL__59FA5E80]
ON [dbo].[HOADONs]
    ([MaNguoiLap]);
GO

-- Creating foreign key on [MaQuay] in table 'HOADONs'
ALTER TABLE [dbo].[HOADONs]
ADD CONSTRAINT [FK__HOADON__MaQuay__59063A47]
    FOREIGN KEY ([MaQuay])
    REFERENCES [dbo].[QUAYs]
        ([MaQuay])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HOADON__MaQuay__59063A47'
CREATE INDEX [IX_FK__HOADON__MaQuay__59063A47]
ON [dbo].[HOADONs]
    ([MaQuay]);
GO

-- Creating foreign key on [MaNCC] in table 'MATHANGs'
ALTER TABLE [dbo].[MATHANGs]
ADD CONSTRAINT [FK__MATHANG__MaNCC__49C3F6B7]
    FOREIGN KEY ([MaNCC])
    REFERENCES [dbo].[NHACUNGCAPs]
        ([MaNCC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MATHANG__MaNCC__49C3F6B7'
CREATE INDEX [IX_FK__MATHANG__MaNCC__49C3F6B7]
ON [dbo].[MATHANGs]
    ([MaNCC]);
GO

-- Creating foreign key on [MaNSX] in table 'MATHANGs'
ALTER TABLE [dbo].[MATHANGs]
ADD CONSTRAINT [FK__MATHANG__MaNSX__4AB81AF0]
    FOREIGN KEY ([MaNSX])
    REFERENCES [dbo].[NHASANXUATs]
        ([MaNSX])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__MATHANG__MaNSX__4AB81AF0'
CREATE INDEX [IX_FK__MATHANG__MaNSX__4AB81AF0]
ON [dbo].[MATHANGs]
    ([MaNSX]);
GO

-- Creating foreign key on [MaMH] in table 'THEKHOes'
ALTER TABLE [dbo].[THEKHOes]
ADD CONSTRAINT [FK__THEKHO__MaMH__70DDC3D8]
    FOREIGN KEY ([MaMH])
    REFERENCES [dbo].[MATHANGs]
        ([MaMH])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__THEKHO__MaMH__70DDC3D8'
CREATE INDEX [IX_FK__THEKHO__MaMH__70DDC3D8]
ON [dbo].[THEKHOes]
    ([MaMH]);
GO

-- Creating foreign key on [MaNhom] in table 'NGUOIDUNGs'
ALTER TABLE [dbo].[NGUOIDUNGs]
ADD CONSTRAINT [FK__NGUOIDUNG__MaNho__3D5E1FD2]
    FOREIGN KEY ([MaNhom])
    REFERENCES [dbo].[NHOMNGUOIDUNGs]
        ([MaNhom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__NGUOIDUNG__MaNho__3D5E1FD2'
CREATE INDEX [IX_FK__NGUOIDUNG__MaNho__3D5E1FD2]
ON [dbo].[NGUOIDUNGs]
    ([MaNhom]);
GO

-- Creating foreign key on [MaNguoiLap] in table 'PHIEUNHAPKHOes'
ALTER TABLE [dbo].[PHIEUNHAPKHOes]
ADD CONSTRAINT [FK__PHIEUNHAP__MaNgu__693CA210]
    FOREIGN KEY ([MaNguoiLap])
    REFERENCES [dbo].[NGUOIDUNGs]
        ([MaNguoiDung])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHIEUNHAP__MaNgu__693CA210'
CREATE INDEX [IX_FK__PHIEUNHAP__MaNgu__693CA210]
ON [dbo].[PHIEUNHAPKHOes]
    ([MaNguoiLap]);
GO

-- Creating foreign key on [MaNguoiLap] in table 'PHIEUXUATKHOes'
ALTER TABLE [dbo].[PHIEUXUATKHOes]
ADD CONSTRAINT [FK__PHIEUXUAT__MaNgu__4F7CD00D]
    FOREIGN KEY ([MaNguoiLap])
    REFERENCES [dbo].[NGUOIDUNGs]
        ([MaNguoiDung])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHIEUXUAT__MaNgu__4F7CD00D'
CREATE INDEX [IX_FK__PHIEUXUAT__MaNgu__4F7CD00D]
ON [dbo].[PHIEUXUATKHOes]
    ([MaNguoiLap]);
GO

-- Creating foreign key on [MaNguoiLap] in table 'THEKHOes'
ALTER TABLE [dbo].[THEKHOes]
ADD CONSTRAINT [FK__THEKHO__MaNguoiL__6FE99F9F]
    FOREIGN KEY ([MaNguoiLap])
    REFERENCES [dbo].[NGUOIDUNGs]
        ([MaNguoiDung])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__THEKHO__MaNguoiL__6FE99F9F'
CREATE INDEX [IX_FK__THEKHO__MaNguoiL__6FE99F9F]
ON [dbo].[THEKHOes]
    ([MaNguoiLap]);
GO

-- Creating foreign key on [MaNCC] in table 'PHIEUNHAPKHOes'
ALTER TABLE [dbo].[PHIEUNHAPKHOes]
ADD CONSTRAINT [FK__PHIEUNHAP__MaNCC__6754599E]
    FOREIGN KEY ([MaNCC])
    REFERENCES [dbo].[NHACUNGCAPs]
        ([MaNCC])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHIEUNHAP__MaNCC__6754599E'
CREATE INDEX [IX_FK__PHIEUNHAP__MaNCC__6754599E]
ON [dbo].[PHIEUNHAPKHOes]
    ([MaNCC]);
GO

-- Creating foreign key on [MaNhom] in table 'PHANQUYENs'
ALTER TABLE [dbo].[PHANQUYENs]
ADD CONSTRAINT [FK__PHANQUYEN__MaNho__4222D4EF]
    FOREIGN KEY ([MaNhom])
    REFERENCES [dbo].[NHOMNGUOIDUNGs]
        ([MaNhom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaQuay] in table 'PHIEUDNXUATKHOes'
ALTER TABLE [dbo].[PHIEUDNXUATKHOes]
ADD CONSTRAINT [FK__PHIEUDNXU__MaQua__60A75C0F]
    FOREIGN KEY ([MaQuay])
    REFERENCES [dbo].[QUAYs]
        ([MaQuay])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PHIEUDNXU__MaQua__60A75C0F'
CREATE INDEX [IX_FK__PHIEUDNXU__MaQua__60A75C0F]
ON [dbo].[PHIEUDNXUATKHOes]
    ([MaQuay]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------