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
using MasterSalesDemo.Helper;
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterSalesDemo.ViewModel
{
    public class ThongTinCaNhanNV
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

        public ThongTinCaNhanNV(int stt, string MaNV, string HoTen, DateTime NgaySinh, string GioiTinh, string PhongBan, string ChucVu, string NoiSinh, TRINHDO TD, string TenTrinhDo, CHUCVU CHUCVU)
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

    public class KyNangNhanVien
    {
        public string STT { get; set; }
        public string TenKyNang { get; set; }
        public string DanhGia { get; set; }
        public string MaKN { get; set; }

        public KyNangNhanVien(int stt, DANHGIAKYNANG dgkn)
        {
            STT = stt + "";
            KYNANG kn = DataProvider.Ins.DB.KYNANGs.Where(x => x.id == dgkn.MaKyNang).FirstOrDefault();
            MaKN = kn.id;
            TenKyNang = kn.TenKyNang;
            DanhGia = dgkn.LoaiDanhGia;
        }
    }

    public class QLKiNang_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenKyNangCommand { get; set; }
        public ICommand OpenTrinhDoCommand { get; set; }
        public ICommand ThemTrinhDoCommand { get; set; }
        public ICommand SuaTrinhDoCommand { get; set; }
        public ICommand ThemKyNangCommand { get; set; }
        public ICommand SuaKyNangCommand { get; set; }
        public ICommand XoaKyNangCommand { get; set; }
        public ICommand InitKNCommand { get; set; }
        public ICommand InitTDCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand ThayDoiTrinhDoCommand { get; set; }
        public ICommand ThemKyNangNhanVienCommand { get; set; }
        public ICommand EvaluateSkillsOfStaffCommand { get; set; }
        
        ///public ICommand SelectionChangedCommand { get; set; }

        public string format(string a)
        {
            string tmp = a;
            for (int i = 1; i <= 3 - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        #region mã trình độ

        private string GetCodeTrinhDo()
        {
            ObservableCollection<TRINHDO> ListTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            int tmp = ListTrinhDo.Count();
            return "TD" + format((tmp + 1).ToString());
        }

        #endregion

        #region mã kỹ năng

        private string GetCodeKyNang()
        {
            ObservableCollection<KYNANG> ListKyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
            int tmp = ListKyNang.Count();
            return "KN" + format((tmp + 1).ToString());
        }

        #endregion

        #region init kỹ năng

        void InitKyNang() 
        {
            TenKyNang = "";
            KyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);

            ListKyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);            
            ListKyNang.Clear();
            LoadSourceListKyNang();
        }

        #endregion

        #region Init trình độ

        void InitTrinhDo()
        {
            TenTrinhDo = "";
            TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            SelectedItemTrinhDo = null;
        }

        #endregion

        #region Trình độ

        private ObservableCollection<TRINHDO> _TrinhDo;
        public ObservableCollection<TRINHDO> TrinhDo { get => _TrinhDo; set { _TrinhDo = value; OnPropertyChanged(); } }

        private string _TenTrinhDo;
        public string TenTrinhDo { get => _TenTrinhDo; set { _TenTrinhDo = value; OnPropertyChanged(); } }

        private TRINHDO _SelectedItemTrinhDo;
        public TRINHDO SelectedItemTrinhDo
        {
            get => _SelectedItemTrinhDo;
            set
            {
                _SelectedItemTrinhDo = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemTrinhDo != null)
                {
                    TenTrinhDo = SelectedItemTrinhDo.TenTrinhDo;
                }
            }
        }

        #endregion

        #region init nhân viên

        public void InitNhanVien()
        {
            _ListThongTinNhanVien = new ObservableCollection<ThongTinCaNhanNV>();
            SearchNhanVien();
        }

        #endregion

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

        private string _NhanVienDanhGia;
        public string NhanVienDanhGia { get => _NhanVienDanhGia; set { _NhanVienDanhGia = value; OnPropertyChanged(); } }

        //private NHANVIEN _SelectedItemNhanVien;
        //public NHANVIEN SelectedItemNhanVien
        //{
        //    get => _SelectedItemNhanVien;
        //    set
        //    {
        //        _SelectedItemNhanVien = value;
        //        OnPropertyChanged();
        //        if (SelectedItemNhanVien != null)
        //        {
        //            MaNhanVien = SelectedItemNhanVien.id;
        //            HoTen = SelectedItemNhanVien.HoTen;
        //            MaTrinhDo = SelectedItemNhanVien.MaTrinhDo;
        //            GioiTinh = SelectedItemNhanVien.GioiTinh;
        //            NoiSinh = SelectedItemNhanVien.NoiSinh;
        //            SelectedItemTrinhDo = SelectedItemNhanVien.TRINHDO;
        //            NgaySinh = SelectedItemNhanVien.NgaySinh.Value;
                
        //            // TenTrinhDo = SelectedItemNhanVien.TenTrinhDo;
        //        }
        //    }
        //}

        private ThongTinCaNhanNV _SelectedNhanVien;
        public ThongTinCaNhanNV SelectedNhanVien
        {
            get { return _SelectedNhanVien; }
            set
            {
                _SelectedNhanVien = value; OnPropertyChanged();
                if (SelectedNhanVien != null)
                {
                    HoTen = SelectedNhanVien.HoTen;
                    NgaySinh = SelectedNhanVien.NgaySinh;
                    GioiTinh = SelectedNhanVien.GioiTinh;
                    NoiSinh = SelectedNhanVien.NoiSinh;
                    TenTrinhDo = SelectedNhanVien.TenTrinhDo;
                    SelectedItemTrinhDo = SelectedNhanVien.TD;
                    MaTrinhDo = SelectedNhanVien.TD.id;
                    MaChucVu = SelectedNhanVien.CHUCVU.id;
                }
            }
        }

        private ObservableCollection<ThongTinCaNhanNV> _ListThongTinNhanVien;
        public ObservableCollection<ThongTinCaNhanNV> ListThongTinNhanVien
        {
            get { return _ListThongTinNhanVien; }
            set { _ListThongTinNhanVien = value; OnPropertyChanged(); }
        }

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
                if (td.id == MaTD)
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

        private string _ContentCommand;
        public string ContentCommand
        {
            get { return _ContentCommand; }
            set { _ContentCommand = value; OnPropertyChanged(); }
        }

        private string _ContentEditCommand;
        public string ContentEditCommand
        {
            get { return _ContentEditCommand; }
            set { _ContentEditCommand = value; OnPropertyChanged(); }
        }

        public void ThemNhanVienVaoList(NHANVIEN nv)
        {
            if (nv.isDeleted==true)
                return;

            bool validPhongBan = false;
            bool validTen = false;
            CHUCVU chucvu = getChucVubyMaNV(nv.MaChucVu);
            TRINHDO trinhdo = getTrinhdobyMaNV(nv.MaTrinhDo);
            if (SelectedPhongBan == null || SelectedPhongBan=="Tất cả" || (chucvu != null && chucvu.PHONGBAN.TenPhong == SelectedPhongBan))
                validPhongBan = true;

            if (String.IsNullOrWhiteSpace(TenNhanVien) || nv.HoTen.Contains(TenNhanVien))
                validTen = true;

            if (validTen && validPhongBan)
            {
                int stt = _ListThongTinNhanVien.Count() + 1;
                ThongTinCaNhanNV item = new ThongTinCaNhanNV(stt, nv.id, nv.HoTen, nv.NgaySinh.Value, nv.GioiTinh, chucvu.PHONGBAN.TenPhong, chucvu.TenChucVu, nv.NoiSinh, trinhdo, trinhdo.TenTrinhDo, chucvu);
                ListThongTinNhanVien.Add(item);
            }
        }

        #endregion

        #region Kỹ năng

        private ObservableCollection<KYNANG> _ListKyNang;
        public ObservableCollection<KYNANG> ListKyNang { get => _ListKyNang; set { _ListKyNang = value; OnPropertyChanged(); } }

        private ObservableCollection<KYNANG> _KyNang;
        public ObservableCollection<KYNANG> KyNang { get => _KyNang; set { _KyNang = value; OnPropertyChanged(); } }

        private string _TenKyNang;
        public string TenKyNang { get => _TenKyNang; set { _TenKyNang = value; OnPropertyChanged(); } }

        private string _MaKyNang;
        public string MaKyNang { get => _MaKyNang; set { _MaKyNang = value; OnPropertyChanged(); } }

        private KYNANG _SelectedItemKyNang;
        public KYNANG SelectedItemKyNang
        {
            get => _SelectedItemKyNang;
            set
            {
                _SelectedItemKyNang = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemKyNang != null)
                {
                    TenKyNang = SelectedItemKyNang.TenKyNang;
                    MaKyNang = SelectedItemKyNang.id;
                }
            }
        }

        private DANHGIAKYNANG _SelectedKyNang;
        public DANHGIAKYNANG SelectedKyNang
        {
            get { return _SelectedKyNang; }
            set
            {
                _SelectedKyNang = value; OnPropertyChanged();
                if (SelectedNhanVien != null)
                {
                    TenKyNang = SelectedKyNang.KYNANG.TenKyNang;
                }
            }
        }

        private ObservableCollection<KyNangNhanVien> _ListEvaluateSkillsOfStaff;
        public ObservableCollection<KyNangNhanVien> ListEvaluateSkillsOfStaff
        {
            get { return _ListEvaluateSkillsOfStaff; }
            set 
            {
                _ListEvaluateSkillsOfStaff = value; 
                OnPropertyChanged();  
            }
        }

        private ObservableCollection<DANHGIAKYNANG> _list_DGKN;
        public ObservableCollection<DANHGIAKYNANG> list_DGKN
        {
            get { return _list_DGKN; }
            set
            {
                _list_DGKN = value;
                OnPropertyChanged();
            }
        }

        private KyNangNhanVien _SelectedItemKyNangNhanVien;
        public KyNangNhanVien SelectedItemKyNangNhanVien
        {
            get { return _SelectedItemKyNangNhanVien; }
            set
            {
                _SelectedItemKyNangNhanVien = value; OnPropertyChanged();
                if (SelectedItemKyNangNhanVien != null)
                {
                    KYNANG kn = DataProvider.Ins.DB.KYNANGs.Where(x => x.TenKyNang ==SelectedItemKyNangNhanVien.TenKyNang).FirstOrDefault();
                    MaKyNang = kn.id;
                }    
            }
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

            ListPhongBan.Add("Tất cả");
        }

        #endregion

        public void display_CTKN()
        {
            ListEvaluateSkillsOfStaff = new ObservableCollection<KyNangNhanVien>();

            if (SelectedNhanVien == null) return;
            string manv = SelectedNhanVien.MaNV;

            ObservableCollection<DANHGIAKYNANG> ListDGKyNang = new ObservableCollection<DANHGIAKYNANG>(DataProvider.Ins.DB.DANHGIAKYNANGs);
            int stt = 1;
            foreach (var dgkn in ListDGKyNang)
                if (dgkn.MaNV == manv)
                {
                    KyNangNhanVien temp = new KyNangNhanVien(stt, dgkn);
                    stt++;
                    ListEvaluateSkillsOfStaff.Add(temp);
                }
        }

        public void ThemKyNang()
        {
            NHANVIEN nhanvien = Global.Ins.getNhanVienbyMaNV(SelectedNhanVien.MaNV);
            DanhGiaKyNang wd = new DanhGiaKyNang(nhanvien);
            wd.Closed += ThemKyNangWindow_Closed;
            wd.ShowDialog();
        }

        public void SuaDanhGia()
        {
            DANHGIAKYNANG temp = new DANHGIAKYNANG();

            ObservableCollection<DANHGIAKYNANG> ListDGKyNang = new ObservableCollection<DANHGIAKYNANG>(DataProvider.Ins.DB.DANHGIAKYNANGs);

            foreach (var dgkn in ListDGKyNang)
            {
                if (dgkn.MaNV == SelectedNhanVien.MaNV && dgkn.MaKyNang == MaKyNang)
                {
                    temp = dgkn;
                    break;
                }
            }

            SuaDanhGiaKN wd = new SuaDanhGiaKN(temp);
            wd.Closed += SuaDanhGia_Closed;
            wd.ShowDialog();
        }

        private void ThemKyNangWindow_Closed(object sender, EventArgs e)
        {
            display_CTKN();
        }

        private void SuaDanhGia_Closed(object sender, EventArgs e)
        {
            display_CTKN();
        }

        public void LoadSourceListKyNang()
        {
            ObservableCollection<KYNANG> _listKynang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);

            foreach (var kn in _listKynang)
                if (kn.isDeleted == false)
                    ListKyNang.Add(kn);
        }

        public QLKiNang_ViewModel()
        {
            InitKyNang();
            InitTrinhDo();
            InitNhanVien();
            if (SelectedNhanVien!= null)
                display_CTKN();
            ContentCommand = "Thêm kỹ năng";
            ContentEditCommand = "Đánh giá";

            ObservableCollection<DANHGIAKYNANG> ListDanhGiaKyNang = new ObservableCollection<DANHGIAKYNANG>(DataProvider.Ins.DB.DANHGIAKYNANGs);
            LoadSourceComboBoxPhongBan();

            #region đóng mở window

           OpenKyNangCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                KyNang window = new KyNang();
                window.ShowDialog();
            });

            OpenTrinhDoCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TrinhDo window = new TrinhDo();
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                InitKyNang();
                InitTrinhDo();
                var exit = p as Window;
                exit.Close();
            });

            #endregion

            #region thêm trình độ

            ThemTrinhDoCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenTrinhDo))
                    return false;

                var tentrinhdo = DataProvider.Ins.DB.TRINHDOes.Where(x => x.TenTrinhDo.ToLower() == TenTrinhDo.ToLower());
                if (tentrinhdo == null || tentrinhdo.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string matrinhdo = GetCodeTrinhDo();
                var trinhdo = new TRINHDO()
                {
                    id = matrinhdo,
                    TenTrinhDo = TenTrinhDo,
                    isDeleted= false,
                };

                DataProvider.Ins.DB.TRINHDOes.Add(trinhdo);
                DataProvider.Ins.DB.SaveChanges();
                TrinhDo.Add(trinhdo);
                TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
                TrinhDo.Add(trinhdo);
                InitTrinhDo();
                MessageBox.Show("Thêm thành công");
                var exit = p as Window;
                exit.Close();
            });

            #endregion

            #region thêm kỹ năng

            ThemKyNangCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenKyNang))
                    return false;

                var tenkynang = DataProvider.Ins.DB.KYNANGs.Where(x => x.TenKyNang.ToLower() == TenKyNang.ToLower());
                if (tenkynang == null || tenkynang.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string makynang = GetCodeKyNang();
                var kynang = new KYNANG()
                {
                    id = makynang,
                    TenKyNang = TenKyNang,
                    isDeleted = false,
                };

                DataProvider.Ins.DB.KYNANGs.Add(kynang);
                DataProvider.Ins.DB.SaveChanges();
                KyNang.Add(kynang);
                KyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
                ListKyNang.Add(kynang);
                InitKyNang();
                MessageBox.Show("Thêm thành công");
                var exit = p as Window;
                exit.Close();
            });

            #endregion

            #region sửa kỹ năng

            SuaKyNangCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemKyNang == null )
                    return false;
                return true;

            }, (p) =>
            {
                var kynang = DataProvider.Ins.DB.KYNANGs.Where(x => x.id == SelectedItemKyNang.id).SingleOrDefault();
                kynang.TenKyNang = TenKyNang;
                DataProvider.Ins.DB.SaveChanges();
                InitKyNang();
                MessageBox.Show("Bạn lưu thành công");
                var exit = p as Window;
                exit.Close();
            });
            #endregion

            #region sửa trình độ

            SuaTrinhDoCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemTrinhDo == null)
                    return false;
                return true;

            }, (p) =>
            {
                var trinhdo = DataProvider.Ins.DB.TRINHDOes.Where(x => x.id == SelectedItemTrinhDo.id).SingleOrDefault();
                trinhdo.TenTrinhDo = TenTrinhDo;
                DataProvider.Ins.DB.SaveChanges();
                InitTrinhDo();
                MessageBox.Show("Bạn lưu thành công");
                var exit = p as Window;
                exit.Close();
            });
            #endregion

            #region init kỹ năng

            InitKNCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                InitKyNang();
            });

            #endregion

            #region init trình độ

            InitTDCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                InitTrinhDo();
            });

            #endregion

            #region tìm nhân viên

            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SearchNhanVien();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                BindingSelectionNhanVien();
                display_CTKN();
            });

            #endregion

            #region thay đổi trình độ

            ThayDoiTrinhDoCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemTrinhDo == null)
                    return false;
                var nhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == SelectedNhanVien.MaNV).SingleOrDefault();

                if (String.Compare(SelectedItemTrinhDo.id, nhanvien.TRINHDO.id) == 1)
                    return true;
                else
                    return false;
            }, (p) =>
            {
                var nhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == SelectedNhanVien.MaNV).SingleOrDefault();

                if (String.Compare(nhanvien.TRINHDO.id, SelectedItemTrinhDo.id) == 1)
                {
                    MessageBox.Show("Phải chọn trình độ cao hơn");
                }
                else
                {
                    nhanvien.MaTrinhDo = SelectedItemTrinhDo.id;
                    DataProvider.Ins.DB.SaveChanges();
                    SearchNhanVien();
                    OnPropertyChanged("SelectedNhanVien");
                    InitNhanVien();
                    //InitMH();
                    MessageBox.Show("Bạn đã chỉnh sửa thành công");
                }
            });

            #endregion

            #region thêm kỹ năng nhân viên

            ThemKyNangNhanVienCommand = new RelayCommand<Window>((p) => { if (SelectedNhanVien == null) return false; return true; }, (p) => {
                if (ContentCommand == "Thêm kỹ năng")
                {
                    ThemKyNang();
                }
            });

            #endregion

            #region sửa đánh giá kỹ năng

            EvaluateSkillsOfStaffCommand = new RelayCommand<Window>((p) => { if (SelectedItemKyNangNhanVien == null) return false; return true; }, (p) => {
                if (ContentEditCommand == "Đánh giá")
                {
                    SuaDanhGia();
                }
            });

            #endregion

            #region xóa kĩ năng hệ thống

            XoaKyNangCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemKyNang == null)
                    return false;
                return true;

            }, (p) =>
            {
                var kynang = DataProvider.Ins.DB.KYNANGs.Where(x => x.id == SelectedItemKyNang.id).SingleOrDefault();
                kynang.isDeleted = true;
                DataProvider.Ins.DB.SaveChanges();
                ListKyNang.Remove(kynang);
                //InitKyNang();
                MessageBox.Show("Bạn đã xóa thành công");
                var exit = p as Window;
                exit.Close();
            });

            #endregion
        }
    }
}
