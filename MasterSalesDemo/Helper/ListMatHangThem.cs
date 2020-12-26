using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Helper
{
    public class ListMatHangThem
    {
        public string STT { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string DonGia { get; set; }
        public string Ton { get; set; }

        public ListMatHangThem(string stt, string ma, string ten, string dongia, string ton)
        {
            STT = stt;
            Ma = ma;
            Ten = ten;
            DonGia = dongia;
            Ton = ton;
        }

        public ListMatHangThem (string stt, string ma, string ten, string dongia)
        {
            STT = stt;
            Ma = ma;
            Ten = ten;
            DonGia = dongia;
           
        }

    }
}
