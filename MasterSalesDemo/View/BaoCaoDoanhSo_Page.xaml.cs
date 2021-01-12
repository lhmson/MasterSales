using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MasterSalesDemo.ViewModel;

namespace MasterSalesDemo.View
{
    /// <summary>
    /// Interaction logic for BaoCaoDoanhSo_Page.xaml
    /// </summary>
    public partial class BaoCaoDoanhSo_Page : Page
    {
        public BaoCaoDoanhSo_Page()
        {
            InitializeComponent();
            this.DataContext = new BaoCaoDoanhSo_ViewModel();
        }

    }
}
