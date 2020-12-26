using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class ListLichSuPhieuRut
    {
        public string MaPR { get; set; }
        public string NgayRutTien { get; set; }
        public string TienRut { get; set; }
        public ListLichSuPhieuRut()
        {

        }
        public ListLichSuPhieuRut(string MaPhieu, string Ngay, string Tien)
        {
            MaPR = MaPhieu;
            NgayRutTien = Ngay;
            TienRut = Tien;
        }
    }
}