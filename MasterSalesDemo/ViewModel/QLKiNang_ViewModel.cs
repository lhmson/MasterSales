using MasterSalesDemo.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using MasterSalesDemo.View;
using System.Windows.Input;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace MasterSalesDemo.ViewModel
{
    public class QLKiNang_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenKyNangCommand { get; set; }
        public ICommand OpenTrinhDoCommand { get; set; }

        public QLKiNang_ViewModel()
        {
            OpenKyNangCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                KyNang window = new KyNang();
                window.ShowDialog();
            });

            OpenTrinhDoCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TrinhDo window = new TrinhDo();
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                var exit = p as Window;
                exit.Close();
            });
        }
    }
}
