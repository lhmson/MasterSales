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
    class PhieuDatHang
    {
        public string STT { get; set; }
        public string MaSo { get; set; }
        public string KhachHang { get; set; }
        public string TongTien { get; set; }
        public string NgayDat { get; set; }
        
        public PhieuDatHang (int stt, string ma, string kh, decimal tien, DateTime? ngaydat)
        {
            this.STT = stt + "";
            this.MaSo = ma;
            this.KhachHang = kh;
            this.TongTien = tien.ToString("0,000");
            this.NgayDat = ngaydat?.ToString("dd/MM/yyyy");
        }
    }
    class DatOnline_ViewModel : BaseViewModel
    {
        #region Variables

        #endregion

        #region Binding Variables
        private ObservableCollection<PhieuDatHang> _ListPhieu;
        public ObservableCollection<PhieuDatHang> ListPhieu
        {
            get { return _ListPhieu; }
            set { _ListPhieu = value; OnPropertyChanged(); }
        }

        private PhieuDatHang _SelectedPhieu;
        public PhieuDatHang SelectedPhieu
        {
            get { return _SelectedPhieu; }
            set { _SelectedPhieu = value; OnPropertyChanged(); }
        }

        private string _KhachHang;
        public string KhachHang
        {
            get { return _KhachHang; }
            set { _KhachHang = value; OnPropertyChanged(); }
        }

        private string _TongTien;
        public string TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; OnPropertyChanged(); }
        }

        private DateTime _TuNgay;
        public DateTime TuNgay
        {
            get { return _TuNgay; }
            set { _TuNgay = value; OnPropertyChanged(); }
        }

        private DateTime _DenNgay;
        public DateTime DenNgay
        {
            get { return _DenNgay; }
            set { _DenNgay = value; OnPropertyChanged(); }
        }


        #endregion

        #region Icommand
        public ICommand HuyPhieuCommand { get; set; }
        public ICommand XuLyCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        #endregion

        #region
        public void LoadPhieu(ObservableCollection<PHIEUDATHANG> listPhieu)
        {
            ListPhieu.Clear();
            for (int i = 0; i < listPhieu.Count; i++)
                for (int j = i + 1; j < listPhieu.Count; j++)
                    if (listPhieu[i].NgayDat.Value.Date > listPhieu[j].NgayDat.Value.Date)
                    {
                        PHIEUDATHANG temp = listPhieu[i];
                        listPhieu[i] = listPhieu[j];
                        listPhieu[j] = temp;
                    }

            foreach (var phieu in listPhieu)
            if (!(phieu.TrangThai==1))
            {
                int stt = ListPhieu.Count + 1;
                PhieuDatHang pdh = new PhieuDatHang(stt, phieu.id, phieu.KHACHHANG.TenKH, phieu.ThanhTien??0, phieu.NgayDat);
                ListPhieu.Add(pdh);
            }
        }
        public void LoadDatabase()
        {
            Global.Ins.isXuLy = false;

            TuNgay = DateTime.Now;
            DenNgay = DateTime.Now;
            KhachHang = TongTien = "";

            ListPhieu = new ObservableCollection<PhieuDatHang>();
            ObservableCollection<PHIEUDATHANG> _listPDH = Global.Ins.getAllPhieuDatHang();
            LoadPhieu(_listPDH);
        }

        public void SearchPhieuDH()
        {
            KhachHang = TongTien = "";

            ListPhieu = new ObservableCollection<PhieuDatHang>();
            ObservableCollection<PHIEUDATHANG> _listPDH = Global.Ins.getAllPhieuDatHang();
            ObservableCollection<PHIEUDATHANG> _listPDHRES = new ObservableCollection<PHIEUDATHANG>();
            foreach (var item in _listPDH)
            if (item.isDeleted != true && item.TrangThai == 0)
            {
                bool isTuNgay = false;
                bool isDenNgay = false;
                if (TuNgay == null || item.NgayDat.Value.Date >= TuNgay.Date)
                    isTuNgay = true;
                if (DenNgay == null || item.NgayDat.Value.Date <= DenNgay.Date)
                    isDenNgay = true;

                if (isDenNgay && isTuNgay)
                    _listPDHRES.Add(item);
            }
            LoadPhieu(_listPDHRES);
        }

        public void HuyPhieuDH(string MaPhieu)
        {
            ObservableCollection<PHIEUDATHANG> _ListPDH = new ObservableCollection<PHIEUDATHANG>(DataProvider.Ins.DB.PHIEUDATHANGs);

            foreach (var pdh in _ListPDH)
                if (pdh.id == MaPhieu)
                    pdh.TrangThai = 2;

            DataProvider.Ins.DB.SaveChanges();
        }
        public void HuyPhieuDH()
        {
            if (SelectedPhieu == null)
                return;
            DialogResult result = System.Windows.Forms.MessageBox.Show("Bạn có chắc sẽ hủy phiếu đặt hàng của khách hàng không?", 
                "Hủy phiếu đặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                HuyPhieuDH(SelectedPhieu.MaSo);
                LoadDatabase();
            }
        }

        public void XuLyPhieuDH()
        {
            if (SelectedPhieu == null)
                return;
            Global.Ins.isXuLy = true;
            Global.Ins.PhieuDHXuLY = Global.Ins.getPhieuDHbyMaPhieu(SelectedPhieu.MaSo);
        }
        #endregion

        public DatOnline_ViewModel()
        {
            LoadDatabase();

            SearchCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SearchPhieuDH();
            });

            SelectionChangedCommand = new RelayCommand<Window>((p) => { if (SelectedPhieu == null) return false;  return true; }, (p) => {
                KhachHang = SelectedPhieu.KhachHang;
                TongTien = SelectedPhieu.TongTien;
            });

            HuyPhieuCommand = new RelayCommand<Window>((p) => { if (SelectedPhieu == null) return false; return true; }, (p) => {
                HuyPhieuDH();
            });

            XuLyCommand = new RelayCommand<Window>((p) => { if (SelectedPhieu == null) return false; return true; }, (p) => {
                XuLyPhieuDH();
                if (Global.Ins.isXuLy)
                    p.Close();
            });
        }
    }
}
