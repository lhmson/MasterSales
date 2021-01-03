using MasterSalesDemo.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using MasterSalesDemo.View;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class ThongTinCaNhan
    { 
        public string STT { get; set; }
        public string HoTen { get; set; }
        public string MaNV { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgaySinh { get; set; }
        public string PhongBan { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string TenTrinhDo { get; set; }
        public TRINHDO TD { get; set; }
        public CHUCVU CHUCVU { get; set; }

        public ThongTinCaNhan(int stt, string MaNV, string HoTen, DateTime NgaySinh, string GioiTinh, string PhongBan, string ChucVu, string NoiSinh, TRINHDO TD, string TenTrinhDo, CHUCVU CHUCVU)
        {
            this.STT = stt + "";
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            this.GioiTinh = GioiTinh;
            this.NgaySinh = NgaySinh;
            this.PhongBan = PhongBan;
            this.ChucVu = ChucVu;
            this.NoiSinh = NoiSinh;
            this.TD = TD;
            this.TenTrinhDo = TenTrinhDo;
            this.CHUCVU = CHUCVU;
        }
    }

    public class QLTuyenDung_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenLoaiHopDongCommand { get; set; }
        public ICommand OpenThemHopDongCommand { get; set; }
        public ICommand ThemNhanVienCommand { get; set; }
        public ICommand ThemLoaiHopDongCommand { get; set; }
        public ICommand ThemHopDongCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand SuaThongTinNhanVienCommand { get; set; }
        public ICommand OpenThemNhanVienCommand { get; set; }
        public ICommand SuaLoaiHopDongCommand { get; set; }

        //public ICommand ThayDoiTrinhDo { get; set; }

        #region nhân viên

        private ObservableCollection<NHANVIEN> _NhanVien;
        public ObservableCollection<NHANVIEN> NhanVien { get => _NhanVien; set { _NhanVien = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private DateTime _NgaySinh;
        public DateTime NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _MaNhanVien;
        public string MaNhanVien { get => _MaNhanVien; set { _MaNhanVien = value; OnPropertyChanged(); } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        private string _NoiSinh;
        public string NoiSinh { get => _NoiSinh; set { _NoiSinh = value; OnPropertyChanged(); } }

        private string _MaTrinhDo;
        public string MaTrinhDo { get => _MaTrinhDo; set { _MaTrinhDo = value; OnPropertyChanged(); } }

        private string _TenChuVu;
        public string TenChuVu { get => _TenChuVu; set { _TenChuVu = value; OnPropertyChanged(); } }

        private string _MaChuVu;
        public string MaChucVu { get => _MaChuVu; set { _MaChuVu = value; OnPropertyChanged(); } }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private NHANVIEN _SelectedItemNhanVien;
        public NHANVIEN SelectedItemNhanVien
        {
            get => _SelectedItemNhanVien;
            set
            {
                _SelectedItemNhanVien = value;
                OnPropertyChanged();
                if (SelectedItemNhanVien != null)
                {
                    MaNhanVien = SelectedItemNhanVien.id;
                    HoTen = SelectedItemNhanVien.HoTen;
                    MaTrinhDo = SelectedItemNhanVien.MaTrinhDo;
                    GioiTinh = SelectedItemNhanVien.GioiTinh;
                    NoiSinh = SelectedItemNhanVien.NoiSinh;
                    SelectedItemTrinhDo = SelectedItemNhanVien.TRINHDO;
                    NgaySinh = SelectedItemNhanVien.NgaySinh.Value;
                    SelectedItemChucVu = SelectedItemNhanVien.CHUCVU;
                    // TenTrinhDo = SelectedItemNhanVien.TenTrinhDo;
                }
            }
        }

        private ThongTinCaNhan _SelectedNhanVien;
        public ThongTinCaNhan SelectedNhanVien
        {
            get { return _SelectedNhanVien; }
            set { _SelectedNhanVien = value; OnPropertyChanged();
                if (SelectedNhanVien != null)
                {
                    HoTen = SelectedNhanVien.HoTen;
                    NgaySinh = SelectedNhanVien.NgaySinh;
                    GioiTinh = SelectedNhanVien.GioiTinh;
                    NoiSinh = SelectedNhanVien.NoiSinh;
                    TenTrinhDo = SelectedNhanVien.TenTrinhDo;
                    SelectedItemTrinhDo = SelectedNhanVien.TD;
                    SelectedItemChucVu = SelectedNhanVien.CHUCVU;
                    MaTrinhDo = SelectedNhanVien.TD.id;
                    MaChucVu = SelectedNhanVien.CHUCVU.id;
                    //ChucVu = SelectedNhanVien.ChucVu;
                }
            }
        }

        private ObservableCollection<ThongTinCaNhan> _ListThongTinNhanVien;
        public ObservableCollection<ThongTinCaNhan> ListThongTinNhanVien
        {
            get { return _ListThongTinNhanVien; }
            set { _ListThongTinNhanVien = value; OnPropertyChanged(); }
        }

        #endregion

        #region init nhân viên

        public void InitNhanVien()
        {
            HoTen = "";
            GioiTinh = "";
            SelectedItemTrinhDo = null;
            NoiSinh = "";
            SelectedItemChucVu = null;
            NgaySinh = DateTime.Now;
            ListThongTinNhanVien = new ObservableCollection<ThongTinCaNhan>();
            SearchNhanVien();
        }

        #endregion

        #region init thêm hợp đồng

        void InitThemHopDong()
        {
            TenLoaiHD = "";
            NhanVien = null;
            SelectedStartDate = DateTime.Now;
            ListHopDong = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);
        }

        #endregion

        #region init Thêm loại hợp đồng

        void InitThemLoaiHopDong ()
        {
            TenLoaiHD = "";
            ThoiHan = 0;
            Luong = 0;
            ListLoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
        }

        #endregion

        #region Trình độ

        private string _TenTrinhDo;
        public string TenTrinhDo { get => _TenTrinhDo; set { _TenTrinhDo = value; OnPropertyChanged(); } }

        private ObservableCollection<TRINHDO> _ListTrinhDo;
        public ObservableCollection<TRINHDO> ListTrinhDo { get => _ListTrinhDo; set { _ListTrinhDo = value; OnPropertyChanged(); } }

        private ObservableCollection<TRINHDO> _TrinhDo;
        public ObservableCollection<TRINHDO> TrinhDo { get => _TrinhDo; set { _TrinhDo = value; OnPropertyChanged(); } }

        private TRINHDO _SelectedItemTrinhDo;
        public TRINHDO SelectedItemTrinhDo
        {
            get => _SelectedItemTrinhDo;
            set
            {
                _SelectedItemTrinhDo = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;
            }
        }

        #endregion

        #region giới tính

        private List<string> _ListGioiTinh;
        public List<string> ListGioiTinh
        {
            get { return _ListGioiTinh; }
            set
            {
                _ListGioiTinh = value;
                OnPropertyChanged(nameof(ListGioiTinh));
            }
        }

        #endregion

        #region Chức vụ

        private ObservableCollection<CHUCVU> _ChucVu;
        public ObservableCollection<CHUCVU> ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        private string _TenChucVu;
        public string TenChucVu { get => _TenChucVu; set { _TenChucVu = value; OnPropertyChanged(); } }

        private CHUCVU _SelectedItemChucVu;
        public CHUCVU SelectedItemChucVu
        {
            get => _SelectedItemChucVu;
            set
            {
                _SelectedItemChucVu = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;
            }
        }

        #endregion

        #region Loại hợp đồng

        private ObservableCollection<LOAIHOPDONG> _ListLoaiHopDong;
        public ObservableCollection<LOAIHOPDONG> ListLoaiHopDong { get => _ListLoaiHopDong; set { _ListLoaiHopDong = value; OnPropertyChanged(); } }

        private ObservableCollection<LOAIHOPDONG> _LoaiHopDong;
        public ObservableCollection<LOAIHOPDONG> LoaiHopDong { get => _LoaiHopDong; set { _LoaiHopDong = value; OnPropertyChanged(); } }

        private string _TenLoaiHD;
        public string TenLoaiHD { get => _TenLoaiHD; set { _TenLoaiHD = value; OnPropertyChanged(); } }

        private int _ThoiHan;
        public int ThoiHan { get => _ThoiHan; set { _ThoiHan = value; OnPropertyChanged(); } }

        private decimal? _Luong;
        public decimal? Luong { get => _Luong; set { _Luong = value; OnPropertyChanged(); } }

        private LOAIHOPDONG _SelectedItemLoaiHopDong;
        public LOAIHOPDONG SelectedItemLoaiHopDong
        {
            get => _SelectedItemLoaiHopDong;
            set
            {
                _SelectedItemLoaiHopDong = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemLoaiHopDong != null)
                {
                    TenLoaiHD = SelectedItemLoaiHopDong.TenLoaiHD;
                    ThoiHan = SelectedItemLoaiHopDong.ThoiHan??0;
                    Luong = SelectedItemLoaiHopDong.Luong;
                    SelectedEndDate = SelectedStartDate.AddMonths(SelectedItemLoaiHopDong.ThoiHan ?? 0);
                }
            }
        }

        #endregion

        #region tạo mã loại hợp đồng

        private string GetCodeLoaiHopDong()
        {
            ObservableCollection<LOAIHOPDONG> ListLoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
            int tmp = ListLoaiHopDong.Count();
            return "LHD" + format((tmp + 1).ToString());
        }

        #endregion

        #region tạo mã hợp đồng

        private string GetCodeHopDong()
        {
            ObservableCollection<HOPDONG> ListHopDong = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);
            int tmp = ListHopDong.Count();
            return "HD" + format((tmp + 1).ToString());
        }

        #endregion

        #region tạo mã nhân viên

        public string format(string a)
        {
            string tmp = a;
            for (int i = 1; i <= 5 - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        private string GetCodeNhanVien()
        {
            ObservableCollection<NHANVIEN> ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            int tmp = ListNhanVien.Count();
            return "NV" + format((tmp + 1).ToString());
        }

        #endregion

        #region Phòng ban

        private string _SelectedPhongBan;
        public string SelectedPhongBan
        {
            get { return _SelectedPhongBan; }
            set { _SelectedPhongBan = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListPhongBan;
        public ObservableCollection<string> ListPhongBan
        {
            get { return _ListPhongBan; }
            set { _ListPhongBan = value; OnPropertyChanged(); }
        }

        public void LoadSourceComboBoxPhongBan()
        {
            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);

            ListPhongBan = new ObservableCollection<string>();
            foreach (var pb in _listPhongBan)
                ListPhongBan.Add(pb.TenPhong);
        }

        #endregion

        #region ngày bắt đầu

        private DateTime _SelectedStartDate;
        public DateTime SelectedStartDate 
        {   get => _SelectedStartDate; set { _SelectedStartDate = value; OnPropertyChanged();

            if (SelectedStartDate!=null)
                {
                   // MessageBox.Show(ThoiHan.ToString());
                    SelectedEndDate = SelectedStartDate.AddMonths(ThoiHan);
                }    
            } 
        }

        #endregion

        #region ngày kết thúc

        private DateTime _SelectedEndDate;
        public DateTime SelectedEndDate { get => _SelectedEndDate; set { _SelectedEndDate = value; OnPropertyChanged(); } }

        #endregion

        #region Tìm kiếm nhân viên

        public void SearchNhanVien()
        {
            ObservableCollection<NHANVIEN> _listNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListThongTinNhanVien.Clear();

            foreach (var nv in _listNhanVien)
            {
                ThemNhanVienVaoList(nv);
            }
        }

        public TRINHDO getTrinhdobyMaNV(string MaTD)
        {
            ObservableCollection<TRINHDO> _listTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);

            foreach (var td in _listTrinhDo)
            {
                if ( td.id == MaTD)
                {
                    return td;
                }
            }
            return null;
        }

        public CHUCVU getChucVubyMaNV(string MaCV)
        {
            ObservableCollection<CHUCVU> _listChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            foreach (var cv in _listChucVu)
            {
                if (cv.id == MaCV)
                {
                    return cv;
                }
            }
            return null;
        }

        public void BindingSelectionNhanVien()
        {
            if (SelectedNhanVien == null)
                return;
            HoTen = SelectedNhanVien.HoTen;
        }

        public void ThemNhanVienVaoList(NHANVIEN nv)
        {
            bool validPhongBan = false;
            bool validTen = false;
            CHUCVU chucvu = getChucVubyMaNV(nv.MaChucVu);
            TRINHDO trinhdo = getTrinhdobyMaNV(nv.MaTrinhDo);
            if (SelectedPhongBan == null || (chucvu != null && chucvu.PHONGBAN.TenPhong == SelectedPhongBan))
                validPhongBan = true;

            if (String.IsNullOrWhiteSpace(TenNhanVien) || nv.HoTen.Contains(TenNhanVien))
                validTen = true;

            if (validTen && validPhongBan)
            {
                int stt = _ListThongTinNhanVien.Count() + 1;
                ThongTinCaNhan item = new ThongTinCaNhan(stt, nv.id, nv.HoTen, nv.NgaySinh.Value, nv.GioiTinh, chucvu.PHONGBAN.TenPhong, chucvu.TenChucVu, nv.NoiSinh, trinhdo, trinhdo.TenTrinhDo, chucvu);
                ListThongTinNhanVien.Add(item);
            }
        }

        #endregion

        #region hợp đồng

        private ObservableCollection<HOPDONG> _HopDong;
        public ObservableCollection<HOPDONG> HopDong { get => _HopDong; set { _HopDong = value; OnPropertyChanged(); } }
        
        private ObservableCollection<HOPDONG> _ListHopDong;
        public ObservableCollection<HOPDONG> ListHopDong { get => _ListHopDong; set { _ListHopDong = value; OnPropertyChanged(); } }

        private HOPDONG _SelectedItemHopDong;
        public HOPDONG SelectedItemHopDong
        {
            get => _SelectedItemHopDong;
            set
            {
                _SelectedItemHopDong = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemLoaiHopDong != null)
                {
                    TenLoaiHD = SelectedItemHopDong.LOAIHOPDONG.TenLoaiHD;
                    HoTen = SelectedItemHopDong.NHANVIEN.HoTen;
                  
                }
            }
        }

        #endregion

        #region kỹ năng nhân viên

        private ObservableCollection<KYNANG> _ListKyNangNhanVien;
        public ObservableCollection<KYNANG> ListKyNangNhanVien
        {
            get { return _ListKyNangNhanVien; }
            set { _ListKyNangNhanVien = value; OnPropertyChanged(); }
        }

        #endregion

        public QLTuyenDung_ViewModel()
        {
            InitNhanVien();
            InitThemHopDong();
            InitThemLoaiHopDong();
            LoadSourceComboBoxPhongBan();

            TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            ListTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);

            ListGioiTinh = new List<string>() { "Nam", "Nữ" };

            NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

            LoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
            
            HopDong = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);

            ChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            #region mở đóng

            OpenLoaiHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemLoaiHopDong window = new ThemLoaiHopDong();
                window.ShowDialog();
            });

            OpenThemHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemHopDong window = new ThemHopDong();
                window.ShowDialog();
            });

            OpenThemNhanVienCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemNhanVien window = new ThemNhanVien();
                window.Closed += ThemNhanVienWindow_Closed;
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                var exit = p as Window;
                exit.Close();
            });

            #endregion

            #region thêm nhân viên

            ThemNhanVienCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(HoTen))
                    return false;

                var tennhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.HoTen.ToLower() == HoTen.ToLower());
                if (tennhanvien == null || tennhanvien.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string manhanvien = GetCodeNhanVien();
                var nhanvien = new NHANVIEN()
                {
                    id = manhanvien,
                    HoTen = HoTen,
                    NgaySinh = NgaySinh,
                    GioiTinh = GioiTinh,
                    MaTrinhDo = SelectedItemTrinhDo.id,
                    NoiSinh = NoiSinh,
                    MaChucVu = SelectedItemChucVu.id,
                    isDeleted = false,
                };

                DataProvider.Ins.DB.NHANVIENs.Add(nhanvien);
                DataProvider.Ins.DB.SaveChanges();
                NhanVien.Add(nhanvien);
                NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
                ThemNhanVienVaoList(nhanvien);
                InitNhanVien();
                MessageBox.Show("Thêm thành công");
            });

            #endregion

            #region sửa thông tin nhân viên

            SuaThongTinNhanVienCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedNhanVien == null)
                    return false;
                //ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

                return true;
            }, (p) =>
            {
                var nhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == SelectedNhanVien.MaNV).SingleOrDefault();

                if (String.Compare(nhanvien.TRINHDO.id, SelectedItemTrinhDo.id) == 1)
                {
                    MessageBox.Show("Phải chọn trình độ cao hơn");
                }
                else
                {
                    nhanvien.HoTen = HoTen;
                    nhanvien.NoiSinh = NoiSinh;
                    nhanvien.NgaySinh = NgaySinh;
                    DataProvider.Ins.DB.SaveChanges();
                    SearchNhanVien();
                    OnPropertyChanged("SelectedNhanVien");
                    InitNhanVien();
                    //InitMH();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công");
                }
            });

            #endregion

            #region thêm loại hợp đồng

            ThemLoaiHopDongCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenLoaiHD) || ThoiHan == 0 || Luong == 0)
                    return false;

                var tenloaihopdong = DataProvider.Ins.DB.LOAIHOPDONGs.Where(x => x.TenLoaiHD.ToLower() == TenLoaiHD.ToLower());
                if (tenloaihopdong == null || tenloaihopdong.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string maloaihopdong = GetCodeLoaiHopDong();
                var loaihopdong = new LOAIHOPDONG()
                {
                    id = maloaihopdong,
                    TenLoaiHD = TenLoaiHD,
                    ThoiHan = ThoiHan,
                    Luong = Luong,
                    isDeleted = false,
                };

                DataProvider.Ins.DB.LOAIHOPDONGs.Add(loaihopdong);
                DataProvider.Ins.DB.SaveChanges();
                LoaiHopDong.Add(loaihopdong);
                LoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
                ListLoaiHopDong.Add(loaihopdong);
                InitThemLoaiHopDong();
                MessageBox.Show("Thêm thành công");
            });

            #endregion

            #region sửa loại hợp đồng

            SuaLoaiHopDongCommand = new RelayCommand<object>((p) =>
            {
                if (TenLoaiHD == null || ThoiHan ==0 || Luong ==0 )
                    return false;
                return true;

            }, (p) =>
            {
                var loaihopdong = DataProvider.Ins.DB.LOAIHOPDONGs.Where(x => x.id == SelectedItemLoaiHopDong.id).SingleOrDefault();
                SelectedItemLoaiHopDong.TenLoaiHD = TenLoaiHD;
                SelectedItemLoaiHopDong.ThoiHan = ThoiHan;
                SelectedItemLoaiHopDong.Luong = Luong;
                DataProvider.Ins.DB.SaveChanges();
                InitThemLoaiHopDong();
                MessageBox.Show("Bạn lưu thành công");

            });

            #endregion

            #region thêm hợp đồng

            ThemHopDongCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenLoaiHD) || string.IsNullOrEmpty(HoTen))
                    return false;

                return true;

            }, (p) =>
            {
                string mahopdong = GetCodeHopDong();
                var hopdong = new HOPDONG()
                {
                    id = mahopdong,
                    MaLoaiHD = SelectedItemLoaiHopDong.id,
                    MaNV = SelectedItemNhanVien.id,
                    NgayHD = SelectedStartDate,
                    NgayKT = SelectedEndDate,
                    isDeleted = false,
                };

                NHANVIEN nv = DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == SelectedItemNhanVien.id).FirstOrDefault();
                HOPDONG hd = DataProvider.Ins.DB.HOPDONGs.Where(x => x.MaNV == nv.id).FirstOrDefault();

                if (hd != null)
                {
                    if (hd.NgayKT < SelectedStartDate)
                    {
                        MessageBox.Show("Nhân viên còn hợp đồng");
                    }
                    else
                    {
                        DataProvider.Ins.DB.HOPDONGs.Add(hopdong);
                        DataProvider.Ins.DB.SaveChanges();
                        HopDong.Add(hopdong);
                        ListHopDong = new ObservableCollection<HOPDONG>(DataProvider.Ins.DB.HOPDONGs);
                        ListHopDong.Add(hopdong);
                        InitThemHopDong();
                        MessageBox.Show("Thêm thành công");
                    }    
                }  
            });

            #endregion

            #region tìm nhân viên

            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SearchNhanVien();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                BindingSelectionNhanVien();
            });

            #endregion
        }

        private void ThemNhanVienWindow_Closed(object sender, EventArgs e)
        {
            SearchNhanVien();
        }
    }
}