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
using System.Windows.Shapes;
using MasterSalesDemo.ViewModel;

namespace MasterSalesDemo.View
{
    /// <summary>
    /// Interaction logic for ThemHopDong.xaml
    /// </summary>
    public partial class ThemHopDong : Window
    {
        public ThemHopDong()
        {
            InitializeComponent();
            this.DataContext = new QLTuyenDung_ViewModel();
        }
    }
}
