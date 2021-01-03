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
    public class DongLuongThuong
    {
        public int STT { get; set; }
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public decimal LuongCB { get; set; }
        public decimal LuongPC { get; set; }
        public decimal Thuong { get; set; }
        public decimal LuongNG { get; set; }
        public decimal LuongTL { get; set; }
    }
    public class QLLuongThuong_ViewModel : BaseViewModel
    {
        #region
        public PHONGBAN _PBNhanVien { get; set; }
        #endregion
        #region Binding Varibales
        private ObservableCollection<string> _ListPhongBan;
        public ObservableCollection<string> ListPhongBan
        {
            get { return _ListPhongBan; }
            set { _ListPhongBan = value; OnPropertyChanged(); }
        }
        
        private string _SelectedPhongBan;
        public string SelectedPhongBan
        {
            get { return _SelectedPhongBan; }
            set { _SelectedPhongBan = value; OnPropertyChanged(); }
        }
        private string _SelectedTenPhongBan;
        public string SelectedTenPhongBan
        {
            get { return _SelectedTenPhongBan; }
            set { _SelectedTenPhongBan = value; OnPropertyChanged(); }
        }
        private string _SelectedNam;
        public string SelectedNam
        {
            get { return _SelectedNam; }
            set { _SelectedNam = value; OnPropertyChanged(); }
        }
        private string _SelectedThang;
        public string SelectedThang
        {
            get { return _SelectedThang; }
            set { _SelectedThang = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListNam;
        public ObservableCollection<string> ListNam
        {
            get { return _ListNam; }
            set { _ListNam = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListThang;
        public ObservableCollection<string> ListThang
        {
            get { return _ListThang; }
            set { _ListThang = value; OnPropertyChanged(); }
        }
        private ObservableCollection<DongLuongThuong> _BangLuongThuong;
        public ObservableCollection<DongLuongThuong> BangLuongThuong
        {
            get { return _BangLuongThuong; }
            set { _BangLuongThuong = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _ListMucDo;
        public ObservableCollection<string> ListMucDo
        {
            get { return _ListMucDo; }
            set { _ListMucDo = value; OnPropertyChanged(); }
        }
        private string _SelectedMucDo;
        public string SelectedMucDo
        {
            get { return _SelectedMucDo; }
            set { _SelectedMucDo = value; OnPropertyChanged(); }
        }
        private int _SoBuoi;
        public int SoBuoi
        {
            get { return _SoBuoi; }
            set { _SoBuoi = value; OnPropertyChanged(); }
        }
        private string _TTTenNV;
        public string TTTenNV
        {
            get { return _TTTenNV; }
            set { _TTTenNV = value; OnPropertyChanged(); }
        }
        private DongLuongThuong _SelectedNhanVien;
        public DongLuongThuong SelectedNhanVien
        {
            get => _SelectedNhanVien;
            set { _SelectedNhanVien = value; OnPropertyChanged(); }
        }
        private bool _luuThayDoiEnabled;
        public bool luuThayDoiEnabled
        {
            get => _luuThayDoiEnabled;
            set { _luuThayDoiEnabled = value; OnPropertyChanged(); }
        }
        private bool _suaThongTinEnabled;
        public bool suaThongTinEnabled
        {
            get => _suaThongTinEnabled;
            set { _suaThongTinEnabled = value; OnPropertyChanged(); }
        }
        private string _visibilitySoBuoiPopup;
        public string visibilitySoBuoiPopup
        {
            get => _visibilitySoBuoiPopup;
            set { _visibilitySoBuoiPopup = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommands
        public ICommand phongBanSelectionChangedCommand { get; set; }
        public ICommand thangSelectionChangedCommand { get; set; }
        public ICommand namSelectionChangedCommand { get; set; }
        public ICommand nhanVienSelectionChangedCommand { get; set; }
        public ICommand mucDoSelectionChangedCommand { get; set; }
        public ICommand soBuoiSelectionChangedCommand { get; set; }
        public ICommand luuThayDoiCommand { get; set; }
        #endregion
        #region Functions
        public void loadData()
        {
            ListPhongBan = Global.Ins.getAllPhongBan();
            SelectedPhongBan = Global.Ins.NhanVien.CHUCVU.PHONGBAN.id;
            SelectedTenPhongBan = Global.Ins.NhanVien.CHUCVU.PHONGBAN.TenPhong;
            _PBNhanVien = Global.Ins.NhanVien.CHUCVU.PHONGBAN;
            ListNam = new ObservableCollection<string>();
            ListThang = new ObservableCollection<string>();
            for (int i = 4; i >= 0; i--)
            {
                ListNam.Add((DateTime.Today.Year - i).ToString());
            }
            for (int i=1;i<=12;i++)
            {
                ListThang.Add("Tháng " + i.ToString());
            }
            SelectedNam = DateTime.Today.Year.ToString();
            SelectedThang ="Tháng " + DateTime.Today.Month.ToString();
            ObservableCollection<MUCTHUONG> _listMT = new ObservableCollection<MUCTHUONG>(DataProvider.Ins.DB.MUCTHUONGs);
            ListMucDo = new ObservableCollection<string>();
            foreach (var item in _listMT)
                ListMucDo.Add(item.TenMucThuong);
            SelectedMucDo=null;
            SoBuoi = 0;
            TTTenNV = "(Chọn nhân viên để tiếp tục)";
            SelectedNhanVien = null;
            luuThayDoiEnabled = false;
            suaThongTinEnabled = false;
            visibilitySoBuoiPopup = "Collapsed";
            loadTable();
        }
        public void loadTable()
        {
            ObservableCollection<NHANVIEN> _listNV = Global.Ins.getAllNhanVienbyMaPhongBan(SelectedPhongBan);
            BangLuongThuong = new ObservableCollection<DongLuongThuong>();
            int i = 1;
            int thang = Global.Ins.filterNumber(SelectedThang);
            int nam = Global.Ins.filterNumber(SelectedNam);
            foreach (var item in _listNV)
                if (item.isDeleted == false)
                {
                    DongLuongThuong dongluongthuong = new DongLuongThuong();
                    dongluongthuong.STT = i;
                    i++;
                    dongluongthuong.MaNV = item.id;
                    dongluongthuong.TenNV = item.HoTen;
                    dongluongthuong.LuongCB = item.HOPDONGs.Where(x => x.isDeleted == false).First().LOAIHOPDONG.Luong ?? 0;
                    dongluongthuong.LuongPC = item.CHUCVU.PhuCap ?? 0;

                    //1. bang lam them                    
                    if (DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.Nam == nam && SelectedPhongBan == x.MaPhong).Count() == 0)
                    {
                        BANGLAMTHEM temp = new BANGLAMTHEM()
                        {
                            id = Global.Ins.autoGenerateBangLamThem(),
                            MaTrgPB = item.CHUCVU.PHONGBAN.MaTrgPB,
                            NgayLap = DateTime.Now,
                            Thang = thang,
                            Nam = nam,
                            MaPhong = SelectedPhongBan,
                            HeSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.id == "HeSoLamThem").First().GiaTri,
                            isDeleted = false,
                        };
                        DataProvider.Ins.DB.BANGLAMTHEMs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    if (DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.Nam == nam && SelectedPhongBan == x.MaPhong).First().CT_BANGLAMTHEM.Where(x => x.MaNV == item.id).Count()==0)
                    {
                        CT_BANGLAMTHEM tempp = new CT_BANGLAMTHEM()
                        {
                            id = Global.Ins.autoGenerateCTBangLamThem(),
                            MaLamThem = DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.Nam == nam && SelectedPhongBan == x.MaPhong).First().id,
                            MaNV = item.id,
                            SoBuoi = 0,
                            TienLamThem = 0,
                            isDeleted = false,
                        };
                        DataProvider.Ins.DB.CT_BANGLAMTHEM.Add(tempp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    dongluongthuong.LuongNG = DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.Nam == nam && SelectedPhongBan == x.MaPhong).First().CT_BANGLAMTHEM.Where(x => x.MaNV == item.id).First().TienLamThem ?? 0;
                    
                    //2. bang thuong
                    if (DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.MaPhong == SelectedPhongBan && x.Thang == thang && x.Nam == nam).Count()==0)
                    {
                        BANGTHUONG temp = new BANGTHUONG()
                        {
                            id = Global.Ins.autoGenerateBangThuong(),
                            MaTrgPB = item.CHUCVU.PHONGBAN.MaTrgPB,
                            NgayLap = DateTime.Now,
                            Thang = thang,
                            Nam = nam,
                            MaPhong = SelectedPhongBan,
                            isDeleted = false,
                        };
                        DataProvider.Ins.DB.BANGTHUONGs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    if (DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.MaPhong == SelectedPhongBan && x.Thang == thang && x.Nam == nam).First().CT_BANGTHUONG.Where(x => x.MaNV == item.id).Count()==0)
                    {
                        CT_BANGTHUONG tempp = new CT_BANGTHUONG()
                        {
                            id = Global.Ins.autoGenerateCTBangThuong(),
                            MaThuong = DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.MaPhong == SelectedPhongBan && x.Thang == thang && x.Nam == nam).First().id,
                            MaNV = item.id,
                            MaMucThuong = DataProvider.Ins.DB.MUCTHUONGs.First().id,
                            TienThuong = DataProvider.Ins.DB.MUCTHUONGs.First().TienThuong,
                            isDeleted = false,
                        };
                        DataProvider.Ins.DB.CT_BANGTHUONG.Add(tempp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    dongluongthuong.Thuong = DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.MaPhong == SelectedPhongBan && x.Thang == thang && x.Nam == nam).First().CT_BANGTHUONG.Where(x => x.MaNV == item.id).First().TienThuong ?? 0;
                    
                    //3. luong thuc lanh
                    if (DataProvider.Ins.DB.BANGLUONGTLs.Where(x => x.Thang == thang && x.Nam == nam && x.MaPhong == SelectedPhongBan).Count() == 0)
                    {
                        BANGLUONGTL temp = new BANGLUONGTL()
                        {
                            id = Global.Ins.autoGenerateBangLuongTL(),
                            MaKeToan = Global.Ins.NhanVien.CHUCVU.MaPhongBan == "PB005" ? Global.Ins.NhanVien.id : null,
                            NgayLap = DateTime.Now,
                            Thang = thang,
                            Nam = nam,
                            MaPhong = SelectedPhongBan,
                            isDeleted = false,
                        };
                        DataProvider.Ins.DB.BANGLUONGTLs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    if (DataProvider.Ins.DB.BANGLUONGTLs.Where(x => x.Thang == thang && x.Nam == nam && x.MaPhong == SelectedPhongBan).First().CT_BANGLUONGTL.Where(x => x.MaNV == item.id).Count()==0)
                    {
                        decimal luongcb = DataProvider.Ins.DB.HOPDONGs.Where(x => x.MaNV == item.id).First().LOAIHOPDONG.Luong ?? 0;
                        decimal tienthuong = DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.MaPhong == SelectedPhongBan && x.Thang == thang && x.Nam == nam).First().CT_BANGTHUONG.Where(x => x.MaNV == item.id).First().TienThuong ?? 0;
                        decimal luonglamthem = DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.Nam == nam && SelectedPhongBan == x.MaPhong).First().CT_BANGLAMTHEM.Where(x => x.MaNV == item.id).First().TienLamThem ?? 0;
                        decimal phucap = item.CHUCVU.PhuCap ?? 0;
                        CT_BANGLUONGTL tempp = new CT_BANGLUONGTL()
                        {
                            id = Global.Ins.autoGenerateCTBangLuongTL(),
                            MaLuongTL = DataProvider.Ins.DB.BANGLUONGTLs.Where(x => x.Thang == thang && x.Nam == nam && x.MaPhong == SelectedPhongBan).First().id,
                            MaNV = item.id,
                            LuongCB = luongcb,
                            TienThuong = tienthuong,
                            LuongLamThem = luonglamthem,
                            PhuCap = phucap,
                            TongLuong = luongcb + tienthuong + luonglamthem + phucap,
                        };
                        DataProvider.Ins.DB.CT_BANGLUONGTL.Add(tempp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    dongluongthuong.LuongTL = DataProvider.Ins.DB.BANGLUONGTLs.Where(x => x.Thang == thang && x.Nam == nam && x.MaPhong == SelectedPhongBan).First().CT_BANGLUONGTL.Where(x => x.MaNV == item.id).First().TongLuong ?? 0;
                    
                    BangLuongThuong.Add(dongluongthuong);
                }
            luuThayDoiEnabled = false;
        }
        public void loadThongTin()
        {
            suaThongTinEnabled = true;
            if (SelectedNhanVien != null)
            {
                int thang = Global.Ins.filterNumber(SelectedThang);
                TTTenNV = SelectedNhanVien.TenNV;
                SelectedMucDo = DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGTHUONG.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().MUCTHUONG.TenMucThuong;
                SoBuoi = DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGLAMTHEM.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().SoBuoi ?? 0;
                luuThayDoiEnabled = false;
            }
        }

        public bool dataCheck()
        {
            return true;
        }

        #endregion
        public QLLuongThuong_ViewModel()
        {
            loadData();
            phongBanSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadTable();
                SelectedTenPhongBan = DataProvider.Ins.DB.PHONGBANs.Where(x => x.id == SelectedPhongBan).First().TenPhong;
            });
            namSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadTable();
            });
            thangSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadTable();
            });
            nhanVienSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                loadThongTin();
            });
            mucDoSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (dataCheck())
                {
                    luuThayDoiEnabled = true;
                }
                else
                    luuThayDoiEnabled = false;
            });
            soBuoiSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (dataCheck())
                {
                    luuThayDoiEnabled = true;
                }
                else
                    luuThayDoiEnabled = false;
            });
            luuThayDoiCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (dataCheck())
                {
                    int thang = Global.Ins.filterNumber(SelectedThang);
                    String maMucThuong = DataProvider.Ins.DB.MUCTHUONGs.Where(x => x.TenMucThuong == SelectedMucDo).First().id;
                    DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGTHUONG.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().MaMucThuong = maMucThuong;
                    DataProvider.Ins.DB.BANGTHUONGs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGTHUONG.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().TienThuong = DataProvider.Ins.DB.MUCTHUONGs.Where(x => x.id == maMucThuong).First().TienThuong;
                    DataProvider.Ins.DB.SaveChanges();
                    DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGLAMTHEM.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().SoBuoi = SoBuoi;
                    DataProvider.Ins.DB.BANGLAMTHEMs.Where(x => x.Thang == thang && x.MaPhong == SelectedPhongBan).First().CT_BANGLAMTHEM.Where(x => x.MaNV == SelectedNhanVien.MaNV).First().TienLamThem = SoBuoi * DataProvider.Ins.DB.THAMSOes.Where(x => x.id == "HeSoLamThem").First().GiaTri;
                    DataProvider.Ins.DB.SaveChanges();
                    loadTable();
                }
                luuThayDoiEnabled = false;
            });
        }
    }
}

