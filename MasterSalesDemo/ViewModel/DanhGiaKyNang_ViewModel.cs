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
    public class DanhGiaKyNang_ViewModel : BaseViewModel
    {

        #region Icommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ThemKyNangNhanVienCommand { get; set; }

        #endregion

        #region Nhân viên

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        #endregion

        #region tạo mã đánh giá

        public string format(string a)
        {
            string tmp = a;
            for (int i = 1; i <= 5 - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        private string GetCodeMaDanhGia()
        {
            ObservableCollection<DANHGIAKYNANG> ListDGKN = new ObservableCollection<DANHGIAKYNANG>(DataProvider.Ins.DB.DANHGIAKYNANGs);
            int tmp = ListDGKN.Count();
            return "DGKN" + format((tmp + 1).ToString());
        }

        #endregion

        #region loại đánh giá

        private string _LoaiDanhGia;
        public string LoaiDanhGia { get => _LoaiDanhGia; set { _LoaiDanhGia = value; OnPropertyChanged(); } }

        private List<string> _ListDanhGia;
        public List<string> ListDanhGia
        {
            get { return _ListDanhGia; }
            set
            {
                _ListDanhGia = value;
                OnPropertyChanged(nameof(ListDanhGia));
            }
        }

        #endregion 

        #region kỹ năng

        private ObservableCollection<KYNANG> _KyNang;
        public ObservableCollection<KYNANG> KyNang { get => _KyNang; set { _KyNang = value; OnPropertyChanged(); } }

        private string _TenKyNang;
        public string TenKyNang { get => _TenKyNang; set { _TenKyNang = value; OnPropertyChanged(); } }

        private string _MaKyNang;
        public string MaKyNang { get => _MaKyNang; set { _MaKyNang = value; OnPropertyChanged(); } }

        private KYNANG _SelectedItemKyNang;
        public KYNANG SelectedItemKyNang
        {
            get => _SelectedItemKyNang;
            set
            {
                _SelectedItemKyNang = value;
                OnPropertyChanged();
                // NCC_NotNull = _SelectedItemTrinhDo != null;

                if (SelectedItemKyNang != null)
                {
                    TenKyNang = SelectedItemKyNang.TenKyNang;
                    MaKyNang = SelectedItemKyNang.id;
                }
            }
        }

        #endregion

        public DanhGiaKyNang_ViewModel()
        {

        }
        public DanhGiaKyNang_ViewModel(NHANVIEN nhanvien)
        {
            TenNhanVien = nhanvien.HoTen;
            ListDanhGia = new List<string>() { "Xuất sắc", "Giỏi", "Khá" };

            KyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Global.Ins.isValid = false;
                p.Close();
            });

            #region thêm kỹ năng nhân viên

            ThemKyNangNhanVienCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenKyNang) || string.IsNullOrEmpty(LoaiDanhGia))
                    return false;

                return true;

            }, (p) =>
            {

                string madanhgia = GetCodeMaDanhGia();
                var dgkn = new DANHGIAKYNANG()
                {
                    id = madanhgia,
                    LoaiDanhGia = LoaiDanhGia,
                    MaKyNang = MaKyNang,
                    MaNV = nhanvien.id,
                    isDeleted = false,
                };

                ObservableCollection<DANHGIAKYNANG> ListDGKyNang = new ObservableCollection<DANHGIAKYNANG>(DataProvider.Ins.DB.DANHGIAKYNANGs);
                bool flag = false;

                foreach (var danhgia in ListDGKyNang)
                {
                    if (danhgia.MaKyNang == dgkn.MaKyNang && danhgia.MaNV == dgkn.MaNV)
                    {
                        MessageBox.Show("Nhân viên này đã có kỹ năng này");
                        flag = true;
                        break;
                    }    
                }

                if (!flag)
                {
                    DataProvider.Ins.DB.DANHGIAKYNANGs.Add(dgkn);
                    DataProvider.Ins.DB.SaveChanges();

                    MessageBox.Show("Thêm kỹ năng thành công");
                    var exit = p as Window;
                    exit.Close();

                } 
            });

            #endregion
        }

    }
}
