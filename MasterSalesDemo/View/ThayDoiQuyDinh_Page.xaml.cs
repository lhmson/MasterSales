using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ThayDoiQuyDinh_Page.xaml
    /// </summary>
    public partial class ThayDoiQuyDinh_Page : Page
    {
        public ThayDoiQuyDinh_Page()
        {
            InitializeComponent();
            this.DataContext = new ThayDoiQuyDinh_ViewModel();
        }
    }
}
