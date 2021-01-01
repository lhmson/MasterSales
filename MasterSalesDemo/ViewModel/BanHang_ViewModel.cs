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

        private string _MaHD;
        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; OnPropertyChanged(); }
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

        private ObservableCollection<string> _ListLoaiHD;
        public ObservableCollection<string> ListLoaiHD
        {
            get { return _ListLoaiHD; }
            set { _ListLoaiHD = value; OnPropertyChanged(); }
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
        #endregion

        #region Icommand
        public ICommand GetMaHDCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand XemDatOnlineCommand { get; set; }
        public ICommand ThemGioHangCommand { get; set; }
        public ICommand BoRaGioHangCommand { get; set; }
        #endregion

        #region
        public void LoadDatabase()
        {
            NgayLapHD = DateTime.Now.ToString("dd/MM/yyyy");
            TenNhanVien = Global.Ins.NhanVien.HoTen;
        }
        #endregion
        public BanHang_ViewModel()
        {
            LoadDatabase();
        }
    }
}

