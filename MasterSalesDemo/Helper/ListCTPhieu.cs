using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListCTPhieu
    {
        public string STT { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string SoLuong { get; set; }

        public ListCTPhieu(string stt, string ma, string ten, string sl)
        {
            STT = stt;
            Ma = ma;
            Ten = ten;
            SoLuong = sl;
        }
    }
}
