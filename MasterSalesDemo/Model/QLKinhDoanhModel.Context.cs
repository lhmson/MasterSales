﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLKinhDoanhEntities : DbContext
    {
        public QLKinhDoanhEntities()
            : base("name=QLKinhDoanhEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BANGLAMTHEM> BANGLAMTHEMs { get; set; }
        public virtual DbSet<BANGLUONGTL> BANGLUONGTLs { get; set; }
        public virtual DbSet<BANGTHUONG> BANGTHUONGs { get; set; }
        public virtual DbSet<CHUCNANG> CHUCNANGs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CT_BANGLAMTHEM> CT_BANGLAMTHEM { get; set; }
        public virtual DbSet<CT_BANGLUONGTL> CT_BANGLUONGTL { get; set; }
        public virtual DbSet<CT_BANGTHUONG> CT_BANGTHUONG { get; set; }
        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<CT_PHIEUDATHANG> CT_PHIEUDATHANG { get; set; }
        public virtual DbSet<DANHGIAKYNANG> DANHGIAKYNANGs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<HOPDONG> HOPDONGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<KYNANG> KYNANGs { get; set; }
        public virtual DbSet<LICHSUCHUCVU> LICHSUCHUCVUs { get; set; }
        public virtual DbSet<LOAIHOPDONG> LOAIHOPDONGs { get; set; }
        public virtual DbSet<MATHANG> MATHANGs { get; set; }
        public virtual DbSet<MUCTHUONG> MUCTHUONGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHOMMATHANG> NHOMMATHANGs { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYENs { get; set; }
        public virtual DbSet<PHIEUDATHANG> PHIEUDATHANGs { get; set; }
        public virtual DbSet<PHONGBAN> PHONGBANs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }
        public virtual DbSet<TRINHDO> TRINHDOes { get; set; }
        public virtual DbSet<TuVanKH> TuVanKHs { get; set; }
        public List<DANHGIAKYNANG> DANHGIAKYNANG { get; internal set; }
        public List<KYNANG> KYNANG { get; internal set; }
    }
}
