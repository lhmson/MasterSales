using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MasterSalesDemo.Model
{
    public class BangPhanQuyen
    {
        public string TenNhomQuyen { get; set; }
        public bool chkTuyenDung { get; set; }
        public bool chkLuongThuong { get; set; }
        public bool chkLichSu { get; set; }
        public bool chkDaoTao { get; set; }
        public bool chkTraCuu { get; set; }
        public bool chkNhanVien { get; set; }
        public bool chkBanHang { get; set; }
        public bool chkBaoCao { get; set; }
        public bool chkKhachHang { get; set; }
        public bool chkPhanQuyen { get; set; }
        public bool chkThayDoiQD { get; set; }
        public bool EnabledCheckBox { get; set; }

        public BangPhanQuyen(string Ten, bool Enabled)
        {

            chkTuyenDung = chkLuongThuong = chkLichSu = chkDaoTao = chkTraCuu = chkNhanVien 
                = chkBanHang = chkBaoCao = chkKhachHang = chkPhanQuyen = chkThayDoiQD = false;
            EnabledCheckBox = Enabled;

            ObservableCollection<PHANQUYEN> phanQuyen = new ObservableCollection<PHANQUYEN>(DataProvider.Ins.DB.PHANQUYENs);
            ObservableCollection<CHUCVU> nhomnguoiDung = new ObservableCollection<CHUCVU>(DataProvider.Ins.DB.CHUCVUs);

            TenNhomQuyen = Ten;
            foreach (var nhom in nhomnguoiDung)
                if (nhom.TenChucVu == Ten)
                {
                    foreach (var PQ in phanQuyen)
                        if (PQ.MaChucVu==nhom.id)
                        {
                            switch (PQ.MaChucNang)
                            {
                                case "CN001":
                                    chkTuyenDung = true;
                                    break;
                                case "CN002":
                                    chkLuongThuong = true;
                                    break;
                                case "CN003":
                                    chkLichSu = true;
                                    break;
                                case "CN004":
                                    chkDaoTao = true;
                                    break;
                                case "CN005":
                                    chkTraCuu = true;
                                    break;
                                case "CN006":
                                    chkBanHang = true;
                                    break;
                                case "CN007":
                                    chkKhachHang = true;
                                    break;
                                case "CN008":
                                    chkBaoCao = true;
                                    break;
                                case "CN009":
                                    chkPhanQuyen = true;
                                    break;
                                case "CN010":
                                    chkThayDoiQD = true;
                                    break;
                            }
                        }
                }
        }
    }
}
