using MasterSalesDemo.Model;
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

namespace MasterSalesDemo.View
{
    /// <summary>
    /// Interaction logic for SuaDanhGiaKN.xaml
    /// </summary>
    public partial class SuaDanhGiaKN : Window
    {

        public SuaDanhGiaKN(DANHGIAKYNANG dgkn)
        {
            InitializeComponent();
            this.DataContext = new SuaDanhGiaKN(dgkn);
        }
    }
}
