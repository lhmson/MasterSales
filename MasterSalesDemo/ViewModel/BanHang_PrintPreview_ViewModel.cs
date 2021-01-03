using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Drawing;
using System.Collections.ObjectModel;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class BanHang_PrintPreview_ViewModel : BaseViewModel
    {
        #region Variables
        public ICommand CloseWindowCommand { get; set; }

        private string _NgayThangNam;
        public string NgayThangNam
        {
            get { return _NgayThangNam; }
            set { _NgayThangNam = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private string _MaHD;
        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; OnPropertyChanged(); }
        }

        private string _TongTien;
        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ListMatHangMua> _ListMatHang;
        public ObservableCollection<ListMatHangMua> ListMatHang
        {
            get { return _ListMatHang; }
            set { _ListMatHang = value; OnPropertyChanged(); }
        }

        #endregion
        public void Load()
        {
            string NgayLapHD = DateTime.Now.ToString("dd/MM/yyyy");
            NgayThangNam = "Ngày " + NgayLapHD[0] + NgayLapHD[1] + ", Tháng " + NgayLapHD[3] + NgayLapHD[4] + ", Năm " + NgayLapHD.Substring(6);
        }
        #region 
        #endregion
        public BanHang_PrintPreview_ViewModel(string maHD, string TenNV, string tt, ObservableCollection<ListMatHangMua> list)
        {
            MaHD = maHD;
            TenNhanVien = TenNV;
            TongTien = tt;
            ListMatHang = list;
            Load();
            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => {
                p.Close();
            });
        }
    }
}
