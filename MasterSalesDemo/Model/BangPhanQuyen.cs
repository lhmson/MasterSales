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
        public bool chkNhapHang { get; set; }
        public bool chkKiemDuyetNhapHang { get; set; }
        public bool chkBanHang { get; set; }
        public bool chkKiemDuyetXuatHang { get; set; }
        public bool chkTraCuu { get; set; }
        public bool chkBCDS { get; set; }
        public bool chkBCTK { get; set; }
        public bool chkQLNS { get; set; }
        public bool EnabledCheckBox { get; set; }

        public BangPhanQuyen(string Ten, bool Enabled)
        {

            chkNhapHang = chkKiemDuyetNhapHang = chkBanHang = chkTraCuu = chkBCDS = chkBCTK = chkKiemDuyetXuatHang = chkQLNS = false;
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
                                    chkQLNS = true;
                                    break;
                                case "CN002":
                                    chkNhapHang = true;
                                    break;
                                case "CN003":
                                    chkKiemDuyetNhapHang = true;
                                    break;
                                case "CN004":
                                    chkBanHang = true;
                                    break;
                                case "CN005":
                                    chkKiemDuyetXuatHang = true;
                                    break;
                                case "CN006":
                                    chkTraCuu = true;
                                    break;
                                case "CN007":
                                    chkBCDS = true;
                                    break;
                                case "CN008":
                                    chkBCTK = true;
                                    break;
                            }
                        }
                }
        }
    }
}
