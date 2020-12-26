using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListCTTheKho
    {
        //public string STT { get; set; }
        //public string Loai { get; set; }
        //public string Ngay { get; set; }
        //public string Nhap { get; set; }
        //public string Xuat { get; set; }
        //public string DienGiai { get; set; }
        //public string MaPhieu { get; set; }

        //public void check_PhieuNhap(string maPhieu, string maMH)
        //{
        //    ObservableCollection<CT_PHIEUNHAPKHO> list_CTphieu = new ObservableCollection<CT_PHIEUNHAPKHO>(DataProvider.Ins.DB.CT_PHIEUNHAPKHO);

        //    foreach (var phieu in list_CTphieu)
        //        if (phieu.MaPhieuNhapKho == maPhieu && phieu.MaMH == maMH)
        //        {
        //            MaPhieu = phieu.MaPhieuNhapKho;
        //            Loai = "Nhập hàng";
        //            Ngay = phieu.PHIEUNHAPKHO.NgayLap.ToString("dd/MM/yyyy");
        //            Nhap = phieu.SoLuong + "";
        //            Xuat = "0";
        //            DienGiai = "";
        //        }
        //}

        //public void check_PhieuXuat(string maPhieu, string maMH)
        //{
        //    ObservableCollection<CT_PHIEUXUATKHO> list_CTphieu = new ObservableCollection<CT_PHIEUXUATKHO>(DataProvider.Ins.DB.CT_PHIEUXUATKHO);

        //    foreach (var phieu in list_CTphieu)
        //        if (phieu.MaPhieuXK == maPhieu && phieu.MaMH == maMH)
        //        {
        //            MaPhieu = phieu.MaPhieuXK;
        //            Loai = "Xuất hàng";
        //            Ngay = phieu.PHIEUXUATKHO.NgayLap.ToString("dd/MM/yyyy");
        //            Xuat = phieu.SoLuong + "";
        //            Nhap = "0";
        //            DienGiai = "";
        //        }
        //}

        //public ListCTTheKho(int stt, CT_THEKHO ct)
        //{
        //    STT = stt + "";
        //    check_PhieuNhap(ct.MaPhieuNhapXuat, ct.THEKHO.MaMH);
        //    check_PhieuXuat(ct.MaPhieuNhapXuat, ct.THEKHO.MaMH);
        //}
    }
}
