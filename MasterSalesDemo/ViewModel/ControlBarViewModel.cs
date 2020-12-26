using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.IO;
using System.Windows.Threading;
using MasterSalesDemo.Model;
using System.Collections.ObjectModel;

namespace MasterSalesDemo.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        //public ICommand MouseMoveCommand { get; set; }
        #endregion

        #region Variable
        private string _NgayGioHienTai;
        public string NgayGioHienTai
        {
            get => _NgayGioHienTai;
            set
            {
                if (_NgayGioHienTai == value)
                    return;
                _NgayGioHienTai = value; ; OnPropertyChanged();
            }
        }

        private string _TenTaiKhoan;
        public string TenTaiKhoan { get => _TenTaiKhoan; set { _TenTaiKhoan = value; OnPropertyChanged(); } }

        private string _ChucVu;
        public string ChucVu { get => _ChucVu; set { _ChucVu = value; OnPropertyChanged(); } }

        public DispatcherTimer _timer;

        private TAIKHOAN user;
        #endregion

        #region function
        private void GetTimeNow()
        {
            NgayGioHienTai = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            // Copy from https://stackoverflow.com/questions/31160201/time-ticking-in-c-sharp-wpf-mvvm
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                //Khởi tạo tài khoản cho toàn bộ chương trình
                InitTaiKhoan();
                NgayGioHienTai = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            };
            _timer.Start();
        }

        private void InitTaiKhoan()
        {
            if (user == LoginViewModel.TaiKhoanSuDung) return; // check to update Ten one time only for utilize

            user = LoginViewModel.TaiKhoanSuDung;
            if (user == null) return;

            DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == user.MaNV);
            TenTaiKhoan = DataProvider.Ins.DB.NHANVIENs.Where(x => x.id == user.MaNV).SingleOrDefault().HoTen;
            //cmt tam thoi hihi
            ObservableCollection<CHUCVU> listNhom = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);
            foreach (var item in listNhom)
                if (user.MaChucVu == item.id)
                {
                    ChucVu = item.TenChucVu;
                    break;
                }
        }
        #endregion

        public ControlBarViewModel()
        {
            GetTimeNow(); // lay ngay gio hien tai bind voi user control
            CloseWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    System.Windows.Forms.DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn có chắc chắn thoát không?", "Đăng xuất", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                    if(kq == System.Windows.Forms.DialogResult.Yes)
                    {
                        //if (LoginViewModel.Quay != null)
                        //{
                        //    ObservableCollection<QUAY> list_quay = new ObservableCollection<QUAY>(DataProvider.Ins.DB.QUAYs);
                        //    foreach (var items in list_quay)
                        //        if (items.MaQuay == LoginViewModel.Quay.MaQuay)
                        //        {
                        //            items.DangSuDung = 0;
                        //            DataProvider.Ins.DB.SaveChanges();
                        //        }
                        //}
                        window.Close();
                    }
                }
            });

            MinimizeWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                Window window = GetWindowParent(p);
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized)
                        window.WindowState = WindowState.Minimized;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            });

            //MouseMoveCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            //{
            //    Window window = GetWindowParent(p);
            //    if (window != null)
            //    {
            //        window.DragMove();
            //    }
            //});
        }

        public Window GetWindowParent(UserControl p)
        {
            return Window.GetWindow(p);
        }
    }
}