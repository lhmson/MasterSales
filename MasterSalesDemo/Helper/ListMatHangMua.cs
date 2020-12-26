using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListMatHangMua
    {
        public string STT { get; set; }
        public string MaMH { get; set; }
        public string MatHang { get; set; }
        public string DonVi { get; set; }
        public string DonGia { get; set; }
        public string SoLuong { get; set; }
        public string ThanhTien { get; set; }

        public ListMatHangMua(string stt, string ma, string mh, string dv, string dongia, string sl, string tt)
        {
            STT = stt;
            MaMH = ma;
            MatHang = mh;
            DonVi = dv;
            DonGia = dongia;
            SoLuong = sl;
            ThanhTien = tt;
        }
    }
}
