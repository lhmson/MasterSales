using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class ListBaoCaoDongMo
    {
        public string STT { get; set; }
        public string Ngay { get; set; }
        public string SoMo { get; set; }
        public string SoDong { get; set; }
        public string ChenhLech { get; set; }
        public ListBaoCaoDongMo(string SoTT, string NgayXem, string SoDaMo, string SoDaDong, string SoChenhLech)
        {
            STT = SoTT;
            Ngay = NgayXem;
            SoMo = SoDaMo;
            SoDong = SoDaDong;
            ChenhLech = SoChenhLech;
        }
    }
}