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
    
    public partial class HOPDONG
    {
        public string id { get; set; }
        public string MaNV { get; set; }
        public Nullable<System.DateTime> NgayHD { get; set; }
        public Nullable<System.DateTime> NgayKT { get; set; }
        public string MaLoaiHD { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual LOAIHOPDONG LOAIHOPDONG { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
