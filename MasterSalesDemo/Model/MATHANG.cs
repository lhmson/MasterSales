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
    
    public partial class MATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATHANG()
        {
            this.CT_HOADON = new HashSet<CT_HOADON>();
            this.CT_PHIEUDATHANG = new HashSet<CT_PHIEUDATHANG>();
        }
    
        public string id { get; set; }
        public string TenMH { get; set; }
        public string DonVi { get; set; }
        public string HinhAnh { get; set; }
        public string MaNCC { get; set; }
        public string MaNhomMH { get; set; }
        public decimal DonGia { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOADON> CT_HOADON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PHIEUDATHANG> CT_PHIEUDATHANG { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
        public virtual NHOMMATHANG NHOMMATHANG { get; set; }
    }
}
