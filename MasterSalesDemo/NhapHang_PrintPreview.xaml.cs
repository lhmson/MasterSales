using MasterSalesDemo.ViewModel;
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

namespace MasterSalesDemo
{
    /// <summary>
    /// Interaction logic for NhapHang_PrintPreview.xaml
    /// </summary>
    public partial class NhapHang_PrintPreview : Window
    {
        public NhapHang_PrintPreview(BaseViewModel x)
        {
            InitializeComponent();
            this.DataContext = x;
        }
    }
}