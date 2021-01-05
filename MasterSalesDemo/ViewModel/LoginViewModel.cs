using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        static public TAIKHOAN TaiKhoanSuDung; // tao bien static nguoi dung
        //static public QUAY Quay;

        public ICommand CloseWindowCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public LoginViewModel()
        {
            UserName = "";
            Password = "";

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (UserName == null || Password == null)
                    MessageBox.Show("Mời nhập tài khoản!");

                ObservableCollection<TAIKHOAN> Account = new ObservableCollection<TAIKHOAN>(DataProvider.Ins.DB.TAIKHOANs);
                foreach (var item in Account)
                {
                    if (item.TenDangNhap == UserName && item.MatKhau == Password)
                    {
                        TaiKhoanSuDung = item;
                        Global.Ins.setNhanVien(item.NHANVIEN);
                        p.Close();
                        return;
                    }

                }
                MessageBox.Show("Tài khoản không hợp lệ!");
            });

            CloseWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) => {
                p.Close();
                System.Environment.Exit(1);
            });

            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });
        }

    }
}
