using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MasterSalesDemo.Helper;
using MasterSalesDemo.Model;
using System.Windows.Input;
using System.Windows.Controls;

namespace MasterSalesDemo.ViewModel
{
    public class Home_PageViewModel : BaseViewModel
    {
        #region Variables
        public TAIKHOAN taikhoan { get; set; }

        private string _TenNhanVien;
        public string TenNhanVien { get => _TenNhanVien; set { _TenNhanVien = value; OnPropertyChanged(); } }

        private string _TaiKhoan;
        public string TaiKhoan { get => _TaiKhoan; set { _TaiKhoan = value; OnPropertyChanged(); } }

        private string _MatKhau;
        public string MatKhau { get => _MatKhau; set { _MatKhau = value; OnPropertyChanged(); } }

        private string _MatKhauMoi;
        public string MatKhauMoi { get => _MatKhauMoi; set { _MatKhauMoi = value; OnPropertyChanged(); } }

        private string _XacNhanMatKhau;
        public string XacNhanMatKhau { get => _XacNhanMatKhau; set { _XacNhanMatKhau = value; OnPropertyChanged(); } }

        private string _ChucVu;
        public string ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        private bool _DialogOpen;
        public bool DialogOpen
        {
            get { return _DialogOpen; }
            set { _DialogOpen = value; OnPropertyChanged(); }
        }

        private string _ThongBao;
        public string ThongBao
        {
            get { return _ThongBao; }
            set { _ThongBao = value; OnPropertyChanged(); }
        }

        private string _IconModal;
        public string IconModal
        {
            get { return _IconModal; }
            set { _IconModal = value; OnPropertyChanged(); }
        }

        private Decimal _DoanhThu;
        public Decimal DoanhThu { get => _DoanhThu; set { _DoanhThu = value; OnPropertyChanged(); } }
        public class DiemBieuDoTongQuan
        {
            public String Date { get; set; }
            public Decimal Thu { get; set; }
        }
        private ObservableCollection<DiemBieuDoTongQuan> _ChartData;
        public ObservableCollection<DiemBieuDoTongQuan> ChartData
        {
            get => _ChartData;
            set { _ChartData = value; OnPropertyChanged(); }
        }
        private int _SoHoaDon;
        public int SoHoaDon
        {
            get { return _SoHoaDon; }
            set { _SoHoaDon = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommands
        public ICommand MatKhauCuCommand { get; set; }
        public ICommand MatKhauMoiCommand { get; set; }
        public ICommand XacNhanPasswordCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand DialogOK { get; set; }
        #endregion

        #region
        public PasswordBox pass1 { get; set; }
        public PasswordBox pass2 { get; set; }
        public PasswordBox pass3 { get; set; }
        #endregion
        #region Functions
        public void initTaiKhoan()
        {
            MatKhau = MatKhauMoi = XacNhanMatKhau = "";
            try
            {
                NHANVIEN nv = Global.Ins.NhanVien;

                if (nv != null)
                {
                    taikhoan = nv.TAIKHOANs.Where(x => x.MaNV == nv.id).First();
                    if (taikhoan == null)
                        return;
                    TaiKhoan = taikhoan.TenDangNhap;
                    TenNhanVien = taikhoan.NHANVIEN.HoTen;
                    ChucVu = taikhoan.NHANVIEN.CHUCVU.TenChucVu;
                }
            } 
            catch (Exception E)
            {

            }
        }

        public void DoiMatKhau()
        {
            if (taikhoan == null)
                return;
            if (taikhoan.MatKhau != MatKhau)
            {
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Mật khẩu hiện tại không chính xác";
                return;
            }
            if (MatKhauMoi == null || MatKhauMoi.Length < 6)
            {
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Mật khẩu mới phải trên 6 ký tự";
                return;
            }
            if (MatKhauMoi != XacNhanMatKhau)
            {
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Mật khẩu mới không trùng khớp";
                return;
            }

            ObservableCollection<TAIKHOAN> _listTK = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
            foreach (var tk in _listTK)
                if (tk.id == taikhoan.id)
                {
                    tk.MatKhau = MatKhauMoi;
                    break;
                }
            DataProvider.Ins.DB.SaveChanges();
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Đổi mật khẩu thành công";
        }
        public void ResetMK()
        {
            if (pass1 != null)
            {
                pass1.Password = "";
            }
            if (pass2 != null)
            {
                pass2.Password = "";
            }
            if (pass3 != null)
            {
                pass3.Password = "";
            }
        }
        #endregion

        void loadChart()
        {
            ChartData = new ObservableCollection<DiemBieuDoTongQuan>();
            Decimal doanhthucaky = 0;
            int slhoadon = 0;
            for (int i=6;i>=0;i--)
            {
                DateTime theDay = DateTime.Now.AddDays(-i);
                DiemBieuDoTongQuan diembieudo = new DiemBieuDoTongQuan();
                Decimal doanhthu = 0;
                ObservableCollection<CT_HOADON> cthoadons = new ObservableCollection<CT_HOADON>();
                foreach (var hoadon in DataProvider.Ins.DB.HOADONs.Where(x => x.NgayLap.Value.Day == theDay.Day && x.NgayLap.Value.Month == theDay.Month && x.NgayLap.Value.Year == theDay.Year))
                {
                    if (theDay.Date == DateTime.Now.Date)
                        slhoadon++;
                    foreach (var cthoadon in hoadon.CT_HOADON)
                    {
                        doanhthu += cthoadon.TongTien ?? 0;
                        doanhthucaky += cthoadon.TongTien ?? 0;
                    }
                }
                diembieudo.Date = theDay.Month.ToString() + "/" + theDay.Day.ToString();
                if (theDay.Date == DateTime.Now.Date)
                    diembieudo.Date = "Hôm nay";
                diembieudo.Thu = Math.Round(doanhthu,0);
                ChartData.Add(diembieudo);
            }
            SoHoaDon = slhoadon;
            DoanhThu = doanhthucaky;
        }
        public Home_PageViewModel()
        {
            loadChart();
            initTaiKhoan();

            MatKhauCuCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                MatKhau = p.Password;
                pass1 = p;
            });

            MatKhauMoiCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                MatKhauMoi = p.Password;
                pass2 = p;
            });

            XacNhanPasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                    return;
                XacNhanMatKhau = p.Password;
                pass3 = p;
            });

            XacNhanCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                DoiMatKhau();
                ResetMK();
            });

            DialogOK = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogOpen = false;
            });
        }
    }
}