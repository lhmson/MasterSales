using Microsoft.Expression.Interactivity.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterSalesDemo.Model
{
    public class ListBaoCaoDongMo_DaBaoCao
    {

        public string ThangNamDaBaoCao { get; set; }
        public string LTKDaBaoCao { get; set; }

        public ListBaoCaoDongMo_DaBaoCao(string TN, string LTK)
        {
            ThangNamDaBaoCao = TN;
            LTKDaBaoCao = LTK;
        }
    }
}