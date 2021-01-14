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
    class ThongTinHoaDon
    {
        public string STT { get; set; }
        public string MaSo { get; set; }
        public string KhachHang { get; set; }
        public string TongTien { get; set; }

        public ThongTinHoaDon(int stt, HOADON hd)
        {
            this.STT = stt + "";
            this.MaSo = hd.id;
            if (hd.MaKH == null)
                this.KhachHang = "Thành Nam";
            else
                this.KhachHang = hd.KHACHHANG.TenKH;
            this.TongTien = hd.ThanhTien?.ToString("0,000");
        }
    }

    class ChiTietHoaDon
    {
        public string STT { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string SoLuong { get; set; }
        public string DonGia { get; set; }
        public string ThanhTien { get; set; }

        public ChiTietHoaDon(int stt, CT_HOADON ct)
        {
            this.STT = stt + "";
            this.MaMH = ct.MaMH;
            this.TenMH = ct.MATHANG.TenMH;
            this.SoLuong = ct.SLMua + "";
            this.DonGia = ct.DonGia?.ToString("0,000");
            this.ThanhTien = ct.TongTien?.ToString("0,000");
        }
    }
    class QuanLyHoaDon_ViewModel : BaseViewModel
    {
        #region Variables

        #endregion

        #region Binding Variables
        private ObservableCollection<ThongTinHoaDon> _ListHoaDon;
        public ObservableCollection<ThongTinHoaDon> ListHoaDon
        {
            get { return _ListHoaDon; }
            set { _ListHoaDon = value; OnPropertyChanged(); }
        }

        private ThongTinHoaDon _SelectedHD;
        public ThongTinHoaDon SelectedHD
        {
            get { return _SelectedHD; }
            set { _SelectedHD = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ChiTietHoaDon> _ListCTHoaDon;
        public ObservableCollection<ChiTietHoaDon> ListCTHoaDon
        {
            get { return _ListCTHoaDon; }
            set { _ListCTHoaDon = value; OnPropertyChanged(); }
        }

        private DateTime _NgayHD;
        public DateTime NgayHD
        {
            get { return _NgayHD; }
            set { _NgayHD = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand HuyPhieuCommand { get; set; }
        public ICommand XuLyCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        #endregion

        public void search()
        {
            ObservableCollection<HOADON> _listHD = new ObservableCollection<HOADON>(DataProvider.Ins.DB.HOADONs);
            ListHoaDon = new ObservableCollection<ThongTinHoaDon>();
            foreach (var hd in _listHD)
                if (hd.NgayLap.Value.Date == NgayHD.Date)
                    ListHoaDon.Add(new ThongTinHoaDon(ListHoaDon.Count + 1, hd));
        }
        public void load()
        {
            NgayHD = DateTime.Now;
            search();
        }
        
        public void binding()
        {
            ObservableCollection<CT_HOADON> _listCT = new ObservableCollection<CT_HOADON>(DataProvider.Ins.DB.CT_HOADON);
            ListCTHoaDon = new ObservableCollection<ChiTietHoaDon>();
            foreach (var item in _listCT)
                if (item.MaHD == SelectedHD.MaSo)
                ListCTHoaDon.Add(new ChiTietHoaDon(ListCTHoaDon.Count + 1, item));

        }
        public QuanLyHoaDon_ViewModel()
        {
            load();

            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                search();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { if (SelectedHD == null) return false; return true; }, (p) => {
                binding();
            });
        }
    }
}
