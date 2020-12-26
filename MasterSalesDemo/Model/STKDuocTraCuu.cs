using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class STKDuocTraCuu
    {
        public string STT { get; set; }
        public string Ma { get; set; }
        public string LoaiTietKiem { get; set; }
        public string TenKH { get; set; }
        public string SoDu { get; set; }
        public string NgayDaoHan { get; set; }
        public string LaiSuat { get; set; }
        public string NgayMoSo { get; set; }
        public string NgayDongSo { get; set; }

        public STKDuocTraCuu(string MaSo, string TenLTK, string KH, string SoDu, string NgayDH, string LS, string NgayMoSo, int KyHan, DateTime? NgayDongSo)
        {
            STT = "";
            Ma = MaSo;
            LoaiTietKiem = TenLTK;
            TenKH = KH;
            this.SoDu = SoDu;
            NgayDaoHan = NgayDH;
            LaiSuat = LS;
            this.NgayMoSo = NgayMoSo;
            if (KyHan == 0)
                NgayDaoHan = "Không xác định";
            if (NgayDongSo == null)
                this.NgayDongSo = "Chưa đóng";
            else this.NgayDongSo = NgayDongSo.Value.ToString("dd-MM-yyyy");
        }
    }
}