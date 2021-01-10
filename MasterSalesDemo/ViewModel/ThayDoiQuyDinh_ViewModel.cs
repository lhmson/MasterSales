using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class BangMucThuong {
        public string STT { get; set; }
        public string TenMucThuong { get; set; }
        public string LuongThuong { get; set; }

        public BangMucThuong() { }
        public BangMucThuong(int stt, MUCTHUONG mt)
        {
            STT = stt + "";
            TenMucThuong = mt.TenMucThuong;
            LuongThuong = mt.TienThuong?.ToString("0,000");
        }
    }

    public class BangPhuCap
    {
        public string STT { get; set; }
        public string ChucVu { get; set; }
        public string PhongBan { get; set; }
        public string PhuCap { get; set; }

        public BangPhuCap (int stt, CHUCVU chucvu)
        {
            STT = stt + "";
            ChucVu = chucvu.TenChucVu;
            PhongBan = chucvu.PHONGBAN.TenPhong;
            PhuCap = chucvu.PhuCap?.ToString("0,000");
        }
    }
    public class ThayDoiQuyDinh_ViewModel : BaseViewModel
    {
        #region Binding variables
        private ObservableCollection<BangMucThuong> _ListMucThuong;
        public ObservableCollection<BangMucThuong> ListMucThuong
        {
            get { return _ListMucThuong; }
            set { _ListMucThuong = value; OnPropertyChanged(); }
        }

        private BangMucThuong _SelectedMucThuong;
        public BangMucThuong SelectedMucThuong
        {
            get { return _SelectedMucThuong; }
            set { _SelectedMucThuong = value; OnPropertyChanged(); }
        }

        private string _HeSoLuongHienTai;
        public string HeSoLuongHienTai
        {
            get { return _HeSoLuongHienTai; }
            set { _HeSoLuongHienTai = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BangPhuCap> _ListPhuCap;
        public ObservableCollection<BangPhuCap> ListPhuCap
        {
            get { return _ListPhuCap; }
            set { _ListPhuCap = value; OnPropertyChanged(); }
        }

        private BangPhuCap _SelectedPhuCap;
        public BangPhuCap SelectedPhuCap
        {
            get { return _SelectedPhuCap; }
            set { _SelectedPhuCap = value; OnPropertyChanged(); }
        }

        private string _PhuCap;
        public string PhuCap
        {
            get { return _PhuCap; }
            set { _PhuCap = value; OnPropertyChanged(); }
        }

        private string _TenChucVu;
        public string TenChucVu
        {
            get { return _TenChucVu; }
            set { _TenChucVu = value; OnPropertyChanged(); }
        }

        private string _HeSoMoi;
        public string HeSoMoi
        {
            get { return _HeSoMoi; }
            set { _HeSoMoi = value; OnPropertyChanged(); }
        }

        private string _PhuCapMoi;
        public string PhuCapMoi
        {
            get { return _PhuCapMoi; }
            set { _PhuCapMoi = value; OnPropertyChanged(); }
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
        private string _IconModal;
        public string IconModal
        {
            get { return _IconModal; }
            set { _IconModal = value; OnPropertyChanged(); }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; OnPropertyChanged(); }

        }

        private string _NhapTenMucThuong;
        public string NhapTenMucThuong
        {
            get { return _NhapTenMucThuong; }
            set { _NhapTenMucThuong = value; OnPropertyChanged(); }
        }

        private string _NhapTienThuong;
        public string NhapTienThuong
        {
            get { return _NhapTienThuong; }
            set { _NhapTienThuong = value; OnPropertyChanged(); }
        }

        private bool _DialogThemMTOpen;
        public bool DialogThemMTOpen
        {
            get { return _DialogThemMTOpen; }
            set { _DialogThemMTOpen = value; OnPropertyChanged(); }
        }

        private bool _DialogXoaMTOpen;
        public bool DialogXoaMTOpen
        {
            get { return _DialogXoaMTOpen; }
            set { _DialogXoaMTOpen = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand 
        public ICommand MucThuongSelectionChangedCommand { get; set; }
        public ICommand PhuCapSelectionChangedCommand { get; set; }
        public ICommand ThemMucThuongCommand { get; set; }
        public ICommand XoaMucThuongCommand { get; set; }
        public ICommand SuaMucThuongCommand { get; set; }
        public ICommand ReloadCommand { get; set; }
        public ICommand XacNhanHeSoCommand { get; set; }
        public ICommand XacNhanPhuCapCommand { get; set; }
        public ICommand DialogOK { get; set; }
        public ICommand DialogOKMT { get; set; }
        public ICommand DialogHuyMT { get; set; }
        public ICommand DialogHuyXoaMT { get; set; }
        public ICommand DialogOKXoaMT { get; set; }
        #endregion

        #region Functions
        public bool checkNumberFormat(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;
            foreach (var ch in number)
                if (ch < '0' || ch > '9')
                    return false;
            return true;
        }
        public void LoadDatabaseMucThuong()
        {
            ObservableCollection<MUCTHUONG> _listMT = new ObservableCollection<MUCTHUONG>(DataProvider.Ins.DB.MUCTHUONGs);
            ListMucThuong = new ObservableCollection<BangMucThuong>();

            foreach( var mt in _listMT)
                if (!(mt.isDeleted == true))
            {
                int stt = ListMucThuong.Count() + 1;
                BangMucThuong bmt = new BangMucThuong(stt, mt);
                ListMucThuong.Add(bmt);
            }
        }
        public void LoadHeSoLamThem()
        {
            HeSoMoi = "";
            ObservableCollection<THAMSO> _listThamSo = new ObservableCollection<THAMSO>(DataProvider.Ins.DB.THAMSOes);
            HeSoLuongHienTai = "0";
            foreach (var ts in _listThamSo)
                if (ts.id == "HeSoLamThem")
                {
                    HeSoLuongHienTai = ts.GiaTri.ToString("0,000");
                    break;
                }
        
        }
        public void LoadBangPhuCap()
        {
            ObservableCollection<CHUCVU> _listCV = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            ListPhuCap = new ObservableCollection<BangPhuCap>();
            foreach (var cv in _listCV)
                if (!(cv.isDeleted == true))
            {
                int stt = ListPhuCap.Count + 1;
                BangPhuCap bpc = new BangPhuCap(stt, cv);
                ListPhuCap.Add(bpc);
            }
        }
        public void LoadSomeVariables()
        {
            PhuCap = "0";
            TenChucVu = "Chưa chọn";
            Title = "THÊM MỨC THƯỞNG";
        }
        public void BindingPhuCap()
        {
            if (ListPhuCap == null || ListPhuCap.Count == 0)
                return;
            if (SelectedPhuCap == null)
                SelectedPhuCap = ListPhuCap[0];
            if (SelectedPhuCap == null)
                return;
            PhuCap = SelectedPhuCap.PhuCap;
            TenChucVu = SelectedPhuCap.ChucVu;
        }
        public bool checkTrungTenMucThuong(string tenmucthuong)
        {
            ObservableCollection<MUCTHUONG> _listMT = new ObservableCollection<MUCTHUONG>(DataProvider.Ins.DB.MUCTHUONGs);
            foreach (var mt in _listMT)
                if (!(mt.isDeleted == true))
                {
                    if (mt.TenMucThuong == tenmucthuong)
                        return true; 
                }
            return false;
        }
        public void XacNhanThemMucThuong()
        {
            if (string.IsNullOrEmpty(NhapTenMucThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập tên mức thưởng hợp lệ";
                return;
            }
            if (string.IsNullOrEmpty(NhapTienThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập tiền thưởng hợp lệ";
                return;
            }
            if (!checkNumberFormat(NhapTienThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Tiền thưởng phải là một số nguyên";
                return;
            }

            if (checkTrungTenMucThuong(NhapTenMucThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Tên mức thưởng đã tồn tại! Bạn hãy chọn tên khác!";
                return;
            }

            MUCTHUONG mucthuong = new MUCTHUONG()
            {
                id = Global.Ins.autoGenerateMucThuong(),
                TenMucThuong = NhapTenMucThuong,
                TienThuong = decimal.Parse(NhapTienThuong),
                isDeleted = false,
            };
            DataProvider.Ins.DB.MUCTHUONGs.Add(mucthuong);
            DataProvider.Ins.DB.SaveChanges();
            DialogThemMTOpen = false;
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Thêm một mức thưởng thành công!";
            LoadDatabaseMucThuong();
        }
        public void XacNhanSuaMucThuong()
        {
            if (string.IsNullOrEmpty(NhapTenMucThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập tên mức thưởng hợp lệ";
                return;
            }
            if (string.IsNullOrEmpty(NhapTienThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập tiền thưởng hợp lệ";
                return;
            }
            if (!checkNumberFormat(NhapTienThuong))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Tiền thưởng phải là một số nguyên";
                return;
            }

            if (checkTrungTenMucThuong(NhapTenMucThuong) && NhapTenMucThuong != SelectedMucThuong.TenMucThuong)
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Tên mức thưởng đã tồn tại! Bạn hãy chọn tên khác!";
                return;
            }


            ObservableCollection<MUCTHUONG> _listMT = new ObservableCollection<MUCTHUONG>(DataProvider.Ins.DB.MUCTHUONGs);
            foreach (var item in _listMT)
                if (item.TenMucThuong == SelectedMucThuong.TenMucThuong)
                {
                    item.TenMucThuong = NhapTenMucThuong;
                    item.TienThuong = decimal.Parse(NhapTienThuong);
                    break;
                }
            DataProvider.Ins.DB.SaveChanges();
            DialogThemMTOpen = false;
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Sửa một mức thưởng thành công!";
            LoadDatabaseMucThuong();
        }

        public void ThayDoiHeSo()
        {
            if (string.IsNullOrEmpty(HeSoMoi))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập hệ số làm thêm ngoài giờ hợp lệ";
                return;
            }
            if (!checkNumberFormat(HeSoMoi))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Hệ số làm thêm ngoài giờ phải là một số nguyên";
                return;
            }

            ObservableCollection<THAMSO> listTS = new ObservableCollection<THAMSO>(DataProvider.Ins.DB.THAMSOes);
            foreach(var ts in listTS)
                if (ts.id == "HeSoLamThem")
                {
                    ts.GiaTri = decimal.Parse(HeSoMoi);
                }
            DataProvider.Ins.DB.SaveChanges();
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Thay đổi quy định hệ số làm thêm thành công!";
            LoadHeSoLamThem();
        }
        public void ThayDoiPhuCap()
        {
            if (string.IsNullOrEmpty(PhuCapMoi))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Bạn phải nhập phụ cấp chức vụ hợp lệ";
                return;
            }
            if (!checkNumberFormat(PhuCapMoi))
            {
                DialogOpen = true;
                IconModal = "CloseCircle";
                ThongBao = "Phụ cấp phải là một số nguyên";
                return;
            }

            ObservableCollection<CHUCVU> listCV = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var cv in listCV)
                if (cv.TenChucVu == SelectedPhuCap.ChucVu && cv.PHONGBAN.TenPhong == SelectedPhuCap.PhongBan)
                {
                    cv.PhuCap = decimal.Parse(PhuCapMoi);
                }
            DataProvider.Ins.DB.SaveChanges();
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Thay đổi quy định phụ cấp cho chức vụ " + SelectedPhuCap.ChucVu + " thành công!";
            BindingPhuCap();
            BangPhuCap temp = SelectedPhuCap;
            LoadBangPhuCap();
            foreach (var item in ListPhuCap)
                if (temp.ChucVu == item.ChucVu && temp.PhongBan == item.PhongBan)
                    SelectedPhuCap = item;
            PhuCapMoi = "";
        }
        public void XacNhanXoaMT()
        {
            ObservableCollection<MUCTHUONG> _listMT = new ObservableCollection<MUCTHUONG>(DataProvider.Ins.DB.MUCTHUONGs);
            foreach (var item in _listMT)
                if (item.TenMucThuong == SelectedMucThuong.TenMucThuong && item.isDeleted!=true)
                {
                    item.isDeleted = true;
                }
            DataProvider.Ins.DB.SaveChanges();
            LoadDatabaseMucThuong();
            DialogXoaMTOpen = false;
            DialogOpen = true;
            IconModal = "CheckCircleOutline";
            ThongBao = "Bạn đã xóa một mức thưởng thành công!";
        }
        #endregion
        public ThayDoiQuyDinh_ViewModel()
        {
            LoadSomeVariables();
            LoadDatabaseMucThuong();
            LoadHeSoLamThem();
            LoadBangPhuCap();
            BindingPhuCap();

            MucThuongSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                
            });
            PhuCapSelectionChangedCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                BindingPhuCap();
            });
            DialogOK = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                DialogOpen = false;
            });
            DialogOKMT = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (Title == "THÊM MỨC THƯỞNG")
                    XacNhanThemMucThuong();
                else
                    XacNhanSuaMucThuong();
            });
            DialogHuyMT = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                DialogThemMTOpen = false;
            });
            DialogOKXoaMT = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                XacNhanXoaMT();
            });
            DialogHuyXoaMT = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                DialogXoaMTOpen = false;
            });
            ThemMucThuongCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogThemMTOpen = true;
                NhapTenMucThuong = "";
                NhapTienThuong = "";
                Title = "THÊM MỨC THƯỞNG";
            });
            SuaMucThuongCommand = new RelayCommand<Window>((p) => { if (SelectedMucThuong == null) return false; return true; }, (p) => {
                DialogThemMTOpen = true;
                NhapTenMucThuong = SelectedMucThuong.TenMucThuong;
                NhapTienThuong = Global.Ins.filterNumber(SelectedMucThuong.LuongThuong).ToString();
                Title = "SỬA MỨC THƯỞNG";
            });
            XoaMucThuongCommand = new RelayCommand<Window>((p) => { if (SelectedMucThuong == null) return false; return true; }, (p) =>
            {
                DialogXoaMTOpen  = true;
            });

            ReloadCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogOpen = true;
                IconModal = "CheckCircleOutline";
                ThongBao = "Không có gì mới để reload";
            });

            XacNhanHeSoCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ThayDoiHeSo();
            });

            XacNhanPhuCapCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ThayDoiPhuCap();
            });
        }
    }
}