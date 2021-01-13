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
    class DangKyTaiKhoan_ViewModel : BaseViewModel
    {
        #region Binding Variables

        public static bool flagFinished;

        private ObservableCollection<string> _ListPhongBan;
        public ObservableCollection<string> ListPhongBan
        {
            get { return _ListPhongBan; }
            set { _ListPhongBan = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListNhanVien;
        public ObservableCollection<string> ListNhanVien
        {
            get { return _ListNhanVien; }
            set { _ListNhanVien = value; OnPropertyChanged(); }
        }

        private string _SelectedPhongBan;
        public string SelectedPhongBan
        {
            get { return _SelectedPhongBan; }
            set { _SelectedPhongBan = value; OnPropertyChanged(); }
        }

        private string _SelectedNhanVien;
        public string SelectedNhanVien
        {
            get { return _SelectedNhanVien; }
            set { _SelectedNhanVien = value; OnPropertyChanged(); }
        }

        private string _TenDangNhap;
        public string TenDangNhap
        {
            get { return _TenDangNhap; }
            set { _TenDangNhap = value; OnPropertyChanged(); }
        }

        private string _MatKhau;
        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; OnPropertyChanged(); }
        }
        #endregion
        #region Icommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand SelectionChangePBCommand { get; set; }
        public ICommand SelectionChangeNVCommand { get; set; }
        #endregion

        #region
        public bool checkDaCoTaiKhoan(NHANVIEN nv)
        {
            ObservableCollection<TAIKHOAN> listTK = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
            foreach (var tk in listTK)
                if (tk.NHANVIEN.id == nv.id)
                    return false;
            return true;
        }
        public void SelectedPB()
        {
            ObservableCollection<NHANVIEN> _listNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListNhanVien = new ObservableCollection<string>();
            foreach (var nv in _listNhanVien)
                if (nv.isDeleted != true && checkDaCoTaiKhoan(nv) 
                    && (SelectedPhongBan == null || SelectedPhongBan == "Tất cả" || 
                    nv.CHUCVU.PHONGBAN.TenPhong == SelectedPhongBan))
                    ListNhanVien.Add(nv.HoTen);
        }

        public void LoadDataBase()
        {
            ListPhongBan = new ObservableCollection<string>();
            ListPhongBan.Add("Tất cả");
            SelectedPhongBan = "Tất cả";

            ObservableCollection<PHONGBAN> _listPhongBan = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);
            foreach (var pb in _listPhongBan)
                if (pb.isDeleted != true)
                ListPhongBan.Add(pb.TenPhong);

            ObservableCollection<NHANVIEN> _listNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListNhanVien = new ObservableCollection<string>();
            foreach (var nv in _listNhanVien)
                if (nv.isDeleted != true && checkDaCoTaiKhoan(nv))
                ListNhanVien.Add(nv.HoTen);
        }
        public string getMaNVbyTenNhanVien(string tennv, string tenphong)
        {
            ObservableCollection<NHANVIEN> listNV = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            foreach (var nv in listNV)
                if (nv.HoTen == tennv && (nv.CHUCVU.PHONGBAN.TenPhong == tenphong || SelectedPhongBan == "Tất cả"))
                    return nv.id;
            return null;
        }

        public void DangKyTaiKhoan()
        {
            if (String.IsNullOrEmpty(TenDangNhap))
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập");
                return;
            }
            if (String.IsNullOrEmpty(MatKhau) || MatKhau.Length<=5)
            {
                MessageBox.Show("Mật khẩu phải ít nhất phải có 6 ký tự");
                return;
            }
            if (SelectedNhanVien == null)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên để đăng ký");
                return;
            }

            TAIKHOAN tk = new TAIKHOAN()
            {
                id = Global.Ins.autoGenerateTaiKhoan(),
                MaNV = getMaNVbyTenNhanVien(SelectedNhanVien, SelectedPhongBan),
                isDeleted = false,
            };
            tk.TenDangNhap = TenDangNhap;
            tk.MatKhau = MatKhau;
            DataProvider.Ins.DB.TAIKHOANs.Add(tk);
            DataProvider.Ins.DB.SaveChanges();
            flagFinished = true;
        }
        #endregion
        public DangKyTaiKhoan_ViewModel()
        {
            flagFinished = false;
            LoadDataBase();

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                p.Close();
                flagFinished = false;
            });

            SelectionChangePBCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SelectedPB();
                flagFinished = false;
            });

            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DangKyTaiKhoan();
                if (flagFinished)
                    p.Close();
            });
        }
    }
}
