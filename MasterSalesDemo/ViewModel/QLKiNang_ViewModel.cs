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

namespace MasterSalesDemo.ViewModel
{
    public class QLKiNang_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenKyNangCommand { get; set; }
        public ICommand OpenTrinhDoCommand { get; set; }
        public ICommand ThemTrinhDoCommand { get; set; }
        public ICommand ThemKyNangCommand { get; set; }

        public string format(string a)
        {
            string tmp = a;
            for (int i = 1; i <= 6 - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        private string GetCodeTrinhDo()
        {
            ObservableCollection<TRINHDO> ListTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            int tmp = ListTrinhDo.Count();
            return "TD" + format((tmp + 1).ToString());
        }

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

        #endregion

        private string GetCodeKyNang()
        {
            ObservableCollection<KYNANG> ListKyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
            int tmp = ListKyNang.Count();
            return "KN" + format((tmp + 1).ToString());
        }

        #region Kỹ năng

        private ObservableCollection<KYNANG> _ListKyNang;
        public ObservableCollection<KYNANG> ListKyNang { get => _ListKyNang; set { _ListKyNang = value; OnPropertyChanged(); } }

        private ObservableCollection<KYNANG> _KyNang;
        public ObservableCollection<KYNANG> KyNang { get => _KyNang; set { _KyNang = value; OnPropertyChanged(); } }

        private string _TenKyNang;
        public string TenKyNang { get => _TenKyNang; set { _TenKyNang = value; OnPropertyChanged(); } }

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
                }
            }
        }

        #endregion

        private ObservableCollection<NHANVIEN> _ListNhanVien;
        public ObservableCollection<NHANVIEN> ListNhanVien { get => _ListNhanVien; set { _ListNhanVien = value; OnPropertyChanged(); } }

        public QLKiNang_ViewModel()
        {
            TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            ListTrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
            KyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
            ListKyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
            ListNhanVien = new ObservableCollection<NHANVIEN>(DataProvider.Ins.DB.NHANVIENs);

            OpenKyNangCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                KyNang window = new KyNang();
                window.ShowDialog();
            });

            OpenTrinhDoCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TrinhDo window = new TrinhDo();
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                var exit = p as Window;
                exit.Close();
            });

            #region thêm trình độ

            ThemTrinhDoCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenTrinhDo))
                    return false;

                var tentrinhdo = DataProvider.Ins.DB.TRINHDOes.Where(x => x.TenTrinhDo.ToLower() == TenTrinhDo.ToLower());
                if (tentrinhdo == null || tentrinhdo.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string matrinhdo = GetCodeTrinhDo();
                var trinhdo = new TRINHDO()
                {
                    id = matrinhdo,
                    TenTrinhDo = TenTrinhDo,
                };

                DataProvider.Ins.DB.TRINHDOes.Add(trinhdo);
                DataProvider.Ins.DB.SaveChanges();
                TrinhDo.Add(trinhdo);
                TrinhDo = new ObservableCollection<TRINHDO>(DataProvider.Ins.DB.TRINHDOes);
                ListTrinhDo.Add(trinhdo);

                MessageBox.Show("Thêm thành công");
            });

            #endregion

            #region thêm kỹ năng

            ThemKyNangCommand = new AppCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenKyNang))
                    return false;

                var tenkynang = DataProvider.Ins.DB.KYNANGs.Where(x => x.TenKyNang.ToLower() == TenKyNang.ToLower());
                if (tenkynang == null || tenkynang.Count() != 0)
                    return false;

                return true;

            }, (p) =>
            {
                string makynang = GetCodeKyNang();
                var kynang = new KYNANG()
                {
                    id = makynang,
                    TenKyNang = TenKyNang,
                };

                DataProvider.Ins.DB.KYNANGs.Add(kynang);
                DataProvider.Ins.DB.SaveChanges();
                KyNang.Add(kynang);
                KyNang = new ObservableCollection<KYNANG>(DataProvider.Ins.DB.KYNANGs);
                ListKyNang.Add(kynang);

                MessageBox.Show("Thêm thành công");
            });

            #endregion
        }
    }
}
