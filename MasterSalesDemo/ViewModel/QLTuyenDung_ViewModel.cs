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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class QLTuyenDung_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenLoaiHopDongCommand { get; set; }
        public ICommand OpenThemHopDongCommand { get; set; }
        public ICommand ThemNhanVienCommand { get; set; }
        public ICommand ThemLoaiHopDongCommand { get; set; }
        public ICommand ThemHopDongCommand { get; set; }
        //public ICommand ThayDoiTrinhDo { get; set; }

        #region tạo mã nhân viên

        public string format(string a)
        {
            string tmp = a;
            for (int i = 1; i <= 10 - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        private string GetCodeNhanVien()
        {
            ObservableCollection<NHANVIEN> ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            int tmp = ListNhanVien.Count();
            return "NV" + format((tmp + 1).ToString());
        }

        #endregion

        #region nhân viên

        private ObservableCollection<NHANVIEN> _ListNhanVien;
        public ObservableCollection<NHANVIEN> ListNhanVien { get => _ListNhanVien; set { _ListNhanVien = value; OnPropertyChanged(); } }

        private ObservableCollection<NHANVIEN> _NhanVien;
        public ObservableCollection<NHANVIEN> NhanVien { get => _NhanVien; set { _NhanVien = value; OnPropertyChanged(); } }

        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }

        private DateTime _NgaySinh;
        public DateTime NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }

        private string _MaNhanVien;
        public string MaNhanVien { get => _MaNhanVien; set { _MaNhanVien = value; OnPropertyChanged(); } }

        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }

        private string _MaTrinhDo;
        public string MaTrinhDo { get => _MaTrinhDo; set { _MaTrinhDo = value; OnPropertyChanged(); } }

        private string _TenChuVu;
        public string TenChuVu { get => _TenChuVu; set { _TenChuVu = value; OnPropertyChanged(); } }

        private string _NoiSinh;
        public string NoiSinh { get => _NoiSinh; set { _NoiSinh = value; OnPropertyChanged(); } }

        private TRINHDO _SelectedTrinhDo;
        public TRINHDO SelectedTrinhDo
        {
            get => _SelectedTrinhDo;
            set
            {
                _SelectedTrinhDo = value;
                OnPropertyChanged();
            }
        }

        private NHANVIEN _SelectedItemNhanVien;
        public NHANVIEN SelectedItemNhanVien
        {
            get => _SelectedItemNhanVien;
            set
            {
                _SelectedItemNhanVien = value;
                OnPropertyChanged();
                if (SelectedItemNhanVien != null)
                {
                    MaNhanVien = SelectedItemNhanVien.id;
                    HoTen = SelectedItemNhanVien.HoTen;
                    MaTrinhDo = SelectedItemNhanVien.MaTrinhDo;
                    GioiTinh = SelectedItemNhanVien.GioiTinh;
                    NoiSinh = SelectedItemNhanVien.NoiSinh;
                    SelectedTrinhDo = SelectedItemNhanVien.TRINHDO;
                    NgaySinh = SelectedItemNhanVien.NgaySinh.Value;
                   // TenTrinhDo = SelectedItemNhanVien.TenTrinhDo;
                }
            }
        }

        #endregion

        #region init nhân viên

        public void InitNhanVien()
        {
            HoTen = "";
            GioiTinh = "";
            TenChuVu = "";
        }

        #endregion

        #region Trình độ

        private ObservableCollection<TRINHDO> _ListTrinhDo;
        public ObservableCollection<TRINHDO> ListTrinhDo { get => _ListTrinhDo; set { _ListTrinhDo = value; OnPropertyChanged(); } }

        private ObservableCollection<TRINHDO> _TrinhDo;
        public ObservableCollection<TRINHDO> TrinhDo { get => _TrinhDo; set { _TrinhDo = value; OnPropertyChanged(); } }

        private string _TenTrinhDo;
        public string TenTrinhDo { get => _TenTrinhDo; set { _TenTrinhDo = value; OnPropertyChanged(); } }

        private TRINHDO _SelectedItemTrinhDo;
        public TRINHDO SelectedItemTrinhDo
        {
            get => _SelectedItemTrinhDo;
            set
            {
                _SelectedItemTrinhDo = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemTrinhDo != null)
                {
                    TenTrinhDo = SelectedItemTrinhDo.TenTrinhDo;
                    
                }
            }
        }

        private TRINHDO _SelectedTenTrinhDo;
        public TRINHDO SelectedTenTrinhDo
        {
            get => _SelectedTenTrinhDo;
            set
            {
                _SelectedTenTrinhDo = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region giới tính

        private List<string> _ListGioiTinh;
        public List<string> ListGioiTinh
        {
            get { return _ListGioiTinh; }
            set
            {
                _ListGioiTinh = value;
                OnPropertyChanged(nameof(ListGioiTinh));
            }
        }

        #endregion

        #region Chức vụ

        private ObservableCollection<CHUCVU> _ListChucVu;
        public ObservableCollection<CHUCVU> ListChucVu { get => _ListChucVu; set { _ListChucVu = value; OnPropertyChanged(); } }

        private ObservableCollection<CHUCVU> _ChucVu;
        public ObservableCollection<CHUCVU> ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        private string _TenChucVu;
        public string TenChucVu { get => _TenChucVu; set { _TenChucVu = value; OnPropertyChanged(); } }

        private CHUCVU _SelectedItemChucVu;
        public CHUCVU SelectedItemChucVu
        {
            get => _SelectedItemChucVu;
            set
            {
                _SelectedItemChucVu = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemChucVu != null)
                {
                    TenChucVu = SelectedItemChucVu.TenChucVu;
                }
            }
        }

        #endregion

        #region Loại hợp đồng

        private ObservableCollection<LOAIHOPDONG> _ListLoaiHopDong;
        public ObservableCollection<LOAIHOPDONG> ListLoaiHopDong { get => _ListLoaiHopDong; set { _ListLoaiHopDong = value; OnPropertyChanged(); } }

        private ObservableCollection<LOAIHOPDONG> _LoaiHopDong;
        public ObservableCollection<LOAIHOPDONG> LoaiHopDong { get => _LoaiHopDong; set { _LoaiHopDong = value; OnPropertyChanged(); } }

        private string _TenLoaiHD;
        public string TenLoaiHD { get => _TenLoaiHD; set { _TenLoaiHD = value; OnPropertyChanged(); } }

        private int _ThoiHan;
        public int ThoiHan { get => _ThoiHan; set { _ThoiHan = value; OnPropertyChanged(); } }

        private decimal? _Luong;
        public decimal? Luong { get => _Luong; set { _Luong = value; OnPropertyChanged(); } }

        private LOAIHOPDONG _SelectedItemLoaiHopDong;
        public LOAIHOPDONG SelectedItemLoaiHopDong
        {
            get => _SelectedItemLoaiHopDong;
            set
            {
                _SelectedItemLoaiHopDong = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemLoaiHopDong != null)
                {
                    TenLoaiHD = SelectedItemLoaiHopDong.TenLoaiHD;
                    ThoiHan = SelectedItemLoaiHopDong.ThoiHan;
                    Luong = SelectedItemLoaiHopDong.Luong;
                }
            }
        }

        #endregion

        #region tạo mã loại hợp đồng

        private string GetCodeLoaiHopDong()
        {
            ObservableCollection<LOAIHOPDONG> ListLoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
            int tmp = ListLoaiHopDong.Count();
            return "LHD" + format((tmp + 1).ToString());
        }

        #endregion

        public QLTuyenDung_ViewModel()
        {
            TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            ListTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);

            ListGioiTinh = new List<string>() { "Nam", "Nữ" };

            ListChucVu = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

            LoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
            ListLoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);

            OpenLoaiHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemLoaiHopDong window = new ThemLoaiHopDong();
                window.ShowDialog();
            });

            OpenThemHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemHopDong window = new ThemHopDong();
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                var exit = p as Window;
                exit.Close();
            });

            #region thêm nhân viên

            ThemNhanVienCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(HoTen))
                    return false;

                var tennhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.HoTen.ToLower() == HoTen.ToLower());
                if (tennhanvien == null || tennhanvien.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string manhanvien = GetCodeNhanVien();
                var nhanvien = new NHANVIEN()
                {
                    id = manhanvien,
                    HoTen = HoTen,
                    NgaySinh = NgaySinh,
                    GioiTinh = GioiTinh,
                    MaTrinhDo = SelectedTrinhDo.id,
                    NoiSinh = NoiSinh,
                };

                DataProvider.Ins.DB.NHANVIENs.Add(nhanvien);
                DataProvider.Ins.DB.SaveChanges();
                NhanVien.Add(nhanvien);
                NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
                ListNhanVien.Add(nhanvien);
        
                MessageBox.Show("Thêm thành công");
            });

            #endregion

            #region thêm loại hợp đồng

            ThemLoaiHopDongCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenLoaiHD))
                    return false;

                var tenloaihopdong = DataProvider.Ins.DB.LOAIHOPDONGs.Where(x => x.TenLoaiHD.ToLower() == TenLoaiHD.ToLower());
                if (tenloaihopdong == null || tenloaihopdong.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string maloaihopdong = GetCodeLoaiHopDong();
                var loaihopdong = new LOAIHOPDONG()
                {
                    id = maloaihopdong,
                    TenLoaiHD = TenLoaiHD,
                    ThoiHan = ThoiHan,
                    Luong = Luong,
                };

                DataProvider.Ins.DB.LOAIHOPDONGs.Add(loaihopdong);
                DataProvider.Ins.DB.SaveChanges();
                LoaiHopDong.Add(loaihopdong);
                LoaiHopDong = new ObservableCollection<LOAIHOPDONG>(DataProvider.Ins.DB.LOAIHOPDONGs);
                ListLoaiHopDong.Add(loaihopdong);

                MessageBox.Show("Thêm thành công");
            });

            #endregion

            #region thêm hợp đồng

            //ThemHopDongCommand = new AppCommand<object>((p) =>
            //{
            //    if (string.IsNullOrEmpty(TenLoaiHD))
            //        return false;

            //    var tennhanvien = DataProvider.Ins.DB.NHANVIENs.Where(x => x.HoTen.ToLower() == HoTen.ToLower());
            //    if (tennhanvien == null || tennhanvien.Count() != 0)
            //        return false;

            //    return true;

            //}, (p) =>
            //{
            //    string manhanvien = GetCodeNhanVien();
            //    var nhanvien = new HOPDONG()
            //    {
            //        id = manhanvien,
            //        HoTen = HoTen,
            //        NgaySinh = NgaySinh,
            //        GioiTinh = GioiTinh,
            //        MaTrinhDo = SelectedTrinhDo.id,
            //        NoiSinh = NoiSinh,
            //    };

            //    DataProvider.Ins.DB.NHANVIENs.Add(nhanvien);
            //    DataProvider.Ins.DB.SaveChanges();
            //    NhanVien.Add(nhanvien);
            //    NhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);
            //    ListNhanVien.Add(nhanvien);

            //    MessageBox.Show("Thêm thành công");
            //});

            #endregion
        }
    }
}