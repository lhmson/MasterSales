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
    
    public partial class TAIKHOAN
    {
        public string id { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Avatar { get; set; }
        public string MaNV { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
