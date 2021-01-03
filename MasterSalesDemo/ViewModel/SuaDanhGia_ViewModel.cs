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
using MasterSalesDemo.Helper;

namespace MasterSalesDemo.ViewModel
{
    public class SuaDanhGia_ViewModel : BaseViewModel
    {

        #region Icommand

        public ICommand CloseWindowCommand { get; set; }
        public ICommand EvaluateSkillsOfStaffCommand { get; set; }

        #endregion

        private string _TenKyNang;
        public string TenKyNang { get => _TenKyNang; set { _TenKyNang = value; OnPropertyChanged(); } }

        private List<string> _ListDanhGia;
        public List<string> ListDanhGia
        {
            get { return _ListDanhGia; }
            set
            {
                _ListDanhGia = value;
                OnPropertyChanged(nameof(ListDanhGia));
            }
        }

        private string _LoaiDanhGia;
        public string LoaiDanhGia { get => _LoaiDanhGia; set { _LoaiDanhGia = value; OnPropertyChanged(); } }

        public SuaDanhGia_ViewModel()
        {

        }
        public SuaDanhGia_ViewModel(DANHGIAKYNANG dgkn)
        {
            ListDanhGia = new List<string>() { "Xuất sắc", "Giỏi", "Khá" };

            KYNANG kn = DataProvider.Ins.DB.KYNANGs.Where(x => x.id == dgkn.MaKyNang).FirstOrDefault();
            TenKyNang = kn.TenKyNang;

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Global.Ins.isValid = false;
                p.Close();
            });

            #region sửa trình độ

            EvaluateSkillsOfStaffCommand = new RelayCommand<object>((p) =>
            {
                if (LoaiDanhGia == null)
                    return false;
                return true;

            }, (p) =>
            {
                var danhgiakynang = DataProvider.Ins.DB.DANHGIAKYNANGs.Where(x => x.id == dgkn.id).SingleOrDefault();
                danhgiakynang.LoaiDanhGia = LoaiDanhGia;
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("Bạn lưu thành công");
            });
            #endregion

        }
    }

}