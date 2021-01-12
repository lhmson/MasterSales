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

namespace MasterSalesDemo
{
    /// <summary>
    /// Interaction logic for QLTuyenDung_Page.xaml
    /// </summary>
    public partial class QLKiNang_Page : Page
    {
        public QLKiNang_Page()
        {
            InitializeComponent();
            this.DataContext = new QLKiNang_ViewModel();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9,]+");
        }
    }
}
