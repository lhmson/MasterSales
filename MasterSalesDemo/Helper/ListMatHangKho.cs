using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListMatHangKho
    {
        public string STT { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string Ton { get; set; }

        public ListMatHangKho(string stt, string ma, string ten, string ton)
        {
            STT = stt;
            Ma = ma;
            Ten = ten;
            Ton = ton;
        }
    }
}
