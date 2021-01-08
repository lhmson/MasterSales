using MasterSalesDemo.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    class ThemChucVu_ViewModel : BaseViewModel
    {
        public bool isFinished { get; set; } 
        #region Binding Variables
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

        private string _TenChucVu;
        public string TenChucVu
        {
            get { return _TenChucVu; }
            set { _TenChucVu = value; OnPropertyChanged(); }
        }

        private string _PhuCap;
        public string PhuCap
        {
            get { return _PhuCap; }
            set { _PhuCap = value; OnPropertyChanged(); }
        }

        private string _TenPhongBan;
        public string TenPhongBan
        {
            get { return _TenPhongBan; }
            set { _TenPhongBan = value; OnPropertyChanged(); }
        }

        private bool _IsCheckedToggle;
        public bool IsCheckedToggle
        {
            get { return _IsCheckedToggle; }
            set { _IsCheckedToggle = value; OnPropertyChanged(); }
        }

        private bool _TruongPhong;
        public bool TruongPhong
        {
            get { return _TruongPhong; }
            set { _TruongPhong = value; OnPropertyChanged(); }
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

        private bool _EnablePB;
        public bool EnablePB
        {
            get { return _EnablePB; }
            set { _EnablePB = value; OnPropertyChanged(); }
        }

        private bool _EnableTenPB;
        public bool EnableTenPB
        {
            get { return _EnableTenPB; }
            set { _EnableTenPB = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand SelectionChangePBCommand { get; set; }
        public ICommand ClickToggleCommand { get; set; }
        public ICommand DialogOK { get; set; }
        #endregion

        #region
        public bool checkNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                return false;
            foreach (var ch in number)
                if (ch < '0' || ch > '9')
                    return false;
            return true;
        }
        public bool checkTenPhongBan(string tenpb)
        {
            ObservableCollection<PHONGBAN> _listPB = new ObservableCollection<PHONGBAN>(DataProvider.Ins.DB.PHONGBANs);
            foreach (var pb in _listPB)
                if (pb.TenPhong == tenpb)
                    return false;
            return true;
        }
        public bool checkTenChucVu(string tencv)
        {
            ObservableCollection<CHUCVU> _listCV = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var cv in _listCV)
                if (cv.TenChucVu == tencv)
                    return false;
            return true;
        }
        public void ThemChucVu()
        {
            if (string.IsNullOrWhiteSpace(TenChucVu))
            {
                DialogOpen = true;
                ThongBao = "Không được bỏ trống tên chức vụ";
                return;
            }

            if (string.IsNullOrWhiteSpace(PhuCap))
            {
                DialogOpen = true;
                ThongBao = "Không được bỏ trống phụ cấp";
                return;
            }

            if (!checkNumber(PhuCap))
            {
                DialogOpen = true;
                ThongBao = "Phụ cấp chỉ chứa ký tự số";
                return;
            }

            if (!checkTenChucVu(TenChucVu))
            {
                DialogOpen = true;
                ThongBao = "Tên chức vụ này đã có rồi";
                return;
            }
            if (IsCheckedToggle)
            {
                if (string.IsNullOrWhiteSpace(TenPhongBan))
                {
                    DialogOpen = true;
                    ThongBao = "Không được bỏ trống tên phòng ban";
                    return;
                }
                if (!checkTenPhongBan(TenPhongBan))
                {
                    DialogOpen = true;
                    ThongBao = "Tên phòng ban này đã có rồi";
                    return;
                }

                PHONGBAN phongban = new PHONGBAN()
                {
                    id = Global.Ins.autoGeneratePhongBan(),
                    TenPhong = TenPhongBan,
                    MaTrgPB = null,
                    isDeleted = false,
                };
                DataProvider.Ins.DB.PHONGBANs.Add(phongban);
                DataProvider.Ins.DB.SaveChanges();

                CHUCVU chucvu = new CHUCVU()
                {
                    id = Global.Ins.autoGenerateChucVu(),
                    TenChucVu = TenChucVu,
                    MaPhongBan = phongban.id,
                    PhuCap = decimal.Parse(PhuCap),
                    isTrgPB = TruongPhong,
                    isDeleted = false,
                };
                DataProvider.Ins.DB.CHUCVUs.Add(chucvu);
                DataProvider.Ins.DB.SaveChanges();
            }

            if (!IsCheckedToggle)
            {
                if (SelectedPhongBan == null)
                {
                    DialogOpen = true;
                    ThongBao = "Tên phòng ban này đã có rồi";
                    return;
                }

                PHONGBAN phongban = Global.Ins.getPhongBanbyTenPB(SelectedPhongBan);

                CHUCVU chucvu = new CHUCVU()
                {
                    id = Global.Ins.autoGenerateChucVu(),
                    TenChucVu = TenChucVu,
                    MaPhongBan = phongban.id,
                    PhuCap = decimal.Parse(PhuCap),
                    isTrgPB = TruongPhong,
                    isDeleted = false,
                };
                DataProvider.Ins.DB.CHUCVUs.Add(chucvu);
                DataProvider.Ins.DB.SaveChanges();
            }

            isFinished = true;
        }
        #endregion
        public ThemChucVu_ViewModel()
        {
            IconModal = "CloseCircle";
            isFinished = false;
            EnablePB = true;
            EnableTenPB = false;

            ListPhongBan = Global.Ins.getAllTenPhongBan();

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                p.Close();
            });

            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                ThemChucVu();
                if (isFinished)
                    p.Close();
            });

            DialogOK = new RelayCommand<Window>((p) => { return true; }, (p) => {
                DialogOpen = false;
            });

            ClickToggleCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                EnablePB = !IsCheckedToggle;
                EnableTenPB = IsCheckedToggle;
                if (IsCheckedToggle)
                {
                    SelectedPhongBan = null;
                }
                else
                    TenPhongBan = "";
            });
        }
    }
}

