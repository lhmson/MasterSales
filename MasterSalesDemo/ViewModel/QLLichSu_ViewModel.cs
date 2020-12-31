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
using MasterSalesDemo.Helper;



namespace MasterSalesDemo.ViewModel
{
    public class ThongTinNhanVien
    {
        public string STT { get; set; }
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public string PhongBan { get; set; }

        public ThongTinNhanVien(int stt, string MaNV, string HoTen, string PhongBan, string ChucVu)
        {
            this.STT = stt + "";
            this.MaNV = MaNV;
            this.HoTen = HoTen;
            this.PhongBan = PhongBan;
            this.ChucVu = ChucVu;
        }
    }

    public class QuaTrinhLamViec
    {
        public string STT { get; set; }
        public string ChucVu { get; set; }
        public string PhongBan { get; set; }
        public string NgayBatDau { get; set; }
        public string NgayKetThuc { get; set; }

        public QuaTrinhLamViec(int stt, string ChucVu, string PhongBan, string NgayBatDau, string NgayKetThuc)
        {
            this.STT = stt + "";
            this.ChucVu = ChucVu;
            this.PhongBan = PhongBan;
            this.NgayBatDau = NgayBatDau;
            this.NgayKetThuc = NgayKetThuc;
        }
    }

    public class QLLichSu_ViewModel : BaseViewModel
    {
        #region Binding Variables
        private ObservableCollection<string> _ListPhongBan;
        public ObservableCollection<string> ListPhongBan
        {
            get { return _ListPhongBan; }
            set { _ListPhongBan = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ThongTinNhanVien> _ListThongTinNhanVien;
        public ObservableCollection<ThongTinNhanVien> ListThongTinNhanVien
        {
            get { return _ListThongTinNhanVien; }
            set { _ListThongTinNhanVien = value; OnPropertyChanged(); }
        }

        private ObservableCollection<QuaTrinhLamViec> _ListQuaTrinhNhanVien;
        public ObservableCollection<QuaTrinhLamViec> ListQuaTrinhNhanVien
        {
            get { return _ListQuaTrinhNhanVien; }
            set { _ListQuaTrinhNhanVien = value; OnPropertyChanged(); }
        }
        private bool _DialogOpen;
        public bool DialogOpen
        {
            get { return _DialogOpen; }
            set { _DialogOpen = value; OnPropertyChanged(); }
        }
        private string _SelectedPhongBan;
        public string SelectedPhongBan
        {
            get { return _SelectedPhongBan; }
            set { _SelectedPhongBan = value; OnPropertyChanged(); }
        }

        private string _ContentCommand;
        public string ContentCommand
        {
            get { return _ContentCommand; }
            set { _ContentCommand = value; OnPropertyChanged(); }
        }

        private string _ThongBao;
        public string ThongBao
        {
            get { return _ThongBao; }
            set { _ThongBao = value; OnPropertyChanged(); }
        }

        private ThongTinNhanVien _SelectedNhanVien;
        public ThongTinNhanVien SelectedNhanVien
        {
            get { return _SelectedNhanVien; }
            set { _SelectedNhanVien = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private string _HoTen;
        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; OnPropertyChanged(); }
        }

        private string _ChucVu;
        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; OnPropertyChanged(); }
        }

        private string _HanHopDong;
        public string HanHopDong
        {
            get { return _HanHopDong; }
            set { _HanHopDong = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand SearchCommand { get; set; }
        public ICommand ChuyenCV_GiahanCommand { get; set; }
        public ICommand ThoiViecCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand DialogOK { get; set; }
        #endregion

        #region Support Functions
        public void LoadSourceComboBoxPhongBan()
        {
            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);

            ListPhongBan = new ObservableCollection<string>();
            foreach (var pb in _listPhongBan)
                ListPhongBan.Add(pb.TenPhong);
        }

        public void SearchNhanVien()
        {   
            ObservableCollection<NHANVIEN> _listNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListThongTinNhanVien.Clear();

            foreach (var nv in _listNhanVien)
            if (nv.isDeleted == false)
            {
                bool validPhongBan = false;
                bool validTen = false;
                CHUCVU chucvu = Global.Ins.getChucVubyMaNV(nv.id);
                if (SelectedPhongBan == null || (chucvu != null && chucvu.PHONGBAN.TenPhong == SelectedPhongBan))
                    validPhongBan = true;

                if (String.IsNullOrWhiteSpace(TenNhanVien) || nv.HoTen.Contains(TenNhanVien))
                    validTen = true;

                if (validTen && validPhongBan)
                {
                    int stt = _ListThongTinNhanVien.Count() + 1;
                    ThongTinNhanVien item = new ThongTinNhanVien(stt, nv.id, nv.HoTen, chucvu.PHONGBAN.TenPhong, chucvu.TenChucVu);
                    ListThongTinNhanVien.Add(item);
                }
            }
            
        }

        public void BindingSelectionNhanVien()
        {
            if (SelectedNhanVien == null)
                return;
            HoTen = SelectedNhanVien.HoTen;
            CHUCVU chucvu = Global.Ins.getChucVubyMaNV(SelectedNhanVien.MaNV);
            PHONGBAN phongban = chucvu.PHONGBAN;
            ChucVu = chucvu.TenChucVu + " - " + phongban.TenPhong;
            NHANVIEN nv = Global.Ins.getNhanVienbyMaNV(SelectedNhanVien.MaNV);
            HanHopDong = "";
            HOPDONG hopdong = Global.Ins.getHopDongbyMaNV(SelectedNhanVien.MaNV);
            if (hopdong != null)
            { 

                HanHopDong = hopdong.LOAIHOPDONG.TenLoaiHD + " - " + " Hiệu lực đến : " + hopdong.NgayKT?.ToString("dd/MM/yyyy");

                if (hopdong.NgayKT < DateTime.Now)
                {
                    HanHopDong += "  (Đã quá hạn)";
                    ContentCommand = "Gia hạn hợp đồng";
                }
                else
                    ContentCommand = "Chuyển chức vụ";
            }

            //Binding Qua trinh lam viec
            ListQuaTrinhNhanVien.Clear();
            List<LICHSUCHUCVU> _listLS = new List<LICHSUCHUCVU>(DataProvider.Ins.DB.LICHSUCHUCVUs);
            foreach (var ls in _listLS)
            {
                if (ls.isDeleted == false && ls.MaNV == nv.id)
                {
                    int stt = ListQuaTrinhNhanVien.Count() + 1;
                    string ngayBD = ls.NgayBD?.ToString("dd/MM/yyyy");
                    string ngayKT = ls.NgayKT?.ToString("dd/MM/yyyy");
                    if (ls.NgayKT == null)
                        ngayKT = "Hiện tại";
                    QuaTrinhLamViec quatrinh = new QuaTrinhLamViec(stt, ls.CHUCVU.TenChucVu, ls.CHUCVU.PHONGBAN.TenPhong, ngayBD, ngayKT);
                    ListQuaTrinhNhanVien.Add(quatrinh);
                }
            }
        }
        
        public void RefreshQuaTrinh()
        {
            SelectedNhanVien = null;
            HoTen = "";
            ChucVu = "";
            HanHopDong = "";
            ListQuaTrinhNhanVien.Clear();
        }

        public void ChuyenChucVu()
        {
            NHANVIEN nhanvien = Global.Ins.getNhanVienbyMaNV(SelectedNhanVien.MaNV);
            ChuyenChucVu windowChuyenChucVu = new ChuyenChucVu(nhanvien);
            windowChuyenChucVu.ShowDialog();
        }
        #endregion

        public QLLichSu_ViewModel()
        {
            #region Load Database
            ContentCommand = "Chuyển chức vụ";
            LoadSourceComboBoxPhongBan();
            _ListThongTinNhanVien = new ObservableCollection<ThongTinNhanVien>();
            _ListQuaTrinhNhanVien = new ObservableCollection<QuaTrinhLamViec>();
            #endregion

            SearchNhanVien();
            #region Declare Icommands
            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SearchNhanVien();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                BindingSelectionNhanVien();
            });

            ChuyenCV_GiahanCommand = new RelayCommand<Window>((p) => { if (SelectedNhanVien == null) return false; return true; }, (p) => {
                if (ContentCommand == "Chuyển chức vụ")
                {
                    ChuyenChucVu();
                    BindingSelectionNhanVien();
                    if (Global.Ins.isValid)
                    {
                        DialogOpen = true;
                        ThongBao = "Chuyển chức vụ thành công";
                    }
                }
            });

            ThoiViecCommand = new RelayCommand<Window>((p) => { if (SelectedNhanVien == null) return false; return true; }, (p) => {
                MessageBoxResult res = MessageBox.Show("Bạn có chắc xóa nhân viên này chứ! Sau khi xóa bạn sẽ không thấy nhân viên này nữa",
                    "Thôi việc nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (res == MessageBoxResult.Yes)
                {
                    NHANVIEN nhanvien = Global.Ins.getNhanVienbyMaNV(SelectedNhanVien.MaNV);
                    nhanvien.isDeleted = true;
                    nhanvien.NgayKetThuc = DateTime.Now;
                    Global.Ins.updateLichSu(nhanvien);
                    DialogOpen = true;
                    ThongBao = "Thôi việc nhân viên thành công";
                    SearchNhanVien();
                    RefreshQuaTrinh();
                    DataProvider.Ins.DB.SaveChanges();
                }

            });

            DialogOK = new RelayCommand<Window>((p) => {return true; }, (p) => {
                DialogOpen = false;
            });
            #endregion
        }

    }
}
