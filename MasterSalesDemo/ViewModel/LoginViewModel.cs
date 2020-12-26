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

        //public QUAY init_Quay()
        //{
        //    ObservableCollection<QUAY> list_quay = new ObservableCollection<QUAY>(DataProvider.Ins.DB.QUAYs);

        //    foreach (var item in list_quay)
        //        if (item.DangSuDung == 0)
        //        {
        //            if (TaiKhoanSuDung.NHOMNGUOIDUNG.TenNhom == "Thu ngân")
        //                item.DangSuDung = 1;
        //            DataProvider.Ins.DB.SaveChanges();
        //            return item;
        //        }
        //    return null;
        //}
        public LoginViewModel()
        {
            //DatabaseCheck.Ins.Check();
            //ObservableCollection<QUAY> Quays = new ObservableCollection<QUAY>(DataProvider.Ins.DB.QUAYs);

            //foreach (var item in Quays)
            //    if (item.MaQuay == "Q001")
            //        Quay = item;

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
                        //Gan static TaiKhoanSuDung
                        TaiKhoanSuDung = item;
                        //Quay = init_Quay();
                        //if (Quay == null && TaiKhoanSuDung.NHOMNGUOIDUNG.TenNhom=="Thu ngân")
                        //{
                        //    MessageBox.Show("Hiện tại không có quầy trống! Mời bạn quay lại sau");
                        //    return;
                        //}
                        //MessageBox.Show("Đăng nhập thành công");
                        p.Close();
                        return;
                    }

                }
                MessageBox.Show("Tài khoản không hợp lệ!");
              
                //CheckLogin(p);
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
