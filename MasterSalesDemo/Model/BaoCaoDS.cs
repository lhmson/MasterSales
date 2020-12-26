using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class BaoCaoDS
    {
        public int SoThuTu { get; set; }
        public string TenLoaiTietKiem { get; set; }
        public decimal TongThu { get; set; }
        public decimal TongChi { get; set; }
        public decimal ChenhLech { get; set; }

        public BaoCaoDS(int stt, string tenLoaiTK, decimal thu, decimal chi, decimal chenhLech)
        {
            this.SoThuTu = stt;
            this.TenLoaiTietKiem = tenLoaiTK;
            this.TongThu = thu;
            this.TongChi = chi;
            this.ChenhLech = chenhLech;
        }
    }
}
