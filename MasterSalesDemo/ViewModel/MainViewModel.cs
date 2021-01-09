using MasterSalesDemo.Helper;
using MasterSalesDemo.Model;
using MasterSalesDemo.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;

namespace MasterSalesDemo.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Variable

        static public DispatcherTimer _timer;

        private bool _Selected_HOME;
        public bool Selected_HOME
        {
            get => _Selected_HOME;
            set { _Selected_HOME = value; OnPropertyChanged(); }
        }

        private bool _Selected_DangXuat;
        public bool Selected_DangXuat
        {
            get => _Selected_DangXuat;
            set { _Selected_DangXuat = value; OnPropertyChanged(); }
        }
        #region Enable
        private bool _Enable_Home;
        public bool Enable_Home
        {
            get => _Enable_Home;
            set { _Enable_Home = value; OnPropertyChanged(); }
        }

        private bool _Enable_QLTuyenDung;
        public bool Enable_QLTuyenDung
        {
            get => _Enable_QLTuyenDung;
            set { _Enable_QLTuyenDung = value; OnPropertyChanged(); }
        }

        private bool _Enable_QLLuongThuong;
        public bool Enable_QLLuongThuong
        {
            get => _Enable_QLLuongThuong;
            set { _Enable_QLLuongThuong = value; OnPropertyChanged(); }
        }

        private bool _Enable_QLLichSu;
        public bool Enable_QLLichSu
        {
            get => _Enable_QLLichSu;
            set { _Enable_QLLichSu = value; OnPropertyChanged(); }
        }

        private bool _Enable_QLKiNang;
        public bool Enable_QLKiNang
        {
            get => _Enable_QLKiNang;
            set { _Enable_QLKiNang = value; OnPropertyChanged(); }
        }

        private bool _Enable_BanHang;
        public bool Enable_BanHang
        {
            get => _Enable_BanHang;
            set { _Enable_BanHang = value; OnPropertyChanged(); }
        }

        private bool _Enable_TraCuu;
        public bool Enable_TraCuu
        {
            get => _Enable_TraCuu;
            set { _Enable_TraCuu = value; OnPropertyChanged(); }
        }

        private bool _Enable_QLKhachHang;
        public bool Enable_QLKhachHang
        {
            get => _Enable_QLKhachHang;
            set { _Enable_QLKhachHang = value; OnPropertyChanged(); }
        }

        private bool _Enable_TDQD;
        public bool Enable_TDQD
        {
            get => _Enable_TDQD;
            set { _Enable_TDQD = value; OnPropertyChanged(); }

        }

        private bool _Enable_QLNS;
        public bool Enable_QLNS
        {
            get => _Enable_QLNS;
            set { _Enable_QLNS = value; OnPropertyChanged(); }

        }

        private bool _Enable_BCDS;
        public bool Enable_BCDS
        {
            get => _Enable_BCDS;
            set { _Enable_BCDS = value; OnPropertyChanged(); }
        }
        #endregion

        private Page _FrameContent;

        public Page FrameContent
        {
            get { return _FrameContent; }
            set { _FrameContent = value; OnPropertyChanged(); }
        }

        #region ICommand
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand Home_Page_SelectedCommand { get; set; }
        public ICommand QLTuyenDung_Page_SelectedCommand { get; set; }
        public ICommand QLLuongThuong_Page_SelectedCommand { get; set; }
        public ICommand QLLichSu_Page_SelectedCommand { get; set; }
        public ICommand QLKiNang_Page_SelectedCommand { get; set; }
        public ICommand BanHang_Page_SelectedCommand { get; set; }
        public ICommand TraCuu_Page_SelectedCommand { get; set; }
        public ICommand QLKhachHang_Page_SelectedCommand { get; set; }
        public ICommand BaoCaoDoanhSo_Page_SelectedCommand { get; set; }
        public ICommand ThayDoiQuyDinh_Page_SelectedCommand { get; set; }
        public ICommand QuanLyNhanSu_Page_SelectedCommand { get; set; }
        public ICommand CaiDatKhac_Page_SelectedCommand { get; set; }
        public ICommand DangXuat_SelectedCommand { get; set; }
        #endregion

        #endregion
        // tool tip of navigation
        #region Tooltip
        private string _Home_Tooltip;
        public string Home_Tooltip
        {
            get => _Home_Tooltip;
            set { _Home_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLTuyenDung_Tooltip;
        public string QLTuyenDung_Tooltip
        {
            get => _QLTuyenDung_Tooltip;
            set { _QLTuyenDung_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLLuongThuong_Tooltip;
        public string QLLuongThuong_Tooltip
        {
            get => _QLLuongThuong_Tooltip;
            set { _QLLuongThuong_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLLichSu_Tooltip;
        public string QLLichSu_Tooltip
        {
            get => _QLLichSu_Tooltip;
            set { _QLLichSu_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLKiNang_Tooltip;
        public string QLKiNang_Tooltip
        {
            get => _QLKiNang_Tooltip;
            set { _QLKiNang_Tooltip = value; OnPropertyChanged(); }
        }

        private string _BanHang_Tooltip;
        public string BanHang_Tooltip
        {
            get => _BanHang_Tooltip;
            set { _BanHang_Tooltip = value; OnPropertyChanged(); }
        }

        private string _TraCuu_Tooltip;
        public string TraCuu_Tooltip
        {
            get => _TraCuu_Tooltip;
            set { _TraCuu_Tooltip = value; OnPropertyChanged(); }
        }

        private string _BaoCaoDS_Tooltip;
        public string BaoCaoDS_Tooltip
        {
            get => _BaoCaoDS_Tooltip;
            set { _BaoCaoDS_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLKhachHang_Tooltip;
        public string QLKhachHang_Tooltip
        {
            get => _QLKhachHang_Tooltip;
            set { _QLKhachHang_Tooltip = value; OnPropertyChanged(); }
        }

        private string _TDQD_Tooltip;
        public string TDQD_Tooltip
        {
            get => _TDQD_Tooltip;
            set { _TDQD_Tooltip = value; OnPropertyChanged(); }
        }

        private string _QLNS_Tooltip;
        public string QLNS_Tooltip
        {
            get => _QLNS_Tooltip;
            set { _QLNS_Tooltip = value; OnPropertyChanged(); }
        }


        #endregion


        public bool isLoaded = false;

        #region Function
        private void Init_Button_User(TAIKHOAN user)
        {
            Init_Button();
            ObservableCollection<PHANQUYEN> list_PhanQuyen = new ObservableCollection<PHANQUYEN>(DataProvider.Ins.DB.PHANQUYENs);
            foreach (var item in list_PhanQuyen)
            {
                if (item.MaChucVu == user.NHANVIEN.MaChucVu)
                {
                    Init_Valid_Button(item.MaChucNang);
                    Init_Valid_Tooltip(item.MaChucNang);
                }
            }
        }

        private void Init_Button()
        {
            //Chinh sua phan quyen bao cao luong thuong
            Enable_Home = Enable_QLTuyenDung = Enable_QLLuongThuong = Enable_QLLichSu = Enable_QLKiNang = Enable_BanHang = Enable_TraCuu = Enable_QLKhachHang = Enable_BCDS = Enable_QLNS = Enable_TDQD = false;
            Enable_Home = true;
            // tooltip handle
            Home_Tooltip = QLTuyenDung_Tooltip = QLLuongThuong_Tooltip = QLLichSu_Tooltip = QLKiNang_Tooltip = BanHang_Tooltip = QLKhachHang_Tooltip 
                = TraCuu_Tooltip = BaoCaoDS_Tooltip = QLNS_Tooltip = TDQD_Tooltip = "Không thể truy cập";
            Home_Tooltip = "Có thể truy cập";
        }

        private void Init_Valid_Button(string maChucNang)
        {
            switch (maChucNang)
            {
                
                case "CN001":
                    Enable_QLTuyenDung = true;
                    break;
                case "CN002":
                    Enable_QLLuongThuong = true;
                    break;
                case "CN003":
                    Enable_QLLichSu = true;
                    break;
                case "CN004":
                    Enable_QLKiNang = true;
                    break;
                case "CN005":
                    Enable_TraCuu = true;
                    break;
                case "CN006":
                    Enable_BanHang = true;
                    break;
                case "CN007":
                    Enable_QLKhachHang = true;
                    break;
                case "CN008":
                    Enable_BCDS = true;
                    break;
                case "CN009":
                    Enable_QLNS = true;
                    break;
                case "CN010":
                    Enable_TDQD = true;
                    break;
                default:
                    break;
            }
        }

        // tool tip
        private void Init_Valid_Tooltip(string maChucNang)
        {
            switch (maChucNang)
            {
                case "CN001":
                    QLTuyenDung_Tooltip = "Có thể truy cập";
                    break;
                case "CN002":
                    QLLuongThuong_Tooltip = "Có thể truy cập";
                    break;
                case "CN003":
                    QLLichSu_Tooltip = "Có thể truy cập";
                    break;
                case "CN004":
                    QLKiNang_Tooltip = "Có thể truy cập";
                    break;
                case "CN005":
                    TraCuu_Tooltip = "Có thể truy cập";
                    break;
                case "CN006":
                    BanHang_Tooltip = "Có thể truy cập";
                    break;
                case "CN007":
                    QLKhachHang_Tooltip = "Có thể truy cập";
                    break;
                case "CN008":
                    BaoCaoDS_Tooltip = "Có thể truy cập";
                    break;
                case "CN009":
                    QLNS_Tooltip = "Có thể truy cập";
                    break;
                case "CN010":
                    TDQD_Tooltip = "Có thể truy cập";
                    break;
                default:
                    break;
            }
        }

        static public void Start_Timer()
        {
            _timer.Start();
        }
        static public void LogOut()
        {

        }
        public ICommand Home_Select { get; set; }
        #endregion
        public MainViewModel() // all main page handling goes there
        {
            updateThongKeNgay();
            // set bang true sau nay phai sua hihi
            Init_Button();
            //Selected_HOME = true;
            //Selected_DangXuat = false;
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                //if (p == null) return;
                p.Hide(); // main view hide in login window

                // cmt de chay main, sau nay code cho login sau hihi
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                isLoaded = true;

                //if (loginWindow.DataContext == null) return;
                //var loginVM = loginWindow.DataContext as LoginViewModel;
                //if (loginVM.isLogin)
                //{
                p.Show();
                //    LoadRemainsData(); // show remain table
                //}
                //else
                //{

                //}

                _timer = new DispatcherTimer(DispatcherPriority.Render);
                _timer.Interval = TimeSpan.FromSeconds(1);
                _timer.Tick += (sender, args) =>
                {
                    if (LoginViewModel.TaiKhoanSuDung != null)
                    {
                        Init_Button_User(LoginViewModel.TaiKhoanSuDung);

                        _timer.Stop();
                    }
                };
                _timer.Start();

                FrameContent = new Home_Page();

            });

            Home_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = true;
                //Selected_DangXuat = false;
                FrameContent = new Home_Page();
                FrameContent.DataContext = new Home_PageViewModel();
            });

            QLTuyenDung_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) =>
            {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QLTuyenDung_Page();
                FrameContent.DataContext = new QLTuyenDung_ViewModel();
            });

            QLLuongThuong_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) =>
            {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QLLuongThuong_Page();
                FrameContent.DataContext = new QLLuongThuong_ViewModel();
            });

            QLLichSu_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) =>
            {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QLLichSu_Page();
                FrameContent.DataContext = new QLLichSu_ViewModel();
            });

            QLKiNang_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) =>
            {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QLKiNang_Page();
                FrameContent.DataContext = new QLKiNang_ViewModel();
            });

            BanHang_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new BanHang_Page();
                FrameContent.DataContext = new BanHang_ViewModel();
            });
            TraCuu_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new TraCuu_Page();
                FrameContent.DataContext = new TraCuu_ViewModel();
            });

            QLKhachHang_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QLKhachHang_Page();
                FrameContent.DataContext = new QLKhachHang_ViewModel();
            });
            BaoCaoDoanhSo_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new BaoCaoDoanhSo_Page();
                FrameContent.DataContext = new BaoCaoDoanhSo_ViewModel();
            });
            ThayDoiQuyDinh_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new ThayDoiQuyDinh_Page();
                FrameContent.DataContext = new ThayDoiQuyDinh_ViewModel();
            });
            QuanLyNhanSu_Page_SelectedCommand = new RelayCommand<HamburgerMenu.HamburgerMenu>((p) => { return true; }, (p) => {
                //Selected_HOME = false;
                //Selected_DangXuat = false;
                FrameContent = new QuanLyNhanSu_Page();
                FrameContent.DataContext = new QuanLyNhanSu_ViewModel();
            });
            CaiDatKhac_Page_SelectedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                FrameContent = new CaiDatKhac_Page();
                FrameContent.DataContext = new CaiDatKhac_Page();
            });
            DangXuat_SelectedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                System.Windows.Forms.DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn có chắc đăng xuất tài khoản này không?", "Đăng xuất", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                if (kq == System.Windows.Forms.DialogResult.Yes)
                {
                    // restart the program
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                    //if (LoginViewModel.Quay != null)
                    //{
                    //    ObservableCollection<QUAY> list_quay = new ObservableCollection<QUAY>(DataProvider.Ins.DB.QUAYs);
                    //    foreach (var items in list_quay)
                    //        if (items.MaQuay == LoginViewModel.Quay.MaQuay)
                    //        {
                    //            items.DangSuDung = 0;
                    //            DataProvider.Ins.DB.SaveChanges();
                    //        }
                    //}
                    Application.Current.Shutdown();
                }
            });
        }
        public void updateThongKeNgay()
        {
            //var ThongKeNgay = new ObservableCollection<THONGKENGAY>(DataProvider.Ins.DB.THONGKENGAYs);
            //DateTime NgayKhaiTruong = new DateTime(2020, 09, 21);
            //DateTime LastUpdatedDay = NgayKhaiTruong.AddDays(-1);
            //int CountThongKe = (from tk in ThongKeNgay
            //                    select tk).Count();
            //if (CountThongKe > 0)
            //    LastUpdatedDay = (from tk in ThongKeNgay
            //                      select tk).Last().Ngay;
            //for (DateTime i = LastUpdatedDay.AddDays(1); i < DateTime.Today; i = i.AddDays(1))
            //{
            //    CountThongKe++;
            //    THONGKENGAY thongkengay = new THONGKENGAY()
            //    {
            //        MaThongKe = "TKN" + "000".Substring(0, 4 - CountThongKe.ToString().Length) + CountThongKe.ToString(),
            //        Ngay = i,
            //    };
            //    DataProvider.Ins.DB.THONGKENGAYs.Add(thongkengay);
            //    DataProvider.Ins.DB.SaveChanges();
            //    var MatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            //    var ChiTietThongKe = new ObservableCollection<CT_THONGKENGAY>(DataProvider.Ins.DB.CT_THONGKENGAY);
            //    int CountChiTietThongKe = (from cttk in ChiTietThongKe
            //                               select cttk).Count();
            //    var TheKho = new ObservableCollection<THEKHO>(DataProvider.Ins.DB.THEKHOes);
            //    var ChiTietTheKho = new ObservableCollection<CT_THEKHO>(DataProvider.Ins.DB.CT_THEKHO);
            //    var PhieuNhap = new ObservableCollection<PHIEUNHAPKHO>(DataProvider.Ins.DB.PHIEUNHAPKHOes);
            //    var ChiTietPhieuNhap = new ObservableCollection<CT_PHIEUNHAPKHO>(DataProvider.Ins.DB.CT_PHIEUNHAPKHO);
            //    var PhieuXuat = new ObservableCollection<PHIEUXUATKHO>(DataProvider.Ins.DB.PHIEUXUATKHOes);
            //    var ChiTietPhieuXuat = new ObservableCollection<CT_PHIEUXUATKHO>(DataProvider.Ins.DB.CT_PHIEUXUATKHO);
            //    var HoaDon = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            //    var ChiTietHoaDon = new ObservableCollection<CT_HOADON>(DataProvider.Ins.DB.CT_HOADON);
            //    foreach (var item in MatHang)
            //    {
            //        CountChiTietThongKe++;
            //        var AllPhieuNhap = (from ctpn in ChiTietPhieuNhap
            //                            join pn in PhieuNhap on ctpn.MaPhieuNhapKho equals pn.MaPhieuNhapKho
            //                            where (ctpn.MaMH == item.MaMH && pn.NgayLap.Date == i.Date && pn.Duyet == 1)
            //                            select ctpn);
            //        int TongNhap = 0;
            //        if (AllPhieuNhap.Count() > 0)
            //            TongNhap += AllPhieuNhap.Select(a => a.SoLuong).Sum();
            //        var AllPhieuXuat = (from ctpx in ChiTietPhieuXuat
            //                            join px in PhieuXuat on ctpx.MaPhieuXK equals px.MaPhieuXK
            //                            where (ctpx.MaMH == item.MaMH && px.NgayLap.Date == i.Date && px.TrangThai == 1)
            //                            select ctpx);
            //        int TongXuat = 0;
            //        if (AllPhieuXuat.Count() > 0)
            //            TongXuat += AllPhieuXuat.Select(a => a.SoLuong).Sum();
            //        var LayTon = (from tk in TheKho
            //                      where (tk.MaMH == item.MaMH)
            //                      select tk);
            //        int SoLuongTon = 0;
            //        if (LayTon.Count() > 0)
            //            SoLuongTon += LayTon.First().SoLuongTonKho;
            //        var LayThu = (from cthd in ChiTietHoaDon
            //                      join hd in HoaDon on cthd.MaHoaDon equals hd.MaHoaDon
            //                      where (hd.NgayLap.Date == i.Date && cthd.MaMH == item.MaMH)
            //                      select cthd);
            //        decimal TongThu = 0;
            //        foreach (var moihoadon in LayThu)
            //        {
            //            TongThu += moihoadon.SoLuong * moihoadon.DonGiaBan;
            //        }
            //        decimal TongChi = 0;
            //        foreach (var moihoadon in AllPhieuNhap)
            //        {
            //            TongChi += moihoadon.DonGiaNhap * moihoadon.SoLuong;
            //        }
            //        CT_THONGKENGAY ctthongkengay = new CT_THONGKENGAY()
            //        {
            //            MaCTTK = "CTTKN" + "00000".Substring(0, 5 - CountChiTietThongKe.ToString().Length) + CountChiTietThongKe.ToString(),
            //            MaThongKe = thongkengay.MaThongKe,
            //            MaMH = item.MaMH,
            //            Nhap = TongNhap,
            //            Xuat = TongXuat,
            //            Ton = SoLuongTon,
            //            Thu = TongThu,
            //            Chi = TongChi,
            //        };
            //        DataProvider.Ins.DB.CT_THONGKENGAY.Add(ctthongkengay);
            //        DataProvider.Ins.DB.SaveChanges();
            //    };
            //}

        }

    }
}
