﻿using System;
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

namespace MasterSalesDemo
{
    /// <summary>
    /// Interaction logic for ThemGioHang_Window.xaml
    /// </summary>
    public partial class ThemGioHang_Window : Window
    {
        public ThemGioHang_Window()
        {
            InitializeComponent();
            this.DataContext = new ThemGioHang();
        }
    }
}
