using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterSalesDemo.Model;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace MasterSalesDemo.Helper
{
    public class Global
    {
        public NHANVIEN NhanVien { get; set; }
        public string NgayThangNam { get; set; }

        public bool isValid { get; set; } 

        private Global ()
        {
            isValid = false;
        }

        //Hàm Generate Mã tự động
        public int filterNumber(string code)
        {
            string number = "";
            for (int i = 0; i < code.Length; i++)
                if (code[i] >= '0' && code[i] <= '9')
                    number += code[i];
            return int.Parse(number);
        }

        //ex: auto Generate("LS", 123, 8) => code : LS000123
        public string autoGenerateCode(string quydinh, int max, int length)
        {
            int length_numbers0 = length - quydinh.Length - (max + "").Length;
            string code = quydinh;
            for (int i = 1; i <= length_numbers0; i++)
                code += "0";
            code += max + "";
            return code;
        }

        public string autoGenerateLichSu()
        {
            //Loại bỏ chữ cái ở trước
            int flag = 0;
            ObservableCollection<LICHSUCHUCVU> _listLS = new ObservableCollection<LICHSUCHUCVU>(DataProvider.Ins.DB.LICHSUCHUCVUs);
            foreach (var ls in _listLS)
            {
                int number = filterNumber(ls.id);
                if (number > flag)
                    flag = number;
            }

            flag++;
            return autoGenerateCode("LS", flag, 7);
        }

        public string autoGenerateHopDong()
        {
            //Loại bỏ chữ cái ở trước
            int flag = 0;
            ObservableCollection<HOPDONG> _listHD = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);
            foreach (var ls in _listHD)
            {
                int number = filterNumber(ls.id);
                if (number > flag)
                    flag = number;
            }

            flag++;
            return autoGenerateCode("HD", flag, 7);
        }

        public string autoGenerateHoaDon()
        {
            //Loại bỏ chữ cái ở trước
            int flag = 0;
            ObservableCollection<HOADON> _listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            foreach (var ls in _listHD)
            {
                int number = filterNumber(ls.id);
                if (number > flag)
                    flag = number;
            }

            flag++;
            return autoGenerateCode("HD", flag, 10);
        }

        public string autoGenerateCTHoaDon()
        {
            //Loại bỏ chữ cái ở trước
            int flag = 0;
            ObservableCollection<CT_HOADON> _listCTHD = new ObservableCollection<CT_HOADON>(DataProvider.Ins.DB.CT_HOADON);
            foreach (var ls in _listCTHD)
            {
                int number = filterNumber(ls.id);
                if (number > flag)
                    flag = number;
            }

            flag++;
            return autoGenerateCode("CTHD", flag, 10);
        }
        public void setNhanVien(NHANVIEN nv)
        {
            this.NhanVien = nv;
            NgayThangNam = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private static Global _instance = null;
        public static Global Ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }

        }

        public void ChuyenChucVuNhanVien(NHANVIEN nhanvien, CHUCVU chucvu)
        {
            nhanvien.MaChucVu = chucvu.id;
            DataProvider.Ins.DB.SaveChanges();

            //Tạo trong lịch sử
            LICHSUCHUCVU lichsu = new LICHSUCHUCVU()
            {
                id = autoGenerateLichSu(),
                MaNV = nhanvien.id,
                MaChucVu = chucvu.id,
                NgayBD = DateTime.Now,
                NgayKT = null,
                isDeleted = false,
            };

            DataProvider.Ins.DB.LICHSUCHUCVUs.Add(lichsu);
            updateLichSu(nhanvien);
            DataProvider.Ins.DB.SaveChanges();
        }

        public MATHANG getMatHangbyMaMH(string MaMH)
        {
            ObservableCollection<MATHANG> _listMH = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            foreach (var mh in _listMH)
                if (mh.id == MaMH)
                    return mh;
            return null;
        }
        public LOAIHOPDONG getLHDbyTenLHD(string TenLHD)
        {
            ObservableCollection<LOAIHOPDONG> _listLHD = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);

            foreach (var lhd in _listLHD)
                if (lhd.TenLoaiHD == TenLHD)
                    return lhd;
            return null;
        }

        public CHUCVU getChucVubyMaNV(string MaNV)
        {
            ObservableCollection<TAIKHOAN> _listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

            foreach (var tk in _listTaiKhoan)
            {
                if (tk.MaNV == MaNV) 
                {
                    return tk.NHANVIEN.CHUCVU;
                }                    
            }
            return null;
        }
        public CHUCVU getChucVubyTenCVTenPB(string TenCV, string TenPB)
        {
            ObservableCollection<CHUCVU> _listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            foreach (var cv in _listChucVu)
                if (cv.TenChucVu == TenCV && cv.PHONGBAN.TenPhong == TenPB)
                    return cv;

            return null;
        }
        public NHANVIEN getNhanVienbyMaNV(string MaNV)
        {
            ObservableCollection<NHANVIEN> _listNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

            foreach (var nv in _listNhanVien)
            {
                if (nv.id == MaNV)
                    return nv;
            }

            return null;
        }

        public HOPDONG getHopDongbyMaNV(string MaNV)
        {
            ObservableCollection<HOPDONG> _listHopDong = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);

            foreach (var hopdong in _listHopDong)
                if (hopdong.MaNV == MaNV && hopdong.isDeleted == false)
                    return hopdong;
            return null;
        }

        public PHONGBAN getPhongBanbyMaPB(string MaPB)
        {
            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);
            foreach (var pb in _listPhongBan)
                if (pb.id == MaPB)
                    return pb;
            return null;
        }

        public PHONGBAN getPhongBanbyTenPB(string TenPB)
        {
            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);
            foreach (var pb in _listPhongBan)
                if (pb.TenPhong == TenPB)
                    return pb;
            return null;
        }
        
        public TAIKHOAN getTaiKhoanbyMaNV(string MaNV)
        {
            ObservableCollection<TAIKHOAN> _listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
            foreach (var tk in _listTaiKhoan)
                if (tk.MaNV == MaNV)
                    return tk;
            return null;
        }

        public KHACHHANG getKHbyMaKH(string MaKH)
        {
            ObservableCollection<KHACHHANG> _listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);

            foreach (var kh in _listKH)
                if (kh.id == MaKH)
                    return kh;

            return null;
        }

        public ObservableCollection<MATHANG> searchMHbyTenNhom_TenMH(string TenNhomMH, string TenMH)
        {
            ObservableCollection<MATHANG> _listMH = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            ObservableCollection<MATHANG> _res = new ObservableCollection<MATHANG>();
            foreach (var mh in _listMH)
            {
                bool isValidNhom = false;
                bool isValidTenMH = false;
                if (String.IsNullOrWhiteSpace(TenNhomMH) || mh.NHOMMATHANG.TenNhomMH == TenNhomMH)
                    isValidNhom = true;

                if (String.IsNullOrWhiteSpace(TenMH) || mh.TenMH.ToLower().Contains(TenMH.ToLower()))
                    isValidTenMH = true;

                if (isValidNhom && isValidTenMH )
                    _res.Add(mh);
            }
            return _res;
        }
        //Functions load database GET ALL
        #region
        public ObservableCollection<PHIEUDATHANG> getAllPhieuDatHang()
        {
            ObservableCollection<PHIEUDATHANG> _listPDH= new ObservableCollection<PHIEUDATHANG>(DataProvider.Ins.DB.PHIEUDATHANGs);
            ObservableCollection<PHIEUDATHANG> _RES = new ObservableCollection<PHIEUDATHANG>();
            foreach (var pdh in _listPDH)
                if (!(pdh.isDeleted == true))
                    _RES.Add(pdh);
            return _RES;
        }

        public ObservableCollection<string> getAllTenPhongBan()
        {
            ObservableCollection<string>  ListPhongBan = new ObservableCollection<string>();
            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);
            foreach (var pb in _listPhongBan)
                ListPhongBan.Add(pb.TenPhong);
            return ListPhongBan;
        }

        public ObservableCollection<string> getAllTenChucVubyMaPB(string MaPhongBan)
        {
            ObservableCollection<string>  ListChucVu = new ObservableCollection<string>();
            ObservableCollection<CHUCVU> _listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var cv in _listChucVu)
                if (cv.PHONGBAN.id == MaPhongBan)
                    ListChucVu.Add(cv.TenChucVu);
            return ListChucVu;
        }

        public ObservableCollection<string> getAllTenLoaiHD()
        {
            ObservableCollection<string> ListLoaiHD = new ObservableCollection<string>();
            ObservableCollection<LOAIHOPDONG> _listLoaiHD = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
            foreach (var lhd in _listLoaiHD)
                ListLoaiHD.Add(lhd.TenLoaiHD);
            return ListLoaiHD;
        }

        public ObservableCollection<string> getAllTenNhomMH()
        {
            ObservableCollection<string> res = new ObservableCollection<string>();
            ObservableCollection<NHOMMATHANG> _listNhomMH = new ObservableCollection<NHOMMATHANG>(DataProvider.Ins.DB.NHOMMATHANGs);
            foreach (var nmh in _listNhomMH)
                res.Add(nmh.TenNhomMH);
            return res;
        }
        #endregion

        //Functions sub
        public void deleteHopDong(string MaNV)
        {
            ObservableCollection<HOPDONG> _listHD = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);

            foreach (var hd in _listHD)
                if (hd.MaNV == MaNV)
                    hd.isDeleted = true;

            DataProvider.Ins.DB.SaveChanges();
        }
        public void updateLichSu(NHANVIEN nhanvien)
        {
            ObservableCollection<LICHSUCHUCVU> _listLS = new ObservableCollection<LICHSUCHUCVU>(DataProvider.Ins.DB.LICHSUCHUCVUs);

            foreach (var ls in _listLS)
                if (ls.MaNV == nhanvien.id)
                    if (ls.NgayKT == null)
                        ls.NgayKT = DateTime.Now;
            DataProvider.Ins.DB.SaveChanges();
        }

        //Dung cho them gio hang
        public string TenMH { get; set; }
        public int SoLuongMua { get; set; }
        public bool isThemThanhCong { get; set; }

        //Dung cho xu ly dat hang online
        public PHIEUDATHANG PhieuDHXuLY { get; set; }
        public bool isXuLy { get; set; }

        public PHIEUDATHANG getPhieuDHbyMaPhieu(string MaPhieu)
        {
            ObservableCollection<PHIEUDATHANG> _listPDH = new ObservableCollection<PHIEUDATHANG>(DataProvider.Ins.DB.PHIEUDATHANGs);
            foreach (var pdh in _listPDH)
                if (!(pdh.isDeleted == true) && pdh.id == MaPhieu)
                    return pdh;
            return null;
        }
    }
}
