using MasterSalesDemo.Helper;
using MasterSalesDemo.Model;
using MasterSalesDemo.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace MasterSalesDemo.ViewModel
{
    public class BanHang_ViewModel : BaseViewModel
	{
        #region Variables

        #endregion

        #region Binding Variables
        private ObservableCollection<ListMatHangMua> _ListMatHang;
        public ObservableCollection<ListMatHangMua> ListMatHang
        {
            get { return _ListMatHang; }
            set { _ListMatHang = value; OnPropertyChanged(); }
        }

        private ListMatHangMua _SelectedMatHang;
        public ListMatHangMua SelectedMatHang
        {
            get { return _SelectedMatHang; }
            set { _SelectedMatHang = value; OnPropertyChanged(); }
        }
        
        private string _MaHD;
        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; OnPropertyChanged(); }
        }

        private string _IconModal;
        public string IconModal
        {
            get { return _IconModal; }
            set { _IconModal = value; OnPropertyChanged(); }
        }

        private string _MaPhieuDH;
        public string MaPhieuDH
        {
            get { return _MaPhieuDH; }
            set { _MaPhieuDH = value; OnPropertyChanged(); }
        }

        private string _SDT;
        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; OnPropertyChanged(); }
        }

        private string _TenKhachHang;
        public string TenKhachHang
        {
            get { return _TenKhachHang; }
            set { _TenKhachHang = value; OnPropertyChanged(); }
        }
        private bool _CreateReport;
        public bool CreateReport
        {
            get { return _CreateReport; }
            set { _CreateReport = value; OnPropertyChanged(); }
        }

        private string _NgayLapHD;
        public string NgayLapHD
        {
            get { return _NgayLapHD; }
            set { _NgayLapHD = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private string _TongTien;
        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; OnPropertyChanged(); }
        }

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

        private bool _EnableKhachHang;
        public bool EnableKhachHang
        {
            get { return _EnableKhachHang; }
            set { _EnableKhachHang = value; OnPropertyChanged(); }
        }

        private string _DiaChiNhan;
        public string DiaChiNhan
        {
            get { return _DiaChiNhan; }
            set { _DiaChiNhan = value; OnPropertyChanged(); }
        }

        private string _ButtonKhachHang;
        public string ButtonKhachHang
        {
            get { return _ButtonKhachHang; }
            set { _ButtonKhachHang = value; OnPropertyChanged(); }
        }

        private Visibility  _XacThuc;
        public Visibility XacThuc
        {
            get { return _XacThuc; }
            set { _XacThuc = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand GetMaHDCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand XemDatOnlineCommand { get; set; }
        public ICommand ThemGioHangCommand { get; set; }
        public ICommand BoRaGioHangCommand { get; set; }
        public ICommand DialogOK { get; set; }
        public ICommand CheckSDTCommand { get; set; }
        public ICommand KhachHangCommand { get; set; }
        #endregion

        #region
        public void LoadDatabase()
        {
            XacThuc = Visibility.Hidden;
            ButtonKhachHang = "Xác thực khách hàng";
            DiaChiNhan = "";
            EnableKhachHang = true;
            IconModal = "CheckCircleOutline";
            DialogOpen = false;
            MaHD = "";
            TongTien = "0";
            NgayLapHD = DateTime.Now.ToString("dd/MM/yyyy");
            TenNhanVien = Global.Ins.NhanVien.HoTen;
            ListMatHang = new ObservableCollection<ListMatHangMua>();
            SelectedMatHang = null;
            CreateReport = false;
            SDT = TenKhachHang = "";
            MaPhieuDH = "";
        }
        public void addGioHang()
        {
            ObservableCollection<MATHANG> _listMH = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);

            MATHANG res = null;
            foreach (var mh in _listMH)
                if (mh.TenMH == Global.Ins.TenMH)
                {
                    res = mh;
                    break;
                }

            bool flag = true;
            foreach (var item in ListMatHang)
                if (item.MatHang == res.TenMH)
                {
                    item.SoLuong = (int.Parse(item.SoLuong) + Global.Ins.SoLuongMua) + "";
                    ObservableCollection<ListMatHangMua> temp = new ObservableCollection<ListMatHangMua>(ListMatHang);
                    ListMatHang = temp;
                    flag = false;
                }

            if (flag)
            {
                int stt = ListMatHang.Count + 1;
                int sl = Global.Ins.SoLuongMua;
                decimal thanhtien = sl * res.DonGia??0;
                ListMatHangMua mh = new ListMatHangMua(stt + "", res.id, res.TenMH, res.DonVi, res.DonGia?.ToString("0,000"), sl + "", thanhtien.ToString("0,000")) ;
                ListMatHang.Add(mh);
            }
        }
        public void ThemGioHang()
        {
            ThemGioHang_Window window = new ThemGioHang_Window();
            window.ShowDialog();
            if (Global.Ins.isThemThanhCong)
            {
                DialogOpen = true;
                IconModal = "PackageVariantClosed";
                ThongBao = "Đã thêm thành công " + Global.Ins.SoLuongMua + " " + Global.Ins.TenMH + " vào giỏ hàng thành công";
                addGioHang();
                Global.Ins.isThemThanhCong = false;
            }
        }
        public void BoHang()
        {
            if (SelectedMatHang == null)
                return;
            ObservableCollection<ListMatHangMua> temp = new ObservableCollection<ListMatHangMua>();
            foreach (var item in ListMatHang)
                if (item.STT != SelectedMatHang.STT)
                {
                    ListMatHangMua mh = item;
                    mh.STT = (temp.Count + 1) + "";
                    temp.Add(mh);
                }
            ListMatHang = temp;
            TinhTien();
        }
        public void TinhTien()
        {
            double res = 0;
            foreach (var item in ListMatHang)
                res += Double.Parse(item.ThanhTien);
            TongTien = res.ToString("0,000");
            if (res == 0 || TongTien == "0,000")
                TongTien = "0";
        }
        public void TaoHoaDon()
        {
            if (String.IsNullOrWhiteSpace(MaHD))
            {
                //System.Windows.MessageBox.Show("Bạn chưa tạo mã hóa đơn");
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Bạn chưa tạo mã hóa đơn";
                return;
            }

            if (ListMatHang.Count == 0)
            {
                //System.Windows.MessageBox.Show("Không thể tạo một hóa đơn rỗng");
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Không thể tạo một hóa đơn rỗng";
                return;
            }

            HOADON hd = new HOADON()
            {
                id = Global.Ins.autoGenerateHoaDon(),
                MaPhieuDH = null,
                NgayLap = DateTime.Now,
                NgayXuat = DateTime.Now,
                MaKH = null,
                MaNV = Global.Ins.NhanVien.id,
                ThanhTien = decimal.Parse(TongTien),
                TrangThai = 1,
                isDeleted = false,
            };
            if (!String.IsNullOrWhiteSpace(MaPhieuDH))
                hd.MaPhieuDH = MaPhieuDH;
            PHIEUDATHANG pdh = Global.Ins.getPhieuDHbyMaPhieu(MaPhieuDH);

            if (pdh != null)
                pdh.TrangThai = 1;
  
            DataProvider.Ins.DB.HOADONs.Add(hd);
            DataProvider.Ins.DB.SaveChanges();
            foreach (var item in ListMatHang)
            {
                CT_HOADON ct = new CT_HOADON()
                {
                    id = Global.Ins.autoGenerateCTHoaDon(),
                    MaHD = hd.id,
                    MaMH = item.MaMH,
                    SLMua = int.Parse(item.SoLuong),
                    DonGia = decimal.Parse(item.DonGia),
                    TongTien = decimal.Parse(item.ThanhTien),
                    isDeleted = false,
                };
                DataProvider.Ins.DB.CT_HOADON.Add(ct);
                DataProvider.Ins.DB.SaveChanges();
            }
            if (CreateReport)
            {
                BanHang_PrintPreview_ViewModel vm = new BanHang_PrintPreview_ViewModel(hd.id, Global.Ins.NhanVien.HoTen, hd.ThanhTien?.ToString("0,000"), ListMatHang, TenKhachHang,DiaChiNhan);
                BanHang_PrintPreview print = new BanHang_PrintPreview(vm);
                print.Show();
            }
            LoadDatabase();
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Tạo hóa đơn thành công";
          
        }
        public void BindingPhieuDHOnline()
        {
            LoadDatabase();
            MaPhieuDH = Global.Ins.PhieuDHXuLY.id;
            if (Global.Ins.PhieuDHXuLY == null)
                return;
            PHIEUDATHANG pdh = Global.Ins.PhieuDHXuLY;
            if (pdh.KHACHHANG != null)
            {
                SDT = pdh.KHACHHANG.SDT;
                TenKhachHang = pdh.KHACHHANG.TenKH;
            }

            ObservableCollection<CT_PHIEUDATHANG> _listCTPDH = new ObservableCollection<CT_PHIEUDATHANG>(DataProvider.Ins.DB.CT_PHIEUDATHANG);
            foreach (var ctphdh in _listCTPDH)
                if (ctphdh.MaPhieuDH ==pdh.id)
                {
                    int stt = ListMatHang.Count + 1;
                    MATHANG mh = ctphdh.MATHANG;
                    string dongia = double.Parse(mh.DonGia.ToString()).ToString("0,000");
                    string tongtien = double.Parse(ctphdh.TongTien.ToString()).ToString("0,000");
                    ListMatHangMua mhmua = new ListMatHangMua(stt+"",mh.id,mh.TenMH,mh.DonVi,dongia,ctphdh.SLDat+"",tongtien);
                    ListMatHang.Add(mhmua);
                }
            DiaChiNhan = pdh.DiaChiNhan;
            TinhTien();
        }
        public void XuLyPhieuOnline()
        {
            DatOnline_Window window = new DatOnline_Window();
            Global.Ins.isXuLy = false;
            window.ShowDialog();
            if (Global.Ins.isXuLy)
            {
                BindingPhieuDHOnline();
                IconModal = "CheckCircleOutline";
                DialogOpen = true;
                ThongBao = "Đã chọn phiếu đặt hàng để xử lí";
            }
        }
        public KHACHHANG findKhachHangbySDT(string sdt)
        {
            ObservableCollection<KHACHHANG> _listKH = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            foreach (var kh in _listKH)
                if (kh.SDT == sdt)
                    return kh;
            return null;
        }
        public void CheckSDT()
        {
            KHACHHANG kh = findKhachHangbySDT(SDT);
            if (kh == null)
            {
                IconModal = "CloseCircle";
                DialogOpen = true;
                ThongBao = "Không tìm thấy khách hàng tương ứng";
                return;
            }

            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Xác thực thành công!";
            TenKhachHang = kh.TenKH;
        }
        #endregion

        public BanHang_ViewModel()
        {
            Global.Ins.isXuLy = false;
            Global.Ins.PhieuDHXuLY = null;
            LoadDatabase();

            GetMaHDCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                MaHD = Global.Ins.autoGenerateHoaDon();
            });

            HuyCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                LoadDatabase();
                Global.Ins.isXuLy = false;
                Global.Ins.PhieuDHXuLY = null;
            });

            ThemGioHangCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ThemGioHang();
                TinhTien();
            });

            BoRaGioHangCommand = new RelayCommand<Window>((p) => { if (SelectedMatHang == null) return false; return true; }, (p) => {
                BoHang();
            });

            DialogOK = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogOpen = false;
            });

            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                TaoHoaDon();
            });

            XemDatOnlineCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                XuLyPhieuOnline();
            });

            CheckSDTCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                CheckSDT();
            });
            KhachHangCommand = new RelayCommand<Window>((p) => { if (!String.IsNullOrEmpty(MaPhieuDH)) return false; return true; }, (p) => {
                if (ButtonKhachHang == "Xác thực khách hàng")
                {
                    SDT = "";
                    TenKhachHang = "";
                    EnableKhachHang = false;
                    XacThuc = Visibility.Visible;
                    ButtonKhachHang = "Hủy xác thực";
                }
                else
                {
                    SDT = "";
                    TenKhachHang = "";
                    EnableKhachHang = true;
                    XacThuc = Visibility.Hidden;
                    ButtonKhachHang = "Xác thực khách hàng";
                }
            });
        }
    }
}

