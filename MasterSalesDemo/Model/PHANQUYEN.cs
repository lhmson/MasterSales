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
    
    public partial class PHANQUYEN
    {
        public string MaChucNang { get; set; }
        public string MaChucVu { get; set; }
        public string GhiChu { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual CHUCNANG CHUCNANG { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
    }
}
