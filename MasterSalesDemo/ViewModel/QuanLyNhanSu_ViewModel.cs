using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MasterSalesDemo.ViewModel
{
    public class ThongTinNguoiDung
    {
        public TAIKHOAN _TaiKhoan { get; set; }
        public string HoTen { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string ChucVu { get; set; }

        public ThongTinNguoiDung(TAIKHOAN taikhoan)
        {
            _TaiKhoan = taikhoan;
            HoTen = taikhoan.NHANVIEN.HoTen;
            TaiKhoan = taikhoan.TenDangNhap;
            MatKhau = taikhoan.MatKhau;
            ChucVu = taikhoan.NHANVIEN.CHUCVU.TenChucVu;
        }
    }
    public class QuanLyNhanSu_ViewModel : BaseViewModel
    {

        #region Tooltips
        private Visibility _Visibility_1;
        public Visibility Visibility_1
        {
            get => _Visibility_1;
            set { _Visibility_1 = value; OnPropertyChanged(); }
        }

        private Visibility _Visibility_2;
        public Visibility Visibility_2
        {
            get => _Visibility_2;
            set { _Visibility_2 = value; OnPropertyChanged(); }
        }

        private Visibility _Visibility_3;
        public Visibility Visibility_3
        {
            get => _Visibility_3;
            set { _Visibility_3 = value; OnPropertyChanged(); }
        }

        private Visibility _Visibility_4;
        public Visibility Visibility_4
        {
            get => _Visibility_4;
            set { _Visibility_4 = value; OnPropertyChanged(); }
        }

        private string _Error1;
        public string Error1
        {
            get => _Error1;
            set { _Error1 = value; OnPropertyChanged(); }
        }


        private string _Error2;
        public string Error2
        {
            get => _Error2;
            set { _Error2 = value; OnPropertyChanged(); }
        }


        private string _Error3;
        public string Error3
        {
            get => _Error3;
            set { _Error3 = value; OnPropertyChanged(); }
        }


        private string _Error4;
        public string Error4
        {
            get => _Error4;
            set { _Error4 = value; OnPropertyChanged(); }
        }
        #endregion

        #region Variables
        private bool isEdit;


        private bool _DialogOpen;
        public bool DialogOpen { get => _DialogOpen; set { _DialogOpen = value; OnPropertyChanged(); } }

        private string _ThongBao;
        public string ThongBao { get => _ThongBao; set { _ThongBao = value; OnPropertyChanged(); } }

        private ObservableCollection<ThongTinNguoiDung> _ListNhanVien;
        public ObservableCollection<ThongTinNguoiDung> ListNhanVien
        {
            get => _ListNhanVien;
            set { _ListNhanVien = value; OnPropertyChanged(); }
        }

        private ObservableCollection<CHUCVU> _ListNhomNguoiDung;
        public ObservableCollection<CHUCVU> ListNhomNguoiDung
        {
            get => _ListNhomNguoiDung;
            set { _ListNhomNguoiDung = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BangPhanQuyen> _ListPhanQuyen;
        public ObservableCollection<BangPhanQuyen> ListPhanQuyen
        {
            get => _ListPhanQuyen;
            set { _ListPhanQuyen = value; OnPropertyChanged(); }
        }

        private ThongTinNguoiDung _SelectedItemNguoiDung;
        public ThongTinNguoiDung SelectedItemNguoiDung
        {
            get => _SelectedItemNguoiDung;
            set { _SelectedItemNguoiDung = value; OnPropertyChanged(); }
        }

        private CHUCVU _SelectedItemNhomNguoiDung;
        public CHUCVU SelectedItemNhomNguoiDung
        {
            get => _SelectedItemNhomNguoiDung;
            set { _SelectedItemNhomNguoiDung = value; OnPropertyChanged(); }
        }

        private BangPhanQuyen _SelectedPhanQuyen;
        public BangPhanQuyen SelectedPhanQuyen
        {
            get => _SelectedPhanQuyen;
            set { _SelectedPhanQuyen = value; OnPropertyChanged(); }
        }

        private int _SelectedIndexCbb;
        public int SelectedIndexCbb
        {
            get => _SelectedIndexCbb;
            set { _SelectedIndexCbb = value; OnPropertyChanged(); }
        }

        // Visibility of add elements
        private Visibility _VisibilityOfAdd;
        public Visibility VisibilityOfAdd
        {
            get => _VisibilityOfAdd;
            set { _VisibilityOfAdd = value; OnPropertyChanged(); }
        }

        // Visibility of edit elements
        private Visibility _VisibilityOfEdit;
        public Visibility VisibilityOfEdit
        {
            get => _VisibilityOfEdit;
            set { _VisibilityOfEdit = value; OnPropertyChanged(); }
        }

        // Visibility of listview NGUOIDUNG
        private Visibility _VisibilityOfListNguoiDung;
        public Visibility VisibilityOfListNguoiDung
        {
            get => _VisibilityOfListNguoiDung;
            set { _VisibilityOfListNguoiDung = value; OnPropertyChanged(); }
        }

        private Visibility _VisibilityOfListPhanQuyen;
        public Visibility VisibilityOfListPhanQuyen
        {
            get => _VisibilityOfListPhanQuyen;
            set { _VisibilityOfListPhanQuyen = value; OnPropertyChanged(); }
        }

        private Visibility _VisibilityOfTenNhomQuyen;
        public Visibility VisibilityOfTenNhomQuyen
        {
            get => _VisibilityOfTenNhomQuyen;
            set { _VisibilityOfTenNhomQuyen = value; OnPropertyChanged(); }
        }
        //TenDangNhap
        private string _TenDangNhap;
        public string TenDangNhap
        {
            get => _TenDangNhap;
            set { _TenDangNhap = value; OnPropertyChanged(); }
        }

        //Tên thanh trên bảng List
        private string _TenDanhSachNhom;
        public string TenDanhSachNhom
        {
            get => _TenDanhSachNhom;
            set { _TenDanhSachNhom = value; OnPropertyChanged(); }
        }

        private string _txtTenNhomQuyen;
        public string txtTenNhomQuyen
        {
            get => _txtTenNhomQuyen;
            set { _txtTenNhomQuyen = value; OnPropertyChanged(); }
        }
        //MatKhau
        private string _MatKhau;
        public string MatKhau
        {
            get => _MatKhau;
            set { _MatKhau = value; OnPropertyChanged(); }
        }

        //Hoten
        private string _HoTen;
        public string HoTen
        {
            get => _HoTen;
            set { _HoTen = value; OnPropertyChanged(); }
        }

        //Ten nhomquyen
        private List<string> _TenNhom;
        public List<string> TenNhom
        {
            get => _TenNhom;
            set { _TenNhom = value; OnPropertyChanged(); }
        }


        private ObservableCollection<string> _CbxTenNhom;
        public ObservableCollection<string> CbxTenNhom
        {
            get { return _CbxTenNhom; }
            set { _CbxTenNhom = value; OnPropertyChanged(); }
        }

        private string _TextTenNhom;
        public string TextTenNhom
        {
            get { return _TextTenNhom; }
            set { _TextTenNhom = value; OnPropertyChanged(); }
        }
        private string _SelectedTenNhom;
        public string SelectedTenNhom
        {
            get { return _SelectedTenNhom; }
            set { _SelectedTenNhom = value; OnPropertyChanged(); }
        }



        #endregion

        #region Function

        private void Reset()
        {
            SelectedItemNguoiDung = null;
            SelectedItemNhomNguoiDung = null;
            if (SelectedPhanQuyen != null)
            {
                BangPhanQuyen PQ = SelectedPhanQuyen;
                PQ.EnabledCheckBox = false;
                foreach (var pq in ListPhanQuyen)
                    if (pq.TenNhomQuyen == PQ.TenNhomQuyen)
                    {
                        ListPhanQuyen.Remove(pq);
                        ListPhanQuyen.Add(PQ);
                        SelectedPhanQuyen = PQ;
                        break;
                    }
                isEdit = true;
            }
            SelectedPhanQuyen = null;
        }

        private bool check_hasaWhiteSpace(string chuoi)
        {
            if (chuoi == null) return false;
            foreach (var item in chuoi)
                if (item == ' ')
                    return true;
            return false;
        }

        private bool check_hasallWhiteSpace(string chuoi)
        {
            if (chuoi == null) return false;
            foreach (var item in chuoi)
                if (item != ' ')
                    return false;
            return true;
        }

        public bool Check_TenNhomQuyen(string name)
        {
            ObservableCollection<CHUCVU> nhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            foreach (var item in nhom)
                if (item.TenChucVu.ToUpper() == name.ToUpper())
                    return true;

            return false;
        }

        private string format(string a, int numberOfDigit)
        {
            string tmp = a;
            for (int i = 1; i <= numberOfDigit - a.Length; i++)
                tmp = "0" + tmp;
            return tmp;
        }

        private string CreateCodeNhomNguoiDung()
        {
            ObservableCollection<CHUCVU> listNhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            int tmp = listNhom.Count();
            return "CV" + format((tmp + 1).ToString(),3);
        }

        //public int CreateCodeNhomNguoiDung()
        //{
        //    ObservableCollection<CHUCVU> listNhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
        //    int max = 0;
        //    foreach (var item in listNhom)
        //        if (max < item.id)
        //            max = item.manhom;
        //    return max + 1;
        //}

        private void LoadData()
        {
            ListNhomNguoiDung = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            ObservableCollection<TAIKHOAN> _listTaiKhoan = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
            ListNhanVien = new ObservableCollection<ThongTinNguoiDung>();

            foreach (var tk in _listTaiKhoan)
                ListNhanVien.Add(new ThongTinNguoiDung(tk));

            VisibilityOfAdd = Visibility.Hidden;
            VisibilityOfEdit = Visibility.Hidden;

            // choosing list NguoiDung
            SelectedIndexCbb = 0;

            CbxTenNhom = new ObservableCollection<string>();
            foreach (var Nhom in ListNhomNguoiDung)
                CbxTenNhom.Add(Nhom.TenChucVu);
        }

        public string search_MaNhom(string TenNhom)
        {
            string ma = "";

            ObservableCollection<CHUCVU> ListNhomNguoiDung = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            foreach (var nhom in ListNhomNguoiDung)
                if (nhom.TenChucVu == TenNhom)
                    return nhom.id;
            return ma;
        }

        private void LoadDataPhanQuyen()
        {
            ListPhanQuyen = new ObservableCollection<BangPhanQuyen>();
            ObservableCollection<CHUCVU> nhomNguoiDung = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            foreach (var item in nhomNguoiDung)
                ListPhanQuyen.Add(new BangPhanQuyen(item.TenChucVu, false));
        }

        private string check_DeleteNhomNguoiDung(string maNhom)
        {
            ObservableCollection<TAIKHOAN> ngDung = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

            string res = "";
            foreach (var item in ngDung)
                if (item.NHANVIEN.MaChucVu == maNhom)
                    res += item.NHANVIEN.HoTen + "\n";
            return res;
        }

        private void ResetCbxTenNhom()
        {
            Visibility vsAdd = VisibilityOfAdd;
            Visibility vsEdit = VisibilityOfEdit;
            VisibilityOfAdd = Visibility.Visible;
            VisibilityOfEdit = Visibility.Visible;
            CbxTenNhom.Clear();

            ObservableCollection<CHUCVU> List_Nhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var Nhom in List_Nhom)
            {
                CbxTenNhom.Add(Nhom.TenChucVu);
            }
            VisibilityOfAdd = vsAdd;
            VisibilityOfEdit = vsEdit;
        }

        private bool CheckValidData()
        {
            if (VisibilityOfAdd == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(TenDangNhap))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(MatKhau))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(HoTen))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(SelectedTenNhom))
                {
                    return false;
                }
                var tenDangNhap = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenDangNhap == TenDangNhap);
                if (tenDangNhap == null || tenDangNhap.Count() != 0)
                    return false;
                return true;
            }
            else if (VisibilityOfEdit == Visibility.Visible)
            {
                if (string.IsNullOrEmpty(MatKhau))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(HoTen))
                {
                    return false;
                }
                if (string.IsNullOrEmpty(SelectedTenNhom))
                {
                    return false;
                }
            }
            return true;
        }
        private void ResetTextbox()
        {
            TenDangNhap = "";
            MatKhau = "";
            HoTen = "";
            TextTenNhom = "";
            SelectedTenNhom = null;
        }

        private void Add_PhanQuyen(string maNhom, string maChucNang)
        {
            PHANQUYEN PQ = new PHANQUYEN();
            PQ.MaChucVu = maNhom;
            PQ.MaChucNang = maChucNang;
            DataProvider.Ins.DB.PHANQUYENs.Add(PQ);
            DataProvider.Ins.DB.SaveChanges();
        }

        private void Delete_PhanQuyen(string maNhom)
        {
            ObservableCollection<PHANQUYEN> listPhanQuyen = new ObservableCollection<PHANQUYEN>(DataProvider.Ins.DB.PHANQUYENs);
            foreach (var pq in listPhanQuyen)
                if (pq.MaChucVu == maNhom)
                    DataProvider.Ins.DB.PHANQUYENs.Remove(pq);
            DataProvider.Ins.DB.SaveChanges();
        }

        private void Delete_NhomNguoiDung(string tenNhom)
        {
            ObservableCollection<CHUCVU> nhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var item in nhom)
                if (item.TenChucVu == tenNhom)
                    DataProvider.Ins.DB.CHUCVUs.Remove(item);
            DataProvider.Ins.DB.SaveChanges();
        }
        #endregion

        #region ICommand
        public ICommand AddNguoiDungCommand { get; set; }
        public ICommand EditNguoiDungCommand { get; set; }
        public ICommand DeleteNguoiDungKCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand CbbSelectionChangedCommand { get; set; }
        public ICommand DialogOK { get; set; }
        #endregion

        #region Function ToolTips
        private void Tat_ToolTip_1()
        {
            if (Error1 == "") Visibility_1 = Visibility.Hidden;
            if (Error2 == "") Visibility_2 = Visibility.Hidden;
            if (Error3 == "") Visibility_3 = Visibility.Hidden;
            if (Error4 == "") Visibility_4 = Visibility.Hidden;
        }

        private void Tat_ToolTip()
        {
            Visibility_1 = Visibility_2 = Visibility_3 = Visibility_4 = Visibility.Hidden;
            Error1 = Error2 = Error3 = Error4 = "";
        }

        private bool Check_ThemNhanVien()
        {
            Tat_ToolTip();
            bool check = true;
            if (TenDangNhap == null || TenDangNhap == "")
            {
                Error1 = "Tên đăng nhập không được để trống";
                Visibility_1 = Visibility.Visible;
                check = false;
            }
            else if (check_hasaWhiteSpace(TenDangNhap))
            {
                Error1 = "Tên đăng nhập không được chứa khoảng trắng";
                Visibility_1 = Visibility.Visible;
                check = false;
            }
            else
            {
                ObservableCollection<TAIKHOAN> list_ngdung = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

                foreach (var item in list_ngdung)
                {
                    if (item.TenDangNhap == TenDangNhap)
                    {
                        Error1 = "Tên đăng nhập đã tồn tại rồi";
                        Visibility_1 = Visibility.Visible;
                        check = false;
                        break;
                    }
                }
            }

            if (MatKhau == null || MatKhau == "")
            {
                Error2 = "Mật khẩu không được để trống";
                Visibility_2 = Visibility.Visible;
                check = false;
            }

            if (HoTen == null || HoTen == "" || check_hasallWhiteSpace(HoTen))
            {
                Error3 = "Họ tên không được để trống";
                Visibility_3 = Visibility.Visible;
                check = false;
            }
            if (SelectedTenNhom == null)
            {
                Error4 = "Chưa chọn vị trí nhóm quyền";
                Visibility_4 = Visibility.Visible;
                check = false;
            }
            Tat_ToolTip_1();
            return check;
        }

        private bool check_SuaNhanVien()
        {
            bool check = true;
            if (MatKhau == null || MatKhau == "")
            {
                Error1 = "Mật khẩu không được để trống";
                Visibility_1 = Visibility.Visible;
                check = false;
            }
            if (HoTen == null || HoTen == "" || check_hasallWhiteSpace(HoTen))
            {
                Error2 = "Họ tên không được để trống";
                Visibility_2 = Visibility.Visible;
                check = false;
            }
            if (SelectedTenNhom == null)
            {
                Error3 = "Chưa chọn vị trí nhóm quyền";
                Visibility_3 = Visibility.Visible;
                check = false;
            }
            Tat_ToolTip_1();
            return check;
        }

        private bool check_ThemNhomQuyen()
        {
            bool check = true;
            if (txtTenNhomQuyen == null || txtTenNhomQuyen == "" || check_hasallWhiteSpace(txtTenNhomQuyen))
            {
                Error1 = "Tên nhóm không để trống";
                Visibility_1 = Visibility.Visible;
                check = false;
            }
            if (Check_TenNhomQuyen(txtTenNhomQuyen))
            {
                Error1 = "Nhóm " + txtTenNhomQuyen + " đã tồn tại! Vui lòng nhập lại tên nhóm khác!";
                Visibility_1 = Visibility.Visible;
                check = false;
            }
            Tat_ToolTip_1();
            return check;
        }
        #endregion
        private string getNewID_NGUOIDUNG()
        {
            ObservableCollection<TAIKHOAN> listNguoiDung = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
            int tmp = listNguoiDung.Count();
            return "TK" + format((tmp + 1).ToString(), 5);
        }

        //public int getNewID_NGUOIDUNG()
        //{
        //    ObservableCollection<TAIKHOAN> listNguoiDung = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);

        //    int max = 0;
        //    foreach (var item in listNguoiDung)
        //    {
        //        int id = int.Parse(item.id);
        //        if (id > max)
        //            max = id;
        //    }
        //    return max + 1;
        //}

        public QuanLyNhanSu_ViewModel()
        {
            Tat_ToolTip();
            TenDanhSachNhom = "Danh sách người dùng";
            isEdit = true;
            LoadData();
            LoadDataPhanQuyen();
            VisibilityOfListPhanQuyen = Visibility.Hidden;
            VisibilityOfTenNhomQuyen = Visibility.Hidden;

            //DialogHost
            DialogOK = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                DialogOpen = false;
            });

            // show elements used for adding
            AddNguoiDungCommand = new RelayCommand<object>((p) =>
            {
                if (VisibilityOfListPhanQuyen == Visibility.Visible)
                    foreach (var item in ListPhanQuyen)
                        if (item.EnabledCheckBox == true)
                            return false;
                if (VisibilityOfEdit == Visibility.Visible)
                    return false;

                return true;
            },
                (p) =>
                {
                    if (VisibilityOfListPhanQuyen == Visibility.Hidden)
                    {
                        VisibilityOfAdd = Visibility.Visible;
                        ResetCbxTenNhom();
                        VisibilityOfEdit = Visibility.Hidden;
                        VisibilityOfTenNhomQuyen = Visibility.Hidden;
                        // reset value for textbox because these textbox still keep value if you are editing and then change to add
                        ResetTextbox();
                    }
                    else
                    {
                        VisibilityOfAdd = Visibility.Hidden;
                        VisibilityOfEdit = Visibility.Hidden;
                        VisibilityOfTenNhomQuyen = Visibility.Visible;
                        // Enable cho selectedPhanQuyen
                        if (SelectedPhanQuyen != null)
                        {
                            BangPhanQuyen PQ = SelectedPhanQuyen;
                            PQ.EnabledCheckBox = false;
                            foreach (var pq in ListPhanQuyen)
                                if (pq.TenNhomQuyen == PQ.TenNhomQuyen)
                                {
                                    ListPhanQuyen.Remove(pq);
                                    ListPhanQuyen.Add(PQ);
                                    SelectedPhanQuyen = PQ;
                                    break;
                                }
                        }
                    }
                }
            );

            // show elements used for editing
            EditNguoiDungCommand = new RelayCommand<object>((p) =>
            {
                if (VisibilityOfAdd == Visibility.Visible)
                    return false;
                if (VisibilityOfTenNhomQuyen == Visibility.Visible)
                    return false;
                return ((SelectedPhanQuyen != null || SelectedItemNguoiDung != null) && isEdit);
            },
                (p) =>
                {

                    if (VisibilityOfListNguoiDung == Visibility.Visible && SelectedItemNguoiDung != null) // Edit Nhóm người dùng
                    {
                        if (SelectedItemNguoiDung._TaiKhoan.NHANVIEN.MaChucVu == "Ban quản lý  ") // edit later hihi
                        {
                            System.Windows.MessageBox.Show("Không thể sửa thông tin được cho nhóm Ban quản lý");
                            return;
                        }    
                        VisibilityOfEdit = Visibility.Visible;
                        VisibilityOfAdd = Visibility.Hidden;
                        MatKhau = SelectedItemNguoiDung.MatKhau;
                        //HoTen = SelectedItemNguoiDung.HoTen;
                        ResetCbxTenNhom();
                        //SelectedTenNhom = SelectedItemNguoiDung.TenNhom;
                    }

                    if (VisibilityOfListPhanQuyen == Visibility.Visible && SelectedPhanQuyen != null) // Edit Bảng phân quyền
                    {

                        if (SelectedPhanQuyen.TenNhomQuyen == "Ban quản lý")
                        {
                            System.Windows.MessageBox.Show("Không thể phân quyền được cho nhóm Ban quản lý");
                            return;
                        }
                        VisibilityOfTenNhomQuyen = Visibility.Hidden;
                        BangPhanQuyen PQ = SelectedPhanQuyen;
                        PQ.EnabledCheckBox = true;
                        foreach (var pq in ListPhanQuyen)
                            if (pq.TenNhomQuyen == PQ.TenNhomQuyen)
                            {
                                ListPhanQuyen.Remove(pq);
                                ListPhanQuyen.Add(PQ);
                                SelectedPhanQuyen = PQ;
                                break;
                            }
                        isEdit = false;
                    }
                }
            );

            DeleteNguoiDungKCommand = new RelayCommand<object>((p) =>
            {
                if (VisibilityOfAdd == Visibility.Visible || VisibilityOfEdit == Visibility.Visible) return false;
                if (VisibilityOfTenNhomQuyen == Visibility.Visible)
                    return false;
                return ((SelectedItemNguoiDung != null || SelectedPhanQuyen != null) && isEdit);
            },
                (p) =>
                {
                    if (VisibilityOfListNguoiDung == Visibility.Visible)
                    {
                        VisibilityOfEdit = Visibility.Hidden;
                        VisibilityOfAdd = Visibility.Hidden;
                        DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn chắc xóa người dùng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        var nguoiDung = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenDangNhap == SelectedItemNguoiDung._TaiKhoan.TenDangNhap).SingleOrDefault();
                        DataProvider.Ins.DB.TAIKHOANs.Remove(nguoiDung);
                        DataProvider.Ins.DB.SaveChanges();
                        if (kq == DialogResult.Yes)
                        {
                            int length = ListNhanVien.Count();
                            for (int i = 0; i < length; i++)
                            {
                                if (ListNhanVien[i]._TaiKhoan.TenDangNhap == SelectedItemNguoiDung._TaiKhoan.TenDangNhap)
                                {
                                    ListNhanVien.RemoveAt(i);
                                    break;
                                }
                            }
                            //System.Windows.Forms.MessageBox.Show("Xóa người dùng thành công");
                            DialogOpen = true;
                            ThongBao = "Xóa người dùng thành công";
                        }
                    }
                    else
                    {
                        VisibilityOfTenNhomQuyen = Visibility.Hidden;
                        DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn chắc xóa nhóm người dùng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (kq == DialogResult.Yes)
                        {
                            string error = check_DeleteNhomNguoiDung(search_MaNhom(SelectedPhanQuyen.TenNhomQuyen));
                            if (error == "")
                            {
                                //System.Windows.Forms.MessageBox.Show("Đã xóa nhóm " + SelectedPhanQuyen.TenNhomQuyen + " thành công!");
                                DialogOpen = true;
                                ThongBao = "Đã xóa nhóm " + SelectedPhanQuyen.TenNhomQuyen + " thành công!";

                                string maNhom = search_MaNhom(SelectedPhanQuyen.TenNhomQuyen);
                                Delete_PhanQuyen(maNhom);
                                Delete_NhomNguoiDung(SelectedPhanQuyen.TenNhomQuyen);
                                ListPhanQuyen.Remove(SelectedPhanQuyen);

                            }
                            else
                                System.Windows.Forms.MessageBox.Show("Không thể xóa. Hãy xóa danh sách người dùng này để thực hiện: \n" + error);
                        }
                    }
                }
            );

            // Button: Confirm for adding NguoiDung
            ConfirmCommand = new RelayCommand<object>((p) =>
            {
                if (VisibilityOfAdd == Visibility.Visible)
                    return true;
                if (VisibilityOfTenNhomQuyen == Visibility.Visible)
                    return true;
                if (VisibilityOfEdit == Visibility.Visible)
                    return true;
                if (SelectedPhanQuyen != null)
                    if (SelectedPhanQuyen.EnabledCheckBox == true)
                        return true;
                    else return false;
                return false;
            }, (p) =>
            {
                try
                {
                    if (VisibilityOfAdd == Visibility.Visible) // Thêm nhân viên
                    {
                        if (Check_ThemNhanVien())
                        {
                            string Ma_Nhom = search_MaNhom(SelectedTenNhom);
                            var nguoiDung = new TAIKHOAN()
                            {
                                id = getNewID_NGUOIDUNG().ToString(),
                                TenDangNhap = TenDangNhap,
                                MatKhau = MatKhau,
                                //HoTen = HoTen,
                                //DiaChi = " ",
                                //SDT = " ",
                                //GioiTinh = " ",
                            };

                            DataProvider.Ins.DB.TAIKHOANs.Add(nguoiDung);
                            DataProvider.Ins.DB.SaveChanges();
                            DialogOpen = true;
                            ThongBao = "Đã thêm nhân viên thành công";
                            //NhanVien nv = new NhanVien(TenDangNhap, MatKhau, HoTen, SelectedTenNhom); // hihi
                            //ListNhanVien.Add(nv);
                            VisibilityOfAdd = Visibility.Hidden;
                            ResetTextbox();
                            VisibilityOfAdd = Visibility.Hidden;
                        }
                    }
                    else if (VisibilityOfEdit == Visibility.Visible)  // Sửa nhân viên
                    {
                        if (check_SuaNhanVien())
                        {
                            var temp = SelectedItemNguoiDung;
                            var nguoiDung = DataProvider.Ins.DB.TAIKHOANs.Where(x => x.TenDangNhap == SelectedItemNguoiDung._TaiKhoan.TenDangNhap).SingleOrDefault();
                            nguoiDung.MatKhau = MatKhau;
                            nguoiDung.NHANVIEN.MaChucVu = search_MaNhom(SelectedTenNhom);
                            //nguoiDung.HoTen = HoTen;
                            DataProvider.Ins.DB.SaveChanges();

                            //System.Windows.Forms.MessageBox.Show("Đã sửa thành công");
                            DialogOpen = true;
                            ThongBao = "Đã sửa thành công";
                            Tat_ToolTip();

                            TAIKHOAN nv = new TAIKHOAN(/*nguoiDung.TenDangNhap, nguoiDung.MatKhau, nguoiDung.HoTen, SelectedTenNhom*/);
                            int length = ListNhanVien.Count();
                            for (int i = 0; i < length; i++)
                            {
                                if (ListNhanVien[i]._TaiKhoan.TenDangNhap == SelectedItemNguoiDung._TaiKhoan.TenDangNhap)
                                {
                                    ListNhanVien.RemoveAt(i);
                                    ListNhanVien.Insert(i, new ThongTinNguoiDung(nv));
                                    break;
                                }
                            }

                            VisibilityOfEdit = Visibility.Hidden;
                            ////After confirming, selected item will die huhu, this line is used for making selected item reborn. 
                            ////You can continue change value without choosing item again if unnecessary
                            //SelectedItemLTK = temp;
                        }
                    }
                    else if (VisibilityOfTenNhomQuyen == Visibility.Visible) // Thêm nhóm quyền
                    {
                        if (check_ThemNhomQuyen())
                        {
                            BangPhanQuyen bpq = new BangPhanQuyen(txtTenNhomQuyen, false);
                            ListPhanQuyen.Add(bpq);
                            //Add Database nhóm người dùng mới
                            CHUCVU nhom = new CHUCVU();
                            nhom.id = CreateCodeNhomNguoiDung();
                            nhom.TenChucVu = txtTenNhomQuyen;
                            DataProvider.Ins.DB.CHUCVUs.Add(nhom);
                            DataProvider.Ins.DB.SaveChanges();
                            VisibilityOfTenNhomQuyen = Visibility.Hidden;
                            DialogOpen = true;
                            ThongBao = "Thêm nhóm quyền thành công";
                            Tat_ToolTip();
                        }
                    }
                    else if (SelectedPhanQuyen.EnabledCheckBox == true) // Sửa nhóm quyền
                    {
                        string maNhom = search_MaNhom(SelectedPhanQuyen.TenNhomQuyen);

                        Delete_PhanQuyen(maNhom);

                        if (SelectedPhanQuyen.chkTuyenDung) Add_PhanQuyen(maNhom, "CN001");
                        if (SelectedPhanQuyen.chkLuongThuong) Add_PhanQuyen(maNhom, "CN002");
                        if (SelectedPhanQuyen.chkLichSu) Add_PhanQuyen(maNhom, "CN003");
                        if (SelectedPhanQuyen.chkDaoTao) Add_PhanQuyen(maNhom, "CN004");
                        if (SelectedPhanQuyen.chkTraCuu) Add_PhanQuyen(maNhom, "CN005");
                        if (SelectedPhanQuyen.chkBanHang) Add_PhanQuyen(maNhom, "CN006");
                        if (SelectedPhanQuyen.chkKhachHang) Add_PhanQuyen(maNhom, "CN007");
                        if (SelectedPhanQuyen.chkBaoCao) Add_PhanQuyen(maNhom, "CN008");
                        if (SelectedPhanQuyen.chkPhanQuyen) Add_PhanQuyen(maNhom, "CN009");
                        if (SelectedPhanQuyen.chkThayDoiQD) Add_PhanQuyen(maNhom, "CN010");
                        DialogOpen = true;
                        ThongBao = "Chỉnh sửa quyền thành công cho nhóm " + SelectedPhanQuyen.TenNhomQuyen;
                        BangPhanQuyen PQ = SelectedPhanQuyen;
                        PQ.EnabledCheckBox = false;
                        foreach (var pq in ListPhanQuyen)
                            if (pq.TenNhomQuyen == PQ.TenNhomQuyen)
                            {
                                ListPhanQuyen.Remove(pq);
                                ListPhanQuyen.Add(PQ);
                                SelectedPhanQuyen = PQ;
                                break;
                            }
                        isEdit = true;
                    }

                }
                catch (Exception e) { };
            });

            CancelCommand = new RelayCommand<object>((p) =>
            {
                return (VisibilityOfTenNhomQuyen == Visibility.Visible || VisibilityOfAdd == Visibility.Visible || VisibilityOfEdit == Visibility.Visible);
            }, (p) =>
            {
                if (VisibilityOfAdd == Visibility.Visible)
                {
                    ResetTextbox();
                    VisibilityOfAdd = Visibility.Hidden;
                }
                else if (VisibilityOfEdit == Visibility.Visible)
                {
                    if (SelectedItemNguoiDung != null)
                    {
                        MatKhau = SelectedItemNguoiDung.MatKhau;
                        //HoTen = SelectedItemNguoiDung.HoTen;
                        //SelectedTenNhom = SelectedItemNguoiDung.TenNhom;
                    }
                    VisibilityOfEdit = Visibility.Hidden;
                }
                else if (VisibilityOfTenNhomQuyen == Visibility.Visible)
                {
                    VisibilityOfTenNhomQuyen = Visibility.Hidden;
                    txtTenNhomQuyen = "";
                }
                Tat_ToolTip();
            });

            CbbSelectionChangedCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                // selected index = 0: choosing list of NGUOIDUNG
                // selected index = 1: choosing list of PhanQuyen
                if (SelectedIndexCbb == 0)
                {
                    Tat_ToolTip();
                    Reset();
                    TenDanhSachNhom = "Danh sách người dùng";
                    VisibilityOfTenNhomQuyen = Visibility.Hidden;
                    VisibilityOfListNguoiDung = Visibility.Visible;
                    VisibilityOfListPhanQuyen = Visibility.Hidden;
                }
                else
                {
                    Tat_ToolTip();
                    Reset();
                    TenDanhSachNhom = "Danh sách phân quyền";
                    VisibilityOfListNguoiDung = Visibility.Hidden;
                    VisibilityOfListPhanQuyen = Visibility.Visible;
                    // co muon an may cai nay ko?
                    VisibilityOfAdd = VisibilityOfEdit = Visibility.Hidden;
                }

            });
        }
    }
}