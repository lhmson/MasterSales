//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterSalesDemo.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HOADON
    {
        public string id { get; set; }
        public string MaHD { get; set; }
        public string MaMH { get; set; }
        public int SLMua { get; set; }
        public decimal DonGia { get; set; }
        public decimal TongTien { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual MATHANG MATHANG { get; set; }
    }
}
