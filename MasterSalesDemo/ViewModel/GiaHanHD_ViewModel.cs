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
    class GiaHanHD_ViewModel : BaseViewModel
    {
        #region Variables
        private CHUCVU checkPointChucVu;
        #endregion

        #region Binding Variables

        private ObservableCollection<string> _ListLoaiHD;
        public ObservableCollection<string> ListLoaiHD
        {
            get { return _ListLoaiHD; }
            set { _ListLoaiHD = value; OnPropertyChanged(); }
        }

        private string _HanHopDong;
        public string HanHopDong
        {
            get { return _HanHopDong; }
            set { _HanHopDong = value; OnPropertyChanged(); }
        }

        private string _SelectedLoaiHD;
        public string SelectedLoaiHD
        {
            get { return _SelectedLoaiHD; }
            set { _SelectedLoaiHD = value; OnPropertyChanged(); }
        }

        private string _SelectedChucVu;
        public string SelectedChucVu
        {
            get { return _SelectedChucVu; }
            set { _SelectedChucVu = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private DateTime _NgayBD;
        public DateTime NgayBD
        {
            get { return _NgayBD; }
            set { _NgayBD = value; OnPropertyChanged(); }
        }

        private string _ChucVu;
        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand SelectionChangeLoaiHDCommand { get; set; }
        public ICommand StartDateChangedCommand { get; set; }
        #endregion

        #region
        public void autoGenerateNgayKT()
        {
            if (SelectedLoaiHD == null)
                return;

            LOAIHOPDONG lhd = Global.Ins.getLHDbyTenLHD(SelectedLoaiHD);
            HanHopDong = (NgayBD.AddMonths(lhd.ThoiHan ?? 0)).ToString("dd/MM/yyyy");
        }
        
        public void GiaHanHopDong(NHANVIEN nhanvien)
        {
            Global.Ins.isValid = false;
            if (SelectedLoaiHD == null)
            {
                MessageBox.Show("Bạn chưa chọn loại hợp đồng");
                return;
            }
            Global.Ins.deleteHopDong(nhanvien.id);
            LOAIHOPDONG lhd = Global.Ins.getLHDbyTenLHD(SelectedLoaiHD);
            HOPDONG hd = new HOPDONG()
            {
                id = Global.Ins.autoGenerateHopDong(),
                MaLoaiHD = lhd.id,
                MaNV = nhanvien.id,
                NgayHD = NgayBD,
                NgayKT = NgayBD.AddMonths(lhd.ThoiHan ?? 0),
                isDeleted = false,
            };
            DataProvider.Ins.DB.HOPDONGs.Add(hd);
            DataProvider.Ins.DB.SaveChanges();

            Global.Ins.isValid = true;
        }
        #endregion

        public GiaHanHD_ViewModel()
        {

        }
        public GiaHanHD_ViewModel(NHANVIEN nhanvien)
        {
            TenNhanVien = nhanvien.HoTen;
            CHUCVU chucvu = Global.Ins.getChucVubyMaNV(nhanvien.id);
            PHONGBAN phongban = chucvu.PHONGBAN;
            ChucVu = chucvu.TenChucVu + " - " + phongban.TenPhong;

            checkPointChucVu = chucvu;
            ListLoaiHD = Global.Ins.getAllTenLoaiHD();

            NgayBD = DateTime.Now;
            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Global.Ins.isValid = false;
                p.Close();
            });

            SelectionChangeLoaiHDCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                autoGenerateNgayKT();
            });

            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                GiaHanHopDong(nhanvien);
                if (Global.Ins.isValid)
                    p.Close();
            });

            StartDateChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                autoGenerateNgayKT();
            });
        }
    }
}
