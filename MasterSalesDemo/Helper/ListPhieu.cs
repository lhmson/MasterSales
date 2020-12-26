using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListPhieu
    {
        public string STT { get; set; }
        public string Ma { get; set; }
        public string NgayLap { get; set; }
        public string Quay { get; set; }
        public string NguoiLap { get; set; }

        public ListPhieu(string stt, string ma, string ngay, string quay, string nguoilap)
        {
            STT = stt;
            Ma = ma;
            NgayLap = ngay;
            Quay = quay;
            NguoiLap = nguoilap;
        }

        public ListPhieu(string stt, string ma, string ngay, string nguoilap)
        {
            STT = stt;
            Ma = ma;
            NgayLap = ngay;
            NguoiLap = nguoilap;
        }
    }
}
