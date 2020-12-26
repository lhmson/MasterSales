using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MasterSaveDemo.Model
{
    public class TraCuuSTK
    {
        public string Ma { get; set; }
        public string LoaiTietKiem { get; set; }
        public string TenKH { get; set; }
        public string SoDu { get; set; }
        public string NgayDaoHan { get; set; }
        public string LaiSuat { get; set; }
        
        public TraCuuSTK(string MaSo, string TenLTK, string KH, string SoDu, string NgayDH, string LS)
        {
            Ma = MaSo;
            LoaiTietKiem = TenLTK;
            TenKH = KH;
            this.SoDu = SoDu;
            NgayDaoHan = NgayDH;
            LaiSuat = LS;
        }
    }
}
