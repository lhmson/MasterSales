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
    public class ChuyenChucVu_ViewModel : BaseViewModel
    {
        #region Variables
        private CHUCVU checkPointChucVu;
        #endregion
        #region Binding Variables
        private ObservableCollection<string> _ListPhongBan;
        public ObservableCollection<string> ListPhongBan
        {
            get { return _ListPhongBan; }
            set { _ListPhongBan = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> _ListChucVu;
        public ObservableCollection<string> ListChucVu
        {
            get { return _ListChucVu; }
            set { _ListChucVu = value; OnPropertyChanged(); }
        }

        private string _SelectedPhongBan;
        public string SelectedPhongBan
        {
            get { return _SelectedPhongBan; }
            set { _SelectedPhongBan = value; OnPropertyChanged(); }
        }

        private string _SelectedChucVu;
        public string SelectedChucVu
        {
            get { return _SelectedChucVu; }
            set { _SelectedChucVu = value; OnPropertyChanged(); }
        }

        private string _TenNhanVien;
        public string TenNhanVien
        {
            get { return _TenNhanVien; }
            set { _TenNhanVien = value; OnPropertyChanged(); }
        }

        private string _ChucVu;
        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; OnPropertyChanged(); }
        }
        #endregion

        #region Icommand
        public ICommand CloseWindowCommand { get; set; }
        public ICommand XacNhanCommand { get; set; }
        public ICommand SelectionChangePBCommand { get; set; }
        #endregion

        #region
        public void SelectedPB()
        {
            ListChucVu.Clear();
            SelectedChucVu = null;
            PHONGBAN phongban = Global.Ins.getPhongBanbyTenPB(SelectedPhongBan);
            ListChucVu = Global.Ins.getAllTenChucVubyMaPB(phongban.id);
        }

        public bool checkChuyen()
        {
            if (SelectedChucVu == null)
            {
                MessageBox.Show("Bạn chưa chọn chức vụ để chuyển chức vụ");
                return false;
            }

            if (SelectedPhongBan == null)
            {
                MessageBox.Show("Bạn chưa chọn phòng ban");
                return false;
            }

            CHUCVU chucvu = Global.Ins.getChucVubyTenCVTenPB(SelectedChucVu, SelectedPhongBan);
            if (chucvu == null)
            {
                MessageBox.Show("Xin lỗi! hiện tại hệ thống không tìm thấy chức vụ bạn muốn! Mời bạn quay lại sau");
                return false;
            }

            if (chucvu == checkPointChucVu)
            {
                MessageBox.Show("Nhân viên này hiện tại đang ở chức vụ này rồi! Vui lòng chọn chức vụ khác");
                return false;
            }

            return true;
        }
        public void XacNhanChuyen(NHANVIEN nhanvien)
        {
            bool ok = checkChuyen();
            Global.Ins.isValid = false;
            if (ok)
            {
                CHUCVU chucvu = Global.Ins.getChucVubyTenCVTenPB(SelectedChucVu, SelectedPhongBan);
                Global.Ins.TaoChucVuNhanVien(nhanvien, chucvu);
                MessageBox.Show("Bạn đã chuyển chức vụ thành công");
                Global.Ins.isValid = true;
            }
        }
        #endregion
        public ChuyenChucVu_ViewModel()
        {

        }
        public ChuyenChucVu_ViewModel(NHANVIEN nhanvien)
        {
            TenNhanVien = nhanvien.HoTen;           
            CHUCVU chucvu =  Global.Ins.getChucVubyMaNV(nhanvien.id);
            PHONGBAN phongban = chucvu.PHONGBAN;
            ChucVu = chucvu.TenChucVu + " - " + phongban.TenPhong;

            checkPointChucVu = chucvu;
            ListPhongBan = Global.Ins.getAllTenPhongBan();
            ListChucVu = new ObservableCollection<string>();

            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                Global.Ins.isValid = false;
                p.Close();
            });

            SelectionChangePBCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                SelectedPB();
            });

            XacNhanCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                XacNhanChuyen(nhanvien);
                if (Global.Ins.isValid)
                    p.Close();
            });
        }
    }
}
