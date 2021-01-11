using MasterSalesDemo.Helper;
using MasterSalesDemo.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MasterSalesDemo.ViewModel
{
    public class CAUHOIKHACHHANG
    {
        public string STT { get; set; }
        public string NgayDat { get; set; }
        public string KhachHang { get; set; }
        public string TrangThai { get; set; }
        public string NguoiTraLoi { get; set; }
        public string ID { get; set; }

        public CAUHOIKHACHHANG (int stt, TuVanKH tuvan)
        {
            STT = stt + "";
            NgayDat = tuvan.NgayDat?.ToString("dd/MM/yyyy");
            KhachHang = tuvan.KHACHHANG.TenKH;
            if (String.IsNullOrEmpty(tuvan.TraLoi))
            {
                TrangThai = "Chưa trả lời";
                NguoiTraLoi = "Không có";
            }
            else
            {
                TrangThai = "Đã trả lời";
                NguoiTraLoi = tuvan.NHANVIEN.HoTen;
            }
            ID = tuvan.id;
        }
    }
    public class QLKhachHang_ViewModel : BaseViewModel
    {
        #region Variables

        #endregion

        #region Binding Variables
        private ObservableCollection<CAUHOIKHACHHANG> _ListTuVan;
        public ObservableCollection<CAUHOIKHACHHANG> ListTuVan
        {
            get { return _ListTuVan; }
            set { _ListTuVan = value; OnPropertyChanged(); }
        }

        private CAUHOIKHACHHANG _SelectedTuVan;
        public CAUHOIKHACHHANG SelectedTuVan
        {
            get { return _SelectedTuVan; }
            set { _SelectedTuVan = value; OnPropertyChanged(); }
        }

        private string _TenKhachHang;
        public string TenKhachHang
        {
            get { return _TenKhachHang; }
            set { _TenKhachHang = value; OnPropertyChanged(); }
        }

        private string _IconModal;
        public string IconModal
        {
            get { return _IconModal; }
            set { _IconModal = value; OnPropertyChanged(); }
        }

        private string _NgayDatCauHoi;
        public string NgayDatCauHoi
        {
            get { return _NgayDatCauHoi; }
            set { _NgayDatCauHoi = value; OnPropertyChanged(); }
        }

        private string _NgayTraLoiLanCuoi;
        public string NgayTraLoiLanCuoi
        {
            get { return _NgayTraLoiLanCuoi; }
            set { _NgayTraLoiLanCuoi = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private string _CauHoi;
        public string CauHoi
        {
            get { return _CauHoi; }
            set { _CauHoi = value; OnPropertyChanged(); }
        }

        private string _TraLoi;
        public string TraLoi
        {
            get { return _TraLoi; }
            set { _TraLoi = value; OnPropertyChanged(); }
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
        #endregion

        #region Icommand
        public ICommand LuuThayDoiCommand { get; set; }
        public ICommand DialogOK { get; set; }
        public ICommand CauHoiSelectionChangedCommand { get; set; }
        #endregion

        #region
        public TuVanKH findTuVan(string MaTuVan)
        {
            ObservableCollection<TuVanKH> _listTuVan = new ObservableCollection<TuVanKH>(DataProvider.Ins.DB.TuVanKHs);
            foreach (var tv in _listTuVan)
                if (tv.id == MaTuVan)
                    return tv;

            return null;
        }
        public void LoadDatabase()
        {
            ObservableCollection<TuVanKH> _listTuVan = new ObservableCollection<TuVanKH>(DataProvider.Ins.DB.TuVanKHs);
            ListTuVan = new ObservableCollection<CAUHOIKHACHHANG>();
            foreach (var tv in _listTuVan)
                ListTuVan.Add(new CAUHOIKHACHHANG(ListTuVan.Count + 1, tv));
        }

        public void LoadCauHoi()
        {
            if (SelectedTuVan == null)
                return;

            TenKhachHang = SelectedTuVan.KhachHang;
            NgayDatCauHoi = SelectedTuVan.NgayDat;
            TuVanKH tuvan = findTuVan(SelectedTuVan.ID);
            if (tuvan.TraLoi == null)
            {
                NgayTraLoiLanCuoi = "Chưa có";
                TenNhanVien = "Chưa có";
            }
            else
            {
                NgayTraLoiLanCuoi = tuvan.NgayTraLoi?.ToString("dd/MM/yyyy");
                TenNhanVien = tuvan.NHANVIEN.HoTen;
            }
            CauHoi = tuvan.CauHoi;
            TraLoi = "";
            if (tuvan.TraLoi != null)
                TraLoi = tuvan.TraLoi;
        }

        public void LuuTraLoi()
        {
            if (string.IsNullOrEmpty(TraLoi))
            {
                DialogOpen = true;
                ThongBao = "Bạn chưa nhập câu trả lời";
                IconModal = "CloseCircle";
            }

            TuVanKH tuvan = findTuVan(SelectedTuVan.ID);
            tuvan.TraLoi = TraLoi;
            tuvan.NgayTraLoi = DateTime.Now;
            tuvan.NguoiTraLoi = Global.Ins.NhanVien.id;
            DataProvider.Ins.DB.SaveChanges();
            DialogOpen = true;
            ThongBao = "Đã trả lời thành công cho khách hàng"; 
            IconModal = "CheckCircleOutline";
            string ma = SelectedTuVan.ID;
            LoadCauHoi();
            LoadDatabase();

            foreach (var item in ListTuVan)
                if (item.ID == ma)
                    SelectedTuVan = item;
        }

        #endregion
        public QLKhachHang_ViewModel()
        {
            LoadDatabase();
            SelectedTuVan = ListTuVan[0];
            LoadCauHoi();

            CauHoiSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                LoadCauHoi();
            });

            LuuThayDoiCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                LuuTraLoi();
            });

            DialogOK = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogOpen = false;
            });
        }
    }
}
