using MasterSalesDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListTheKho
    {
        public string STT { get; set; }
        public string MaThe { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public string NguoiLap { get; set; }
        public string NgayLap { get; set; }
        public string SLTonKho { get; set; }
        public string SLTonGian { get; set; }

        //public ListTheKho(int stt, THEKHO TK)
        //{
        //    STT = stt + "";
        //    MaThe = TK.MaTheKho;
        //    MaMH = TK.MaMH;
        //    TenMH = TK.MATHANG.TenMH;
        //    NguoiLap = TK.NGUOIDUNG.HoTen;
        //    NgayLap = TK.NgayLap.ToString("dd/MM/yyyy");
        //    SLTonGian = TK.MATHANG.SoLuongTonGian + "";
        //    SLTonKho = TK.SoLuongTonKho + "";
        //}
    }
}
