﻿--- Tao DATABASE 
CREATE DATABASE QLKinhDoanh
GO
USE QLKinhDoanh
GO
--- Tao cac bang quan ly nhan su
CREATE TABLE THAMSO
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenThamSo VARCHAR(20) NOT NULL,
	GiaTri NVARCHAR(50) NOT NULL,
)
GO
CREATE TABLE TRINHDO
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenTrinhDo NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE NHANVIEN
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	HoTen NVARCHAR(50),
	NgaySinh SMALLDATETIME,
	GioiTinh NVARCHAR(50),
	NoiSinh NVARCHAR(50),
	MaTrinhDo VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES TRINHDO(id),
	NgayKetThuc SMALLDATETIME,
	isDeleted BIT,
)
GO
CREATE TABLE PHONGBAN
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenPhong NVARCHAR(50),
	MaTrgPB VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	isDeleted BIT,
)
GO
CREATE TABLE CHUCVU
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenChucVu NVARCHAR(50),
	MaPhongBan VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHONGBAN(id),
	PhuCap MONEY NOT NULL CHECK (PhuCap>0),
	isDeleted BIT,
)
GO
CREATE TABLE LICHSUCHUCVU
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
	NgayBD SMALLDATETIME NOT NULL,
	NgayKT SMALLDATETIME NOT NULL,
	isDeleted BIT,
)
GO
ALTER TABLE LICHSUCHUCVU ADD CHECK(NgayKT>=NgayBD);
GO
CREATE TABLE LOAIHOPDONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenLoaiHD NVARCHAR(50) NOT NULL,
	ThoiHan SMALLDATETIME NOT NULL,
	Luong MONEY CHECK (Luong >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE HOPDONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	TenHD SMALLDATETIME NOT NULL,
	NgayHD SMALLDATETIME NOT NULL,
	NgayKT SMALLDATETIME NOT NULL,
	MaLoaiHD  VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOAIHOPDONG(id),
	LuongCB MONEY NOT NULL CHECK (LuongCB>=0),
	isDeleted BIT,
)
GO
ALTER TABLE HOPDONG ADD CHECK(NgayKT>=NgayHD);
GO
CREATE TABLE MUCTHUONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenMucThuong NVARCHAR(50) NOT NULL,
	TienThuong MONEY CHECK (TienThuong >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE KYNANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenKyNang NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE DANHGIAKYNANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	MaKyNang VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES KYNANG(id),
	LoaiDanhGia NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE BANGLAMTHEM
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaTrgPB VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME NOT NULL,
	Thang INT NOT NULL CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHONGBAN(id),
	HeSo MONEY NOT NULL CHECK (HeSo > 0),
	isDeleted BIT,
)
GO
CREATE TABLE BANGTHUONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaTrgPB VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME NOT NULL,
	Thang INT NOT NULL CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHONGBAN(id),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGLAMTHEM
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaLamThem VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES BANGLAMTHEM(id),
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	SoBuoi INT NOT NULL CHECK (SoBuoi >= 0),
	TienLamThem MONEY NOT NULL CHECK (TienLamThem >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGTHUONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaThuong VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES BANGTHUONG(id),
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	MaMucThuong VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES MUCTHUONG(id),
	TienThuong MONEY NOT NULL CHECK (TienThuong >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE BANGLUONGTL
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaKeToan VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME NOT NULL,
    Thang INT NOT NULL CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHONGBAN(id),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGLUONGTL
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaLuongTL VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES BANGLUONGTL(id),
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	LuongCB MONEY NOT NULL CHECK (LuongCB >= 0),
	TienThuong MONEY NOT NULL CHECK (TienThuong >= 0),
	LuongLamThem MONEY NOT NULL CHECK (LuongLamThem >= 0),
	PhuCap MONEY NOT NULL CHECK (PhuCap >= 0),
	TongLuong MONEY NOT NULL CHECK (TongLuong >= 0),
	isDeleted BIT,
)
GO
--- BAN HANG
CREATE TABLE NHACUNGCAP
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNCC NVARCHAR(50) NOT NULL,
	SDT VARCHAR(20),
	isDeleted BIT,
)
GO
CREATE TABLE KHACHHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenKH NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(50) NOT NULL,
	SDT VARCHAR(20),
	Avatar VARCHAR(1000),
	TenDangNhap VARCHAR(50),
	MatKhau VARCHAR (50),
	isDeleted BIT,
)
GO

CREATE TABLE TuVanKH
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaKH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(id),
	CauHoi NVARCHAR (1000),
	TraLoi NVARCHAR (1000),
	isDeleted BIT,
)
GO

CREATE TABLE NHOMMATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNhomMH NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE MATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenMH NVARCHAR(50) NOT NULL,
	DonVi NVARCHAR(50) NOT NULL,
	HinhAnh VARCHAR(1000),
	MaNCC VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHACUNGCAP(id),
	MaNhomMH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHOMMATHANG(id),
	DonGia MONEY NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE PHIEUDATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaKH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(id),
	NgayDat SMALLDATETIME NOT NULL,
	ThanhTien MONEY NOT NULL,
	TrangThai INT NOT NULL ,
	isDeleted BIT,
)
GO
CREATE TABLE CT_PHIEUDATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaPhieuDH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHIEUDATHANG(id),
	MaMH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES MATHANG(id),
	SLDat INT NOT NULL,
	DonGia MONEY NOT NULL ,
	TongTien MONEY NOT NULL ,
	isDeleted BIT,
)
GO
CREATE TABLE HOADON
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaPhieuDH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHIEUDATHANG(id),
	NgayLap SMALLDATETIME NOT NULL,
	NgayXuat SMALLDATETIME,
	MaKH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(id),
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id) ,
	ThanhTien MONEY NOT NULL ,
	TrangThai INT NOT NULL ,
	isDeleted BIT,
)
GO
CREATE TABLE CT_HOADON
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaHD VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES HOADON(id),
	MaMH VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES MATHANG(id),
	SLMua INT NOT NULL,
	DonGia MONEY NOT NULL,
	TongTien MONEY NOT NULL,
	isDeleted BIT,
)
GO
---PHAN QUYEN
CREATE TABLE CHUCNANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenChucNang NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE TAIKHOAN
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenDangNhap VARCHAR(20) NOT NULL,
	MatKhau VARCHAR(50) NOT NULL,
	Avatar VARCHAR(1000),
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
	isDeleted BIT,
)
GO
CREATE TABLE PHANQUYEN
(
	MaChucNang VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCNANG(id),
	MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
	GhiChu NVARCHAR(50),
	isDeleted BIT,
	PRIMARY KEY(MaChucVu,MaChucNang)
)
GO

INSERT INTO TRINHDO VALUES ('TD001', N'THCS', 0)
INSERT INTO TRINHDO VALUES ('TD002', N'THPT', 0)
INSERT INTO TRINHDO VALUES ('TD003', N'Kỹ thuật viên', 0)
INSERT INTO TRINHDO VALUES ('TD004', N'Trung cấp', 0)
INSERT INTO TRINHDO VALUES ('TD005', N'Cao đẳng', 0)
INSERT INTO TRINHDO VALUES ('TD006', N'Đại học', 0)
GO

INSERT INTO NHANVIEN VALUES ('NV00001', N'Lê Sơn', '11/15/2000', N'Nam', N'Đồng Nai', 'TD006', null, 0)
INSERT INTO NHANVIEN VALUES ('NV00002', N'Phạm Sanh', '09/18/2000', N'Nam', N'Phú Yên', 'TD006', null, 0)
INSERT INTO NHANVIEN VALUES ('NV00003', N'Kim Thảo', '09/28/2000', N'Nữ', N'Quảng Nam', 'TD006', null, 0)
INSERT INTO NHANVIEN VALUES ('NV00004', N'Ngô Hậu', '08/22/2000', N'Nam', N'Đồng Nai', 'TD006', null, 0)
INSERT INTO NHANVIEN VALUES ('NV00005', N'Ngọc Anh', '08/07/1995', N'Nữ', N'TP HCM', 'TD004', null, 0)
INSERT INTO NHANVIEN VALUES ('NV00006', N'Tiến Linh', '05/11/2001', N'Nam', N'Tây Ninh', 'TD005', null, 0)
GO

INSERT INTO PHONGBAN VALUES ('PB001', N'Ban quản trị', 'NV00001', 0)
INSERT INTO PHONGBAN VALUES ('PB002', N'Phòng nhân sự', 'NV00002', 0)
INSERT INTO PHONGBAN VALUES ('PB003', N'Phòng kinh doanh', 'NV00003', 0)
INSERT INTO PHONGBAN VALUES ('PB004', N'Phòng kĩ thuật', 'NV00004', 0)
INSERT INTO PHONGBAN VALUES ('PB005', N'Phòng kế toán', 'NV00005', 0)
INSERT INTO PHONGBAN VALUES ('PB006', N'Phòng đào tạo', 'NV00006', 0)
GO

INSERT INTO CHUCVU VALUES ('CV001', N'Giám đốc điều hành', 'PB001', 5600000, 0)
INSERT INTO CHUCVU VALUES ('CV002', N'Trưởng phòng nhân sự', 'PB002', 4600000, 0)
INSERT INTO CHUCVU VALUES ('CV003', N'Trưởng phòng kinh doanh', 'PB003', 5200000, 0)
INSERT INTO CHUCVU VALUES ('CV004', N'Trưởng phòng kĩ thuật', 'PB004', 4350000, 0)
INSERT INTO CHUCVU VALUES ('CV005', N'Trưởng phòng kế toán', 'PB005', 2350000, 0)
INSERT INTO CHUCVU VALUES ('CV006', N'Trưởng phòng đào tạo', 'PB006', 3600000, 0)
INSERT INTO CHUCVU VALUES ('CV007', N'Nhân viên nhân sự', 'PB002', 2600000, 0)
INSERT INTO CHUCVU VALUES ('CV008', N'Nhân viên kinh doanh', 'PB003', 3200000, 0)
INSERT INTO CHUCVU VALUES ('CV009', N'Nhân viên kĩ thuật', 'PB004', 2350000, 0)
INSERT INTO CHUCVU VALUES ('CV010', N'Nhân viên kế toán', 'PB005', 350000, 0)
INSERT INTO CHUCVU VALUES ('CV011', N'Nhân viên đào tạo', 'PB006', 1600000, 0)
GO

INSERT INTO TAIKHOAN VALUES ('TK00001', N'admin', N'admin', null, 'NV00001', 'CV001', 0)
INSERT INTO TAIKHOAN VALUES ('TK00002', N'sanhpham', N'sanhpham', null, 'NV00002', 'CV002', 0)
INSERT INTO TAIKHOAN VALUES ('TK00003', N'kimthao', N'kimthao', null, 'NV00003', 'CV003', 0)
INSERT INTO TAIKHOAN VALUES ('TK00004', N'ngohau', N'ngohau', null, 'NV00004', 'CV004', 0)
INSERT INTO TAIKHOAN VALUES ('TK00005', N'ngocanh', 'ngocanh', null, 'NV00005', 'CV005', 0)
INSERT INTO TAIKHOAN VALUES ('TK00006', N'tienlinh', 'tienlinh', null, 'NV00006', 'CV006', 0)
GO

INSERT INTO CHUCNANG VALUES ('CN001', N'Quản lí tuyển dụng', 0)
INSERT INTO CHUCNANG VALUES ('CN002', N'Quản lí lương thưởng', 0)
INSERT INTO CHUCNANG VALUES ('CN003', N'Quản lí lịch sử làm việc', 0)
INSERT INTO CHUCNANG VALUES ('CN004', N'Quản lí đào tào kĩ năng', 0)
INSERT INTO CHUCNANG VALUES ('CN005', N'Tra cứu nhân viên', 0)
INSERT INTO CHUCNANG VALUES ('CN006', N'Xử lí bán hàng', 0)
INSERT INTO CHUCNANG VALUES ('CN007', N'Quản lí khách hàng', 0)
INSERT INTO CHUCNANG VALUES ('CN008', N'Lập báo cáo kinh doanh', 0)
INSERT INTO CHUCNANG VALUES ('CN009', N'Quản lí phân quyền', 0)
INSERT INTO CHUCNANG VALUES ('CN010', N'Thay đổi quy định', 0)
GO
INSERT INTO PHANQUYEN VALUES ('CN001', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN002', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN003', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN004', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN005', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN006', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN007', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN008', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN009', 'CV001', null, 0)
INSERT INTO PHANQUYEN VALUES ('CN010', 'CV001', null, 0)
GO