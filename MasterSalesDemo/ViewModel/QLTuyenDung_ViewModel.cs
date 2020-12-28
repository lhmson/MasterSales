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

using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class QLTuyenDung_ViewModel : BaseViewModel
    {
        public ICommand CloseWindowCommand { get; set; }
        public ICommand OpenLoaiHopDongCommand { get; set; }
        public ICommand OpenThemHopDongCommand { get; set; }

        public QLTuyenDung_ViewModel()
        {
            OpenLoaiHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemLoaiHopDong window = new ThemLoaiHopDong();
                window.ShowDialog();
            });

            OpenThemHopDongCommand = new AppCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                ThemHopDong window = new ThemHopDong();
                window.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return p == null ? false : true; }, (p) => {
                var exit = p as Window;
                exit.Close();
            });
        }
        
    }
}