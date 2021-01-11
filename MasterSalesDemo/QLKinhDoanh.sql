﻿--- Tao DATABASE 
CREATE DATABASE QLKinhDoanh
GO
USE QLKinhDoanh
GO
--- Tao cac bang quan ly nhan su
CREATE TABLE THAMSO
(
	id NVARCHAR(50) NOT NULL PRIMARY KEY,
	GiaTri MONEY NOT NULL,
)
GO
CREATE TABLE TRINHDO
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenTrinhDo NVARCHAR(50) NOT NULL,
	isDeleted BIT,
)
GO
CREATE TABLE PHONGBAN
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenPhong NVARCHAR(50),
	MaTrgPB VARCHAR(20),
	isDeleted BIT,
)
GO
CREATE TABLE CHUCVU
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenChucVu NVARCHAR(50),
	MaPhongBan VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES PHONGBAN(id),
	PhuCap MONEY CHECK (PhuCap>0),
	isTrgPB BIT,
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
	MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
	isDeleted BIT,
)
GO

ALTER TABLE PHONGBAN
ADD FOREIGN KEY (MaTrgPB) REFERENCES NHANVIEN(id);

CREATE TABLE LICHSUCHUCVU
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
	NgayBD SMALLDATETIME,
	NgayKT SMALLDATETIME,
	isDeleted BIT,
)
GO
CREATE TABLE LOAIHOPDONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenLoaiHD NVARCHAR(50),
	ThoiHan INT,
	Luong MONEY CHECK (Luong >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE HOPDONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaNV VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayHD SMALLDATETIME,
	NgayKT SMALLDATETIME,
	MaLoaiHD  VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES LOAIHOPDONG(id),
	isDeleted BIT,
)
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
	LoaiDanhGia NVARCHAR(50),
	isDeleted BIT,
)
GO
CREATE TABLE BANGLAMTHEM
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaTrgPB VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME ,
	Thang INT NOT NULL CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20) FOREIGN KEY REFERENCES PHONGBAN(id),
	HeSo MONEY  CHECK (HeSo > 0),
	isDeleted BIT,
)
GO
CREATE TABLE BANGTHUONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaTrgPB VARCHAR(20)  FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME ,
	Thang INT  CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20) FOREIGN KEY REFERENCES PHONGBAN(id),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGLAMTHEM
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaLamThem VARCHAR(20)FOREIGN KEY REFERENCES BANGLAMTHEM(id),
	MaNV VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	SoBuoi INT CHECK (SoBuoi >= 0),
	TienLamThem MONEY CHECK (TienLamThem >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGTHUONG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaThuong VARCHAR(20) FOREIGN KEY REFERENCES BANGTHUONG(id),
	MaNV VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	MaMucThuong VARCHAR(20) FOREIGN KEY REFERENCES MUCTHUONG(id),
	TienThuong MONEY CHECK (TienThuong >= 0),
	isDeleted BIT,
)
GO
CREATE TABLE BANGLUONGTL
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaKeToan VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	NgayLap SMALLDATETIME,
    Thang INT CHECK (THANG>=1 AND THANG<=12),
	MaPhong VARCHAR(20)FOREIGN KEY REFERENCES PHONGBAN(id),
	isDeleted BIT,
)
GO
CREATE TABLE CT_BANGLUONGTL
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaLuongTL VARCHAR(20) FOREIGN KEY REFERENCES BANGLUONGTL(id),
	MaNV VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	LuongCB MONEY CHECK (LuongCB >= 0),
	TienThuong MONEY CHECK (TienThuong >= 0),
	LuongLamThem MONEY CHECK (LuongLamThem >= 0),
	PhuCap MONEY CHECK (PhuCap >= 0),
	TongLuong MONEY CHECK (TongLuong >= 0),
	isDeleted BIT,
)
GO
--- BAN HANG
CREATE TABLE NHACUNGCAP
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNCC NVARCHAR(50),
	SDT VARCHAR(20),
	isDeleted BIT,
)
GO
CREATE TABLE KHACHHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenKH NVARCHAR(50),
	DiaChi NVARCHAR(50),
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
	MaKH VARCHAR(20) FOREIGN KEY REFERENCES KHACHHANG(id),
	CauHoi NVARCHAR (1000),
	TraLoi NVARCHAR (1000),
	isDeleted BIT,
	NgayDat SMALLDATETIME,
	NgayTraLoi SMALLDATETIME,
	NguoiTraLoi VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id)
)
GO

CREATE TABLE NHOMMATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenNhomMH NVARCHAR(50),
	isDeleted BIT,
)
GO
CREATE TABLE MATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenMH NVARCHAR(50),
	DonVi NVARCHAR(50),
	HinhAnh VARCHAR(1000),
	MaNCC VARCHAR(20) FOREIGN KEY REFERENCES NHACUNGCAP(id),
	MaNhomMH VARCHAR(20) FOREIGN KEY REFERENCES NHOMMATHANG(id),
	DonGia MONEY,
	isDeleted BIT,
)
GO
CREATE TABLE PHIEUDATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaKH VARCHAR(20) FOREIGN KEY REFERENCES KHACHHANG(id),
	NgayDat SMALLDATETIME,
	ThanhTien MONEY,
	TrangThai INT,
	isDeleted BIT,
)
GO
CREATE TABLE CT_PHIEUDATHANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaPhieuDH VARCHAR(20) FOREIGN KEY REFERENCES PHIEUDATHANG(id),
	MaMH VARCHAR(20) FOREIGN KEY REFERENCES MATHANG(id),
	SLDat INT,
	DonGia MONEY,
	TongTien MONEY ,
	isDeleted BIT,
)
GO
CREATE TABLE HOADON
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaPhieuDH VARCHAR(20) FOREIGN KEY REFERENCES PHIEUDATHANG(id),
	NgayLap SMALLDATETIME,
	NgayXuat SMALLDATETIME,
	MaKH VARCHAR(20) FOREIGN KEY REFERENCES KHACHHANG(id),
	MaNV VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id) ,
	ThanhTien MONEY ,
	TrangThai INT,
	isDeleted BIT,
)
GO
CREATE TABLE CT_HOADON
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	MaHD VARCHAR(20) FOREIGN KEY REFERENCES HOADON(id),
	MaMH VARCHAR(20) FOREIGN KEY REFERENCES MATHANG(id),
	SLMua INT,
	DonGia MONEY,
	TongTien MONEY,
	isDeleted BIT,
)
GO
---PHAN QUYEN
CREATE TABLE CHUCNANG
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenChucNang NVARCHAR(50),
	isDeleted BIT,
)
GO
CREATE TABLE TAIKHOAN
(
	id VARCHAR(20) NOT NULL PRIMARY KEY,
	TenDangNhap VARCHAR(20),
	MatKhau VARCHAR(50),
	Avatar VARCHAR(1000),
	MaNV VARCHAR(20) FOREIGN KEY REFERENCES NHANVIEN(id),
	--MaChucVu VARCHAR(20) NOT NULL FOREIGN KEY REFERENCES CHUCVU(id),
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

INSERT INTO LOAIHOPDONG VALUES ('LHD001', N'Hợp đồng thử việc', 1, 5000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD002', N'Hợp đồng 3 tháng', 3, 8000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD003', N'Hợp đồng 6 tháng', 6, 9000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD004', N'Hợp đồng 9 tháng', 9, 10000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD005', N'Hợp đồng 1 năm', 12, 11000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD006', N'Hợp đồng 2 năm', 24, 11000000, 0)
INSERT INTO LOAIHOPDONG VALUES ('LHD007', N'Hợp đồng 3 năm', 36, 15000000, 0)
GO

INSERT INTO PHONGBAN VALUES ('PB001', N'Ban quản trị', null, 0)
INSERT INTO PHONGBAN VALUES ('PB002', N'Phòng nhân sự', null, 0)
INSERT INTO PHONGBAN VALUES ('PB003', N'Phòng kinh doanh', null, 0)
INSERT INTO PHONGBAN VALUES ('PB004', N'Phòng kĩ thuật', null, 0)
INSERT INTO PHONGBAN VALUES ('PB005', N'Phòng kế toán', null, 0)
INSERT INTO PHONGBAN VALUES ('PB006', N'Phòng đào tạo', null, 0)
GO

INSERT INTO CHUCVU VALUES ('CV001', N'Giám đốc điều hành', 'PB001', 5600000, 1,0)
INSERT INTO CHUCVU VALUES ('CV002', N'Trưởng phòng nhân sự', 'PB002', 4600000,1, 0)
INSERT INTO CHUCVU VALUES ('CV003', N'Trưởng phòng kinh doanh', 'PB003', 5200000,1, 0)
INSERT INTO CHUCVU VALUES ('CV004', N'Trưởng phòng kĩ thuật', 'PB004', 4350000,1, 0)
INSERT INTO CHUCVU VALUES ('CV005', N'Trưởng phòng kế toán', 'PB005', 2350000, 1,0)
INSERT INTO CHUCVU VALUES ('CV006', N'Trưởng phòng đào tạo', 'PB006', 3600000,1, 0)
INSERT INTO CHUCVU VALUES ('CV007', N'Nhân viên nhân sự', 'PB002', 2600000, 0,0)
INSERT INTO CHUCVU VALUES ('CV008', N'Nhân viên kinh doanh', 'PB003', 3200000,0, 0)
INSERT INTO CHUCVU VALUES ('CV009', N'Nhân viên kĩ thuật', 'PB004', 2350000, 0,0)
INSERT INTO CHUCVU VALUES ('CV010', N'Nhân viên kế toán', 'PB005', 350000, 0,0)
INSERT INTO CHUCVU VALUES ('CV011', N'Nhân viên đào tạo', 'PB006', 1600000, 0,0)
GO

INSERT INTO NHANVIEN VALUES ('NV00001', N'Lê Sơn', '11/15/2000', N'Nam', N'Đồng Nai', 'TD006', null, 'CV001',0)
INSERT INTO NHANVIEN VALUES ('NV00002', N'Phạm Sanh', '09/18/2000', N'Nam', N'Phú Yên', 'TD006', null, 'CV002', 0)
INSERT INTO NHANVIEN VALUES ('NV00003', N'Kim Thảo', '09/28/2000', N'Nữ', N'Quảng Nam', 'TD006', null,'CV003', 0)
INSERT INTO NHANVIEN VALUES ('NV00004', N'Ngô Hậu', '08/22/2000', N'Nam', N'Đồng Nai', 'TD006', null, 'CV004',0)
INSERT INTO NHANVIEN VALUES ('NV00005', N'Ngọc Anh', '08/07/1995', N'Nữ', N'TP HCM', 'TD004', null,'CV005',0)
INSERT INTO NHANVIEN VALUES ('NV00006', N'Tiến Linh', '05/11/2001', N'Nam', N'Tây Ninh', 'TD005', null, 'CV006',0)
GO

INSERT INTO HOPDONG VALUES ('HD00001', 'NV00001', '02/12/2017', '04/05/2018', 'LHD001', 0)
INSERT INTO HOPDONG VALUES ('HD00002', 'NV00002', '04/08/2015', '08/20/2018', 'LHD002', 0)
INSERT INTO HOPDONG VALUES ('HD00003', 'NV00003', '05/12/2019', '04/05/2020', 'LHD003', 0)
INSERT INTO HOPDONG VALUES ('HD00004', 'NV00004', '06/11/2020', '12/18/2023', 'LHD004', 0)
INSERT INTO HOPDONG VALUES ('HD00005', 'NV00005', '07/10/2021', '05/21/2025', 'LHD005', 0)
INSERT INTO HOPDONG VALUES ('HD00006', 'NV00006', '08/02/2020', '08/23/2021', 'LHD006', 0)
GO

INSERT INTO TAIKHOAN VALUES ('TK00001', N'admin', N'admin', null, 'NV00001', 0)
INSERT INTO TAIKHOAN VALUES ('TK00002', N'sanhpham', N'sanhpham', null, 'NV00002', 0)
INSERT INTO TAIKHOAN VALUES ('TK00003', N'kimthao', N'kimthao', null, 'NV00003', 0)
INSERT INTO TAIKHOAN VALUES ('TK00004', N'ngohau', N'ngohau', null, 'NV00004', 0)
INSERT INTO TAIKHOAN VALUES ('TK00005', N'ngocanh', 'ngocanh', null, 'NV00005', 0)
INSERT INTO TAIKHOAN VALUES ('TK00006', N'tienlinh', 'tienlinh', null, 'NV00006', 0)
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

INSERT INTO THAMSO VALUES (N'HeSoLamThem', 100000)
GO

INSERT INTO LICHSUCHUCVU VALUES ('LS00001','NV00001', 'CV003', '06/12/2015', '05/12/2016', 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00002','NV00002', 'CV002', '06/12/2019', null, 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00003','NV00003', 'CV003', '06/12/2019', null, 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00004','NV00004', 'CV004', '06/12/2019', null, 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00005','NV00005', 'CV005', '06/12/2019', null, 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00006','NV00006', 'CV006', '06/12/2019', null, 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00007','NV00001', 'CV002', '05/12/2016', '09/24/2017', 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00008','NV00001', 'CV007', '09/24/2017', '07/13/2018', 0)
INSERT INTO LICHSUCHUCVU VALUES ('LS00009','NV00001', 'CV001', '07/13/2018', null, 0)

---- run sql from this hihi

INSERT INTO NHOMMATHANG VALUES ('NMH001', N'Laptop', 0)
INSERT INTO NHOMMATHANG VALUES ('NMH002', N'Điện thoại', 0)
INSERT INTO NHOMMATHANG VALUES ('NMH003', N'Đồng hồ', 0)
INSERT INTO NHOMMATHANG VALUES ('NMH004', N'Loa tai nghe', 0)
INSERT INTO NHOMMATHANG VALUES ('NMH005', N'Khác', 0)
GO

INSERT INTO NHACUNGCAP VALUES ('NCC001', N'Apple', '0123456789', 0)
INSERT INTO NHACUNGCAP VALUES ('NCC002', N'Google', '0123456789', 0)
INSERT INTO NHACUNGCAP VALUES ('NCC003', N'Samsung', '0123456789', 0)
INSERT INTO NHACUNGCAP VALUES ('NCC004', N'Dell', '0123456789', 0)
INSERT INTO NHACUNGCAP VALUES ('NCC005', N'Htc', '0123456789', 0)
GO

-- sua ma phieu dat hang thanh so dem 1 2 3
INSERT INTO MATHANG VALUES ('MH1', N'Google Pixel - Black', 'cái', 'img/product-1.png', 'NCC002','NMH002',10000000,0)
INSERT INTO MATHANG VALUES ('MH2', N'Samsung S7', 'cái', 'img/product-2.png', 'NCC003','NMH002',12000000,0)
INSERT INTO MATHANG VALUES ('MH3', N'HTC 10 - Black', 'cái', 'img/product-3.png', 'NCC005','NMH002',14000000,0)
INSERT INTO MATHANG VALUES ('MH4', N'HTC 10 - White', 'cái', 'img/product-4.png', 'NCC005','NMH002',8000000,0)
INSERT INTO MATHANG VALUES ('MH5', N'HTC Desire 626s', 'abc', 'img/product-5.png', 'NCC005','NMH002',9000000,0)
INSERT INTO MATHANG VALUES ('MH6', N'Vintage Iphone', 'abc', 'img/product-6.png', 'NCC001','NMH002',1000000,0)
INSERT INTO MATHANG VALUES ('MH7', N'Iphone 7', 'abc', 'img/product-7.png', 'NCC001','NMH002',15000000,0)
INSERT INTO MATHANG VALUES ('MH8', N'Laptop Dell Inspiron 5500', 'abc', 'img/product-8.png', 'NCC004','NMH001',19200000,0)
GO

INSERT INTO KHACHHANG VALUES ('KH1', N'Thành Nam', N'Q Thủ Đức TPHCM', '0123456789', null,'kh1','kh1',0)
INSERT INTO KHACHHANG VALUES ('KH2', N'Kim Anh', N'Q Bình Thạnh TPHCM', '0112233445', null,'kh2','kh2',0)
GO

INSERT INTO PHIEUDATHANG VALUES ('PDH1', 'KH1', '05/12/2020', 22000000, 0, 0)
GO

INSERT INTO CT_PHIEUDATHANG VALUES ('CTPDH1', 'PDH1', 'MH1', 1, 10000000, 10000000, 0)
INSERT INTO CT_PHIEUDATHANG VALUES ('CTPDH2', 'PDH1', 'MH2', 1, 12000000, 12000000, 0)
GO

ALTER TABLE BANGLAMTHEM
ADD Nam INT;

ALTER TABLE BANGLUONGTL
ADD Nam INT;

ALTER TABLE BANGTHUONG
ADD Nam INT;

INSERT INTO MUCTHUONG VALUES ('MT1',N'Mức 1', 2000000, 0)
INSERT INTO MUCTHUONG VALUES ('MT2',N'Mức 2', 1200000, 0)
INSERT INTO MUCTHUONG VALUES ('MT3',N'Mức 3', 0, 0)
GO

UPDATE PHONGBAN SET MaTrgPB = 'NV00001' WHERE id='PB001'
UPDATE PHONGBAN SET MaTrgPB = 'NV00002' WHERE id='PB002'
UPDATE PHONGBAN SET MaTrgPB = 'NV00003' WHERE id='PB003'
UPDATE PHONGBAN SET MaTrgPB = 'NV00004' WHERE id='PB004'
UPDATE PHONGBAN SET MaTrgPB = 'NV00005' WHERE id='PB005'
UPDATE PHONGBAN SET MaTrgPB = 'NV00006' WHERE id='PB006'

ALTER TABLE MATHANG
ADD MoTa NVARCHAR(250)

ALTER TABLE PHIEUDATHANG
ADD DiaChiNhan NVARCHAR(50)

INSERT INTO TuVanKH VALUES ('TV1','KH1', N'Bạn có người yêu chưa', N'Tui chưa biết nè hihi', 0,'1/1/2020','1/8/2020','NV00005')


