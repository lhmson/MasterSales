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
    /// Interaction logic for QLLuongThuong_Page.xaml
    /// </summary>
    public partial class QLLuongThuong_Page : Page
    {
        public QLLuongThuong_Page()
        {
            InitializeComponent();
            this.DataContext = new QLLuongThuong_ViewModel();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9,]+");
        }

    }
}
