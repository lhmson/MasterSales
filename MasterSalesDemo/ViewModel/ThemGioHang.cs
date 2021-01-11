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
    class MatHangGioHang
    {
        public string STT { get; set; }
        public string MatHang { get; set; }
        public string DonVi { get; set; }
        public string DonGia { get; set; }
        public string Nhom { get; set; }
        
        public MatHangGioHang(int stt, string tenMH, string dv, string dg, string nhom)
        {
            this.STT = stt + "";
            this.MatHang = tenMH;
            this.DonVi = dv;
            this.DonGia = dg;
            this.Nhom = nhom;
        }
    }

    class ThemGioHang : BaseViewModel
    {
        #region Variables

        #endregion

        #region Binding Variables
        private ObservableCollection<string> _ListNhomMH;
        public ObservableCollection<string> ListNhomMH
        {
            get { return _ListNhomMH; }
            set { _ListNhomMH = value; OnPropertyChanged(); }
        }

        private ObservableCollection<MatHangGioHang> _ListMatHang;
        public ObservableCollection<MatHangGioHang> ListMatHang
        {
            get { return _ListMatHang; }
            set { _ListMatHang = value; OnPropertyChanged(); }
        }

        private MatHangGioHang _SelectedMatHang;
        public MatHangGioHang SelectedMatHang
        {
            get { return _SelectedMatHang; }
            set { _SelectedMatHang = value; OnPropertyChanged(); }
        }

        private string _SourceHinhAnh;
        public string SourceHinhAnh
        {
            get { return _SourceHinhAnh; }
            set { _SourceHinhAnh = value; OnPropertyChanged(); }
        }

        private string _SelectedNhomMH;
        public string SelectedNhomMH
        {
            get { return _SelectedNhomMH; }
            set { _SelectedNhomMH = value; OnPropertyChanged(); }
        }

        private string _SearchTenMatHang;
        public string SearchTenMatHang
        {
            get { return _SearchTenMatHang; }
            set { _SearchTenMatHang = value; OnPropertyChanged(); }
        }

        private string _TenMatHang;
        public string TenMatHang
        {
            get { return _TenMatHang; }
            set { _TenMatHang = value; OnPropertyChanged(); }
        }

        private string _SoLuong;
        public string SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; OnPropertyChanged(); }
        }


        private string _TongTien;
        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand SearchCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ThemCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        #endregion

        #region
        public void SearchMatHang()
        {
            ObservableCollection<MATHANG> _listMatHang = Global.Ins.searchMHbyTenNhom_TenMH(SelectedNhomMH, SearchTenMatHang);

            ListMatHang = new ObservableCollection<MatHangGioHang>();
            foreach (var mh in _listMatHang)
            {
                int stt = ListMatHang.Count + 1;
                MatHangGioHang gh = new MatHangGioHang(stt, mh.TenMH, mh.DonVi, mh.DonGia + "", mh.NHOMMATHANG.TenNhomMH);
                ListMatHang.Add(gh);
            }
        }

        public void BindingMatHang()
        {
            SourceHinhAnh = "/Images/LAPTOP.jpg";
            if (SelectedMatHang == null) return;

            TenMatHang = SelectedMatHang.MatHang;
            SoLuong = "1";
            ObservableCollection<MATHANG> _listMH = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            foreach (var mh in _listMH)
                if (mh.TenMH == SelectedMatHang.MatHang && mh.HinhAnh!=null)
                    SourceHinhAnh = "/" + mh.HinhAnh;
        }

        public bool checkNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
                if (number[i] < '0' || number[i] > '9')
                    return false;
            return true;
        }

        public void ThemHang()
        {
            //check 
            Global.Ins.isThemThanhCong = false;
            if (TenMatHang == null)
            {
                System.Windows.Forms.MessageBox.Show("Bạn chưa chọn mặt hàng");
                return;
            }
            if (!checkNumber(SoLuong))
            {
                System.Windows.MessageBox.Show("Số lượng chỉ chứa ký tự số");
                return;
            }

            Global.Ins.TenMH = TenMatHang;
            Global.Ins.SoLuongMua = int.Parse(SoLuong);
            Global.Ins.isThemThanhCong = true;
        }
        #endregion
        public ThemGioHang()
        {
            Global.Ins.isThemThanhCong = false;
            SourceHinhAnh = "/Images/LAPTOP.jpg";
            ListNhomMH = Global.Ins.getAllTenNhomMH();
            Global.Ins.isThemThanhCong = false;
            SearchMatHang();
            if (ListMatHang.Count >= 1)
            {
                SelectedMatHang = ListMatHang[0];
                BindingMatHang();
            }

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Global.Ins.isThemThanhCong = false;
                p.Close();
            });

            ThemCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ThemHang();
                if (Global.Ins.isThemThanhCong)
                    p.Close();
            });

            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SearchMatHang();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                BindingMatHang();
            });
        }
    }
}
