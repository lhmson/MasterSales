using MasterStoreDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Windows.Data;
using System.Globalization;

namespace MasterStoreDemo.ViewModel
{



    public class BaoCaoDoanhSo_ViewModel : BaseViewModel
    {


        public ICommand StartDateChangedCommand { get; set; }
        public ICommand EndDateChangedCommand { get; set; }
        public ICommand YearChangedCommand { get; set; }
        public ICommand CheDoXemChangedCommand { get; set; }
        private DateTime _SelectedStartDate;
        public DateTime SelectedStartDate { get => _SelectedStartDate; set { _SelectedStartDate = value; OnPropertyChanged(); } }
        private DateTime _SelectedEndDate;
        public DateTime SelectedEndDate { get => _SelectedEndDate; set { _SelectedEndDate = value; OnPropertyChanged(); } }

        private Visibility _VisibilityDatePickerPopup;
        public Visibility VisibilityDatePickerPopup { get => _VisibilityDatePickerPopup; set { _VisibilityDatePickerPopup = value; OnPropertyChanged(); } }
        private string _PopupContent;
        public string PopupContent { get => _PopupContent; set { _PopupContent = value; OnPropertyChanged(); } }
        public ICommand PrintTableCommand { get; set; }
        public ICommand PrintChartCommand { get; set; }
        private ObservableCollection<DongBaoCao> _BaoCao;
        public ObservableCollection<DongBaoCao> BaoCao
        {
            get => _BaoCao;
            set { _BaoCao = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListCheDoXem;
        public ObservableCollection<string> ListCheDoXem { get => _ListCheDoXem; set { _ListCheDoXem = value; OnPropertyChanged(); } }
        private string _SelectedCheDoXem;
        public string SelectedCheDoXem { get => _SelectedCheDoXem; set { _SelectedCheDoXem = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChonNam;
        public Visibility VisibilityChonNam { get => _VisibilityChonNam; set { _VisibilityChonNam = value; OnPropertyChanged(); } }
        private Visibility _VisibilityTuNgayDenNgay;
        public Visibility VisibilityTuNgayDenNgay { get => _VisibilityTuNgayDenNgay; set { _VisibilityTuNgayDenNgay = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChart;
        public Visibility VisibilityChart { get => _VisibilityChart; set { _VisibilityChart = value; OnPropertyChanged(); } }

        private Visibility _VisibilityBang;
        public Visibility VisibilityBang { get => _VisibilityBang; set { _VisibilityBang = value; OnPropertyChanged(); } }
        private string _YearHeader;
        public string YearHeader { get => _YearHeader; set { _YearHeader = value; OnPropertyChanged(); } }
        private string _DoanhThuCaNam;
        public string DoanhThuCaNam { get => _DoanhThuCaNam; set { _DoanhThuCaNam = value; OnPropertyChanged(); } }
        private int _Maximum;
        public int Maximum { get => _Maximum; set { _Maximum = value; OnPropertyChanged(); } }
        private ObservableCollection<DiemBieuDo> _ChartData;
        public ObservableCollection<DiemBieuDo> ChartData
        {
            get => _ChartData;
            set { _ChartData = value; OnPropertyChanged(); }
        }
        private ObservableCollection<int> _ListYear;
        public ObservableCollection<int> ListYear { get => _ListYear; set { _ListYear = value; OnPropertyChanged(); } }
        private int _SelectedYear;
        public int SelectedYear { get => _SelectedYear; set { _SelectedYear = value; OnPropertyChanged(); } }
        private string _TenNhanVien;
        public BaoCaoDoanhSo_ViewModel()
        {
            ListCheDoXem = new ObservableCollection<string>();
            ListCheDoXem.Add("Bảng");
            ListCheDoXem.Add("Biểu đồ đường");
            SelectedCheDoXem = "Bảng";
            showTableView();
            StartDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedStartDate > SelectedEndDate)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else
                    LoadData();
            });
            EndDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedStartDate > SelectedEndDate)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    BaoCao = new ObservableCollection<DongBaoCao>();
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else
                    LoadData();
            });
            YearChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                LoadChart();
            });
            PrintTableCommand = new RelayCommand<object>((q) =>
            {
                if (BaoCao.Count == 0)
                    return false;
                return true;
            },
                (q) =>
                {
                    BaoCaoDoanhSo_PrintPreview_ViewModel printPreviewBaoCaoDoanhSo = new BaoCaoDoanhSo_PrintPreview_ViewModel(BaoCao, SelectedStartDate, SelectedEndDate, "*insert nguoi tao here");
                    BaoCaoDoanhSo_PrintPreview PrintPreviewWindow = new BaoCaoDoanhSo_PrintPreview(printPreviewBaoCaoDoanhSo);
                    PrintPreviewWindow.ShowDialog();
                }
            );
            CheDoXemChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedCheDoXem == "Bảng")
                {
                    showTableView();
                }
                if (SelectedCheDoXem == "Biểu đồ đường")
                {
                    showChartView();
                }
            });


        }
        void showTableView()
        {
            VisibilityChonNam = Visibility.Hidden;
            VisibilityTuNgayDenNgay = Visibility.Visible;
            VisibilityChart = Visibility.Hidden;
            VisibilityBang = Visibility.Visible;
            VisibilityDatePickerPopup = Visibility.Hidden;
            SelectedStartDate = DateTime.Today.AddDays(-1);
            SelectedEndDate = DateTime.Today.AddDays(-1);
            LoadData();
        }

        void showChartView()
        {
            VisibilityTuNgayDenNgay = Visibility.Hidden;
            VisibilityChonNam = Visibility.Visible;
            ListYear = new ObservableCollection<int>();
            VisibilityBang = Visibility.Hidden;
            VisibilityChart = Visibility.Visible;
            for (int i = 4; i >= 0; i--)
            {
                ListYear.Add(DateTime.Today.Year - i);
            }
            SelectedYear = DateTime.Today.Year;
            LoadChart();
        }
        void LoadChart()
        {
            ChartData = new ObservableCollection<DiemBieuDo>();
            YearHeader = "Năm " + SelectedYear.ToString();
            decimal doanhthucanam = 0;
            Maximum = 0;
            for (int i = 1; i < 13; i++)
            {
                var ThongKeNgay = new ObservableCollection<THONGKENGAY>(DataProvider.Ins.DB.THONGKENGAYs);
                var ChiTiet = new ObservableCollection<CT_THONGKENGAY>(DataProvider.Ins.DB.CT_THONGKENGAY);
                var MatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
                var DataQuery = from ct in ChiTiet
                                join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                                where (tkn.Ngay.Year == SelectedYear && tkn.Ngay.Month == i)
                                select new { ct.Thu };
                DiemBieuDo diembieudo = new DiemBieuDo();
                diembieudo.Month = "Tháng " + i.ToString();
                if (DataQuery.Count() == 0)
                    diembieudo.Thu = 0;
                else diembieudo.Thu = DataQuery.Sum(d => d.Thu);
                doanhthucanam += diembieudo.Thu;
                if (diembieudo.Thu > Maximum)
                    Maximum = Decimal.ToInt32(diembieudo.Thu);
                ChartData.Add(diembieudo);
            }
            Maximum += 1000000;
            DoanhThuCaNam = "Doanh thu cả năm: " + Decimal.ToInt32(doanhthucanam).ToString() + " VNĐ";
        }

        void LoadData()
        {
            BaoCao = new ObservableCollection<DongBaoCao>();
            VisibilityDatePickerPopup = Visibility.Hidden;
            var ThongKeNgay = new ObservableCollection<THONGKENGAY>(DataProvider.Ins.DB.THONGKENGAYs);
            var ChiTiet = new ObservableCollection<CT_THONGKENGAY>(DataProvider.Ins.DB.CT_THONGKENGAY);
            var MatHang = new ObservableCollection<MATHANG>(DataProvider.Ins.DB.MATHANGs);
            var DataQuery = from ct in ChiTiet
                            join tkn in ThongKeNgay on ct.MaThongKe equals tkn.MaThongKe
                            where (tkn.Ngay >= SelectedStartDate && tkn.Ngay <= SelectedEndDate)
                            select new { ct.MaMH, ct.Thu, ct.Chi };
            var GroupedDataQuery = DataQuery
                .GroupBy(x => x.MaMH)
                .Select(g => new
                {
                    MaMH = g.Key,
                    TongThu = g.Sum(x => x.Thu),
                    TongChi = g.Sum(x => x.Chi),
                });
            var ExtendedDataQuery = from gdq in GroupedDataQuery
                                    join mh in MatHang on gdq.MaMH equals mh.MaMH
                                    select new
                                    {
                                        gdq.MaMH,
                                        mh.TenMH,
                                        gdq.TongChi,
                                        gdq.TongThu,
                                    };
            BaoCao = new ObservableCollection<DongBaoCao>();
            int i = 1;
            foreach (var item in ExtendedDataQuery)
            {
                DongBaoCao dongbaocao = new DongBaoCao();
                dongbaocao.STT = i++;
                dongbaocao.MaMH = item.MaMH;
                dongbaocao.TenHang = item.TenMH;
                dongbaocao.TongThu = item.TongThu;
                dongbaocao.TongChi = item.TongChi;
                dongbaocao.ChenhLech = item.TongThu - item.TongChi;
                BaoCao.Add(dongbaocao);
            }
        }

    }
    public class DongBaoCao
    {
        public int STT { get; set; }
        public string MaMH { get; set; }
        public string TenHang { get; set; }
        public decimal TongThu { get; set; }
        public decimal TongChi { get; set; }
        public decimal ChenhLech { get; set; }
    }

    public class DiemBieuDo
    {
        public string Month { get; set; }
        public decimal Thu { get; set; }
    }
}