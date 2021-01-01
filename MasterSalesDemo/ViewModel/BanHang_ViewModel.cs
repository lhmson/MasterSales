﻿using MasterSalesDemo.Helper;
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
        #endregion

        #region Icommand
        public ICommand GetMaHDCommand { get; set; }
        public ICommand HuyCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand XemDatThemGioHangCommandOnlineCommand { get; set; }
        public ICommand ThemGioHangCommand { get; set; }
        public ICommand BoRaGioHangCommand { get; set; }
        public ICommand DialogOK { get; set; }
        #endregion

        #region
        public void LoadDatabase()
        {
            DialogOpen = false;
            MaHD = "";
            TongTien = "0";
            NgayLapHD = DateTime.Now.ToString("dd/MM/yyyy");
            TenNhanVien = Global.Ins.NhanVien.HoTen;
            ListMatHang = new ObservableCollection<ListMatHangMua>();
            SelectedMatHang = null;
            CreateReport = false;
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
                ListMatHangMua mh = new ListMatHangMua(stt + "", res.id, res.TenMH, res.DonVi, res.DonGia + "", sl + "", thanhtien + "");
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
                ThongBao = "Thêm mặt hàng" + Global.Ins.TenMH + " vào giỏ hàng thành công";
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
            TongTien = res + "";
        }
        #endregion
        public BanHang_ViewModel()
        {
            LoadDatabase();

            GetMaHDCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                MaHD = Global.Ins.autoGenerateHoaDon();
            });

            HuyCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                LoadDatabase();
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
        }
    }
}

