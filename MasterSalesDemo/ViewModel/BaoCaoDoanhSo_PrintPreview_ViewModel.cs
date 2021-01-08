using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using MasterSalesDemo.Model;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace MasterSalesDemo.ViewModel
{
    public class BaoCaoDoanhSo_PrintPreview_ViewModel : BaseViewModel
    {
        #region Old code





        ////---------------


        #endregion
        private Visibility _KhoangTGVisibility;
        public Visibility KhoangTGVisibility
        {
            get { return _KhoangTGVisibility; }
            set { _KhoangTGVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _HangNamVisibility;
        public Visibility HangNamVisibility
        {
            get { return _HangNamVisibility; }
            set { _HangNamVisibility = value; OnPropertyChanged(); }
        }

        private int _Nam;
        public int Nam
        {
            get { return _Nam; }
            set { _Nam = value; OnPropertyChanged(); }
        }
        private Visibility _VisibilityBang;
        public Visibility VisibilityBang
        {
            get { return _VisibilityBang; }
            set { _VisibilityBang = value; OnPropertyChanged(); }
        }
        private Visibility _VisibilityBangNam;
        public Visibility VisibilityBangNam { get => _VisibilityBangNam; set { _VisibilityBangNam = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChart;
        public Visibility VisibilityChart { get => _VisibilityChart; set { _VisibilityChart = value; OnPropertyChanged(); } }
        private DateTime _StartDate;
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; OnPropertyChanged(); }
        }
        private DateTime _EndDate;
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; OnPropertyChanged(); }
        }
        //---------------
        private string _MaBaoCao;

        public string MaBaoCao
        {
            get { return _MaBaoCao; }
            set { _MaBaoCao = value; OnPropertyChanged(); }
        }

        private string _NguoiTaoPhieu;

        public string NguoiTaoPhieu
        {
            get { return _NguoiTaoPhieu; }
            set { _NguoiTaoPhieu = value; OnPropertyChanged(); }
        }


        private string _NgayThangNam;

        public string NgayThangNam
        {
            get { return _NgayThangNam; }
            set { _NgayThangNam = value; OnPropertyChanged(); }
        }

        //---------------
        private ObservableCollection<DongBaoCao> _BaoCao;

        public ObservableCollection<DongBaoCao> BaoCao
        {
            get { return _BaoCao; }
            set { _BaoCao = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DongBaoCaoNam> _BaoCaoNam;

        public ObservableCollection<DongBaoCaoNam> BaoCaoNam
        {
            get { return _BaoCaoNam; }
            set { _BaoCaoNam = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DiemBieuDo> _ChartData;

        public ObservableCollection<DiemBieuDo> ChartData
        {
            get { return _ChartData; }
            set { _ChartData = value; OnPropertyChanged(); }
        }

        private string _DoanhThuCaNam;
        public string DoanhThuCaNam { get => _DoanhThuCaNam; set { _DoanhThuCaNam = value; OnPropertyChanged(); } }
        //--------------

        public ICommand CloseWindowCommand { get; set; }
        public ICommand Print_Command { get; set; }

        public BaoCaoDoanhSo_PrintPreview_ViewModel(DateTime inputStartDate, DateTime inputEndDate, ObservableCollection<DongBaoCao> Data)
        {
            VisibilityBang = Visibility.Visible;
            VisibilityBangNam = Visibility.Collapsed;
            VisibilityChart = Visibility.Collapsed;
            KhoangTGVisibility = Visibility.Visible;
            HangNamVisibility = Visibility.Collapsed;
            BaoCao = Data;
            StartDate = inputStartDate;
            EndDate = inputEndDate;
            //for (int i = 0; i < listBaoCao.Count(); i++)
            //    ListBaoCaoDoanhSo[i].SoThuTu = i + 1;

            //SanhCodeThem
            if (LoginViewModel.TaiKhoanSuDung != null)
                NguoiTaoPhieu = LoginViewModel.TaiKhoanSuDung.NHANVIEN.HoTen;

            string date = DateTime.Now.ToString("dd/MM/yyyy");
            NgayThangNam = "Ngày " + date.Substring(0, 2) + ", tháng " + date.Substring(3, 2) + ", năm " + date.Substring(6, 4);

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                ex.Close();

            });

            Print_Command = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                try
                {
                    System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(ex, "Print report");

                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Cannot print");
                }

            });


        }
        public BaoCaoDoanhSo_PrintPreview_ViewModel(int nam, ObservableCollection<DongBaoCaoNam> Data)
        {
            VisibilityBang = Visibility.Collapsed;
            VisibilityBangNam = Visibility.Visible;
            VisibilityChart = Visibility.Collapsed;
            KhoangTGVisibility = Visibility.Collapsed;
            HangNamVisibility = Visibility.Visible;
            BaoCaoNam = Data;
            Nam = nam;
            //for (int i = 0; i < listBaoCao.Count(); i++)
            //    ListBaoCaoDoanhSo[i].SoThuTu = i + 1;

            //SanhCodeThem
            if (LoginViewModel.TaiKhoanSuDung != null)
                NguoiTaoPhieu = LoginViewModel.TaiKhoanSuDung.NHANVIEN.HoTen;

            string date = DateTime.Now.ToString("dd/MM/yyyy");
            NgayThangNam = "Ngày " + date.Substring(0, 2) + ", tháng " + date.Substring(3, 2) + ", năm " + date.Substring(6, 4);

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                ex.Close();

            });

            Print_Command = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                try
                {
                    System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(ex, "Print report");

                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Cannot print");
                }

            });


        }
        public BaoCaoDoanhSo_PrintPreview_ViewModel(int nam, String doanhthucanam, ObservableCollection<DiemBieuDo> Data)
        {
            VisibilityBang = Visibility.Collapsed;
            VisibilityBangNam = Visibility.Collapsed;
            VisibilityChart = Visibility.Visible;
            KhoangTGVisibility = Visibility.Collapsed;
            HangNamVisibility = Visibility.Visible;
            ChartData = Data;
            Nam = nam;
            DoanhThuCaNam = doanhthucanam;
            //for (int i = 0; i < listBaoCao.Count(); i++)
            //    ListBaoCaoDoanhSo[i].SoThuTu = i + 1;

            //SanhCodeThem
            if (LoginViewModel.TaiKhoanSuDung != null)
                NguoiTaoPhieu = LoginViewModel.TaiKhoanSuDung.NHANVIEN.HoTen;

            string date = DateTime.Now.ToString("dd/MM/yyyy");
            NgayThangNam = "Ngày " + date.Substring(0, 2) + ", tháng " + date.Substring(3, 2) + ", năm " + date.Substring(6, 4);

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                ex.Close();

            });

            Print_Command = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) =>
            {
                var ex = p as Window;
                try
                {
                    System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(ex, "Print report");

                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("Cannot print");
                }

            });


        }
    }



}
