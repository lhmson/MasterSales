using MasterSalesDemo.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MasterSalesDemo.ViewModel
{

    public class BaoCaoDoanhSo_ViewModel : BaseViewModel
    {


            // new code from this hihi


        public ICommand StartDateChangedCommand { get; set; }
        public ICommand EndDateChangedCommand { get; set; }
        public ICommand YearChangedCommand { get; set; }
        public ICommand CheDoXemChangedCommand { get; set; }
        public ICommand LoaiBaoCaoChangedCommand { get; set; }
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
        private ObservableCollection<DongBaoCaoNam> _BaoCaoNam;
        public ObservableCollection<DongBaoCaoNam> BaoCaoNam
        {
            get => _BaoCaoNam;
            set { _BaoCaoNam = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListCheDoXem;
        public ObservableCollection<string> ListCheDoXem { get => _ListCheDoXem; set { _ListCheDoXem = value; OnPropertyChanged(); } }
        private string _SelectedCheDoXem;
        public string SelectedCheDoXem
        {
            get { return _SelectedCheDoXem; }
            set { _SelectedCheDoXem = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListLoaiBaoCao;
        public ObservableCollection<string> ListLoaiBaoCao { get => _ListLoaiBaoCao; set { _ListLoaiBaoCao = value; OnPropertyChanged(); } }
        private string _SelectedLoaiBaoCao;
        public string SelectedLoaiBaoCao { get => _SelectedLoaiBaoCao; set { _SelectedLoaiBaoCao = value; OnPropertyChanged(); } }

        private Visibility _VisibilityChonNam;
        public Visibility VisibilityChonNam { get => _VisibilityChonNam; set { _VisibilityChonNam = value; OnPropertyChanged(); } }
        private Visibility _VisibilityTuNgayDenNgay;
        public Visibility VisibilityTuNgayDenNgay { get => _VisibilityTuNgayDenNgay; set { _VisibilityTuNgayDenNgay = value; OnPropertyChanged(); } }
        private Visibility _VisibilityChart;
        public Visibility VisibilityChart { get => _VisibilityChart; set { _VisibilityChart = value; OnPropertyChanged(); } }

        private Visibility _VisibilityBang;
        public Visibility VisibilityBang { get => _VisibilityBang; set { _VisibilityBang = value; OnPropertyChanged(); } }
        private Visibility _VisibilityBangNam;
        public Visibility VisibilityBangNam { get => _VisibilityBangNam; set { _VisibilityBangNam = value; OnPropertyChanged(); } }
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
        private bool _DialogOpen;
        public bool DialogOpen { get => _DialogOpen; set { _DialogOpen = value; OnPropertyChanged(); } }
        private string _Notify;
        public string Notify { get => _Notify; set { _Notify = value; OnPropertyChanged(); } }
        private void notifyKhongCoThongTin()
        {
            DialogOpen = true;
            Notify = "Vui lòng chọn thông tin hợp lệ trước khi in";
        }
        public BaoCaoDoanhSo_ViewModel()
        {
            DialogOpen = false;
            ListCheDoXem = new ObservableCollection<string>();
            ListLoaiBaoCao = new ObservableCollection<string>();
            ListLoaiBaoCao.Add("Khoảng thời gian");
            ListLoaiBaoCao.Add("Hằng năm");
            timeRangeView();
            showTableView();
            StartDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedStartDate > SelectedEndDate)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else
                {
                    VisibilityDatePickerPopup = Visibility.Collapsed;
                    LoadData();
                }
            });
            EndDateChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedStartDate > SelectedEndDate)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                }
                else if (SelectedStartDate >= DateTime.Today || SelectedEndDate >= DateTime.Today)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Phạm vi báo cáo phải từ quá khứ đến trước ngày hiện tại";
                }
                else if (SelectedStartDate.Year < 1900 || SelectedEndDate.Year < 1900)
                {
                    VisibilityDatePickerPopup = Visibility.Visible;
                    PopupContent = "Năm được chọn phải sau thế kỷ thứ 18";
                }
                else
                {
                    VisibilityDatePickerPopup = Visibility.Collapsed;
                    LoadData();
                }
            });
            YearChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedCheDoXem == "Bảng")
                    LoadData();
                else if (SelectedCheDoXem == "Biểu đồ đường")
                    LoadChart();
            });
            PrintTableCommand = new RelayCommand<object>((q) =>
            {             
                return true;
            },
                (q) =>
                {
                    if (SelectedLoaiBaoCao=="Khoảng thời gian")
                    {
                        if (BaoCao.Count()<1)
                            notifyKhongCoThongTin();
                        else
                        {
                            BaoCaoDoanhSo_PrintPreview_ViewModel printPreviewBaoCaoDoanhSo = new BaoCaoDoanhSo_PrintPreview_ViewModel(SelectedStartDate,SelectedEndDate,BaoCao);
                            BaoCaoDoanhSo_PrintPreview PrintPreviewWindow = new BaoCaoDoanhSo_PrintPreview(printPreviewBaoCaoDoanhSo);
                            PrintPreviewWindow.ShowDialog();
                        }
                    }
                    else if (SelectedLoaiBaoCao=="Hằng năm")
                    {
                        if (SelectedCheDoXem == "Bảng")
                        {
                            if (BaoCaoNam.Count() < 1)
                                notifyKhongCoThongTin();
                            else
                            {
                                BaoCaoDoanhSo_PrintPreview_ViewModel printPreviewBaoCaoDoanhSo = new BaoCaoDoanhSo_PrintPreview_ViewModel(SelectedYear, BaoCaoNam);
                                BaoCaoDoanhSo_PrintPreview PrintPreviewWindow = new BaoCaoDoanhSo_PrintPreview(printPreviewBaoCaoDoanhSo);
                                PrintPreviewWindow.ShowDialog();
                            }
                        }
                        else if (SelectedCheDoXem == "Biểu đồ đường")
                        {
                            if (ChartData.Count() < 1)
                                notifyKhongCoThongTin();
                            else
                            {
                                BaoCaoDoanhSo_PrintPreview_ViewModel printPreviewBaoCaoDoanhSo = new BaoCaoDoanhSo_PrintPreview_ViewModel(SelectedYear, DoanhThuCaNam, ChartData);
                                BaoCaoDoanhSo_PrintPreview PrintPreviewWindow = new BaoCaoDoanhSo_PrintPreview(printPreviewBaoCaoDoanhSo);
                                PrintPreviewWindow.ShowDialog();
                            }
                        }

                    }
                }
            );
            CheDoXemChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) => {
                if (SelectedCheDoXem == "Bảng")
                {
                    showTableView();
                }
                else if (SelectedCheDoXem == "Biểu đồ đường")
                {
                    showChartView();
                }
            });
            LoaiBaoCaoChangedCommand = new RelayCommand<object>((p) => { return true; },
            (p) =>
            {
                if (SelectedLoaiBaoCao == "Khoảng thời gian")
                {
                    timeRangeView();
                    showTableView();
                }
                if (SelectedLoaiBaoCao == "Hằng năm")
                {
                    anualView();
                    showTableView();
                }
            });
        }
        void timeRangeView()
        {
            SelectedLoaiBaoCao = "Khoảng thời gian";
            VisibilityChonNam = Visibility.Hidden;
            VisibilityTuNgayDenNgay = Visibility.Visible;
            VisibilityDatePickerPopup = Visibility.Hidden;
            SelectedStartDate = DateTime.Today.AddDays(-1);
            SelectedEndDate = DateTime.Today.AddDays(-1);
            ListCheDoXem.Clear();
            ListCheDoXem.Add("Bảng");
        }

        void anualView()
        {
            SelectedLoaiBaoCao = "Hằng năm";
            VisibilityTuNgayDenNgay = Visibility.Hidden;
            VisibilityChonNam = Visibility.Visible;
            ListYear = new ObservableCollection<int>();
            for (int i = 4; i >= 0; i--)
            {
                ListYear.Add(DateTime.Today.Year - i);
            }
            SelectedYear = DateTime.Today.Year;
            ListCheDoXem.Clear();
            ListCheDoXem.Add("Bảng");
            ListCheDoXem.Add("Biểu đồ đường");
        }
        void showTableView()
        {
            SelectedCheDoXem = "Bảng";
            VisibilityChart = Visibility.Collapsed;
            LoadData();
        }
        void showChartView()
        {
            SelectedCheDoXem = "Biểu đồ đường";
            VisibilityBang = Visibility.Collapsed;
            VisibilityBangNam = Visibility.Collapsed;
            VisibilityChart = Visibility.Visible;
            LoadChart();
        }
        void LoadChart()
        {
            YearHeader = SelectedYear.ToString();
            ChartData = new ObservableCollection<DiemBieuDo>();
            Decimal doanhthucanam = 0;
            for (int i = 1; i < 13; i++)
            {
                DiemBieuDo diembieudo = new DiemBieuDo();
                Decimal doanhthu = 0;
                ObservableCollection<CT_HOADON> cthoadons = new ObservableCollection<CT_HOADON>();
                foreach (var hoadon in DataProvider.Ins.DB.HOADONs.Where(x => x.NgayLap.Value.Month == i && x.NgayLap.Value.Year == SelectedYear))
                {
                    foreach (var cthoadon in hoadon.CT_HOADON)
                    {
                        doanhthu += cthoadon.TongTien ?? 0;
                        doanhthucanam+= cthoadon.TongTien ?? 0; 
                    }
                }
                diembieudo.Month = "Tháng " + i.ToString();
                diembieudo.Thu = doanhthu;
                ChartData.Add(diembieudo);
            }
            DoanhThuCaNam = "Doanh thu cả năm: " + doanhthucanam.ToString();
        }

        void LoadData()
        {
            var tempEndDate = SelectedEndDate.AddDays(1).AddSeconds(-1);
            if (SelectedLoaiBaoCao=="Khoảng thời gian")
            {
                VisibilityBangNam = Visibility.Collapsed;
                VisibilityBang = Visibility.Visible;
                BaoCao = new ObservableCollection<DongBaoCao>();
                ObservableCollection<CT_HOADON> cthoadons = new ObservableCollection<CT_HOADON>();
                foreach (var hoadon in DataProvider.Ins.DB.HOADONs.Where(x => x.NgayLap <= tempEndDate && x.NgayLap >= SelectedStartDate))
                {
                    foreach (var cthoadon in hoadon.CT_HOADON)
                    {
                        cthoadons.Add(cthoadon);
                    }
                }
                var query = cthoadons.GroupBy(x => x.MaMH).Select(g => new
                {
                    MaMH = g.Key,
                    SoLuong = g.Sum(x=>x.SLMua),
                    TongTien = g.Sum(x=>x.TongTien),
                });
                int i = 1;
                foreach (var item in query)
                {
                    DongBaoCao dongbaocao = new DongBaoCao();
                    dongbaocao.STT = i;
                    i++;
                    dongbaocao.MaMH = item.MaMH;
                    dongbaocao.TenHang = DataProvider.Ins.DB.MATHANGs.Where(x => x.id == item.MaMH).First().TenMH;
                    dongbaocao.SoLuong = item.SoLuong ?? 0;
                    dongbaocao.TongTien = item.TongTien ?? 0;
                    BaoCao.Add(dongbaocao);
                }
            }
            else if (SelectedLoaiBaoCao == "Hằng năm")
            {
                VisibilityBang = Visibility.Collapsed;
                VisibilityBangNam = Visibility.Visible;
                BaoCaoNam = new ObservableCollection<DongBaoCaoNam>();
                for (int i = 1;i<13;i++)
                {
                    if (i > DateTime.Now.Month && DateTime.Now.Year==SelectedYear)
                        break;
                    ObservableCollection<CT_HOADON> cthoadons = new ObservableCollection<CT_HOADON>();
                    foreach (var hoadon in DataProvider.Ins.DB.HOADONs.Where(x => x.NgayLap.Value.Month == i && x.NgayLap.Value.Year == SelectedYear))
                    {
                        foreach (var cthoadon in hoadon.CT_HOADON)
                        {
                            cthoadons.Add(cthoadon);                            
                        }
                    }
                    var query = cthoadons.GroupBy(x => x.MaMH).Select(g => new
                    {
                        MaMH = g.Key,
                        SoLuong = g.Sum(x=>x.SLMua),
                        TongTien = g.Sum(x => x.TongTien)
                    });

                    Decimal doanhthu = 0;
                    Decimal slmax = 0;
                    string mamh="";
                    foreach (var item in query)
                    {
                        doanhthu += item.TongTien ?? 0;
                        if (item.SoLuong>slmax)
                        {
                            slmax = item.SoLuong ?? 0;
                            mamh = item.MaMH;
                        }
                    }
                    DongBaoCaoNam dongbaocaonam = new DongBaoCaoNam();
                    dongbaocaonam.STT = i;
                    dongbaocaonam.Thang = "Tháng " + i.ToString();
                    dongbaocaonam.DoanhThu = doanhthu;
                    if (DataProvider.Ins.DB.MATHANGs.Where(x => x.id == mamh).Count() > 0)
                        dongbaocaonam.MuaNhieu = DataProvider.Ins.DB.MATHANGs.Where(x => x.id == mamh).First().TenMH;
                    else
                        dongbaocaonam.MuaNhieu = "";
                    BaoCaoNam.Add(dongbaocaonam);
                }
            }


        }

    }
    public class DongBaoCao
    {
        public int STT { get; set; }
        public string MaMH { get; set; }
        public string TenHang { get; set; }
        public int SoLuong { get; set; }
        public decimal TongTien { get; set; }
    }
    public class DongBaoCaoNam
    {
        public int STT { get; set; }
        public string Thang { get; set; }
        public decimal DoanhThu { get; set; }
        public string MuaNhieu { get; set; }
    }
    public class DiemBieuDo
    {
        public string Month { get; set; }
        public decimal Thu { get; set; }  
    }
}