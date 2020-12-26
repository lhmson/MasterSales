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
    /// Interaction logic for 
    /// </summary>
    public partial class BanHang_PrintPreview : Window
    {
        public BanHang_PrintPreview(BanHang_PrintPreview_ViewModel x)
        {
            InitializeComponent();
            this.DataContext = x;
        }
    }
}