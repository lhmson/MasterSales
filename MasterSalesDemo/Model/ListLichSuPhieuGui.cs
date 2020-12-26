using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class ListLichSuPhieuGui
    {
        public string MaPG { get; set; }
        public string NgayGuiTien { get; set; }
        public string TienGui { get; set; }
        public ListLichSuPhieuGui()
        {

        }
        public ListLichSuPhieuGui(string MaPhieu, string Ngay, string Tien)
        {
            MaPG = MaPhieu;
            NgayGuiTien= Ngay;
            TienGui = Tien;
        }
    }
}