using MasterSalesDemo.View;
using MasterSalesDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterSalesDemo.Model;
using MasterSalesDemo.Helper;

namespace MasterSalesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Management Page Selections

       // private Home_Page HomePage = new Home_Page();
       // private QLTuyenDung_Page MoSoPage = new QLTuyenDung_Page();
       //// private XuatHang_Page GuiTienPage = new XuatHang_Page();
       // private BanHang_Page RutTienPage = new BanHang_Page();
       // private BaoCaoDoanhSo_Page BaoCaoDoanhSoPage = new BaoCaoDoanhSo_Page();
       // private BaoCaoTonKho_Page BaoCaoMoDongPage = new BaoCaoTonKho_Page();
       // private ThayDoiQuyDinh_Page ThayDoiQuyDinhPage = new ThayDoiQuyDinh_Page();
       // private QuanLyNhanSu_Page QuanLyNhanSuPage = new QuanLyNhanSu_Page();
       // private CaiDatKhac_Page CaiDatKhacPage = new CaiDatKhac_Page();
       // private TraCuu_Page TraCuuPage = new TraCuu_Page();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Logout_Button_Selected(object sender, RoutedEventArgs e)
        {
            DialogResult kq = System.Windows.Forms.MessageBox.Show("Bạn có chắc đăng xuất tài khoản này không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == System.Windows.Forms.DialogResult.No)
                return;

            //if (LoginViewModel.TaiKhoanSuDung.CHUCVU.TenChucVu == "Bộ phận Thu ngân")
            //{
            //    ObservableCollection<QUAY> list_quay = new ObservableCollection<QUAY>(DataProvider.Ins.DB.QUAYs);

            //    foreach (var item in list_quay)
            //        if (item.MaQuay == LoginViewModel.Quay.MaQuay)
            //        {
            //            item.DangSuDung = 0;
            //            DataProvider.Ins.DB.SaveChanges();
            //            break;
            //        }    
                  
            //}

            this_.Hide();
            LoginWindow loginWindow = new LoginWindow();
            LoginViewModel.TaiKhoanSuDung = null;
            loginWindow.ShowDialog();
            MainViewModel.Start_Timer();
            this_.Show();
        }
    }
}
