using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterSalesDemo.ViewModel;
using NUnit.Framework;

namespace MasterSalesDemo.UnitTest
{
    [TestFixture]
    public class TestQuanLyNhanVien
    {
        private QuanLyNhanSu_ViewModel _QLNS;

        [SetUp]
        public void Setup()
        {
            _QLNS = new QuanLyNhanSu_ViewModel();
        }

        [TestCase(true, "Ban Quản lý")]
        [TestCase(true, "Thu Ngân")]
        [TestCase(true, "Cửa Hàng Trưởng")]
        [TestCase(true, "HR")]
        [TestCase(false, "Trưởng Phòng Nhân Sự")]
        [TestCase(false, "Kế toán")]

        public void TestTonTaiQuyen(bool ok, string name)
        {
            Assert.AreEqual(ok, _QLNS.Check_TenNhomQuyen(name));
        }

        [TestCase(2, "Thủ Kho")]
        [TestCase(3, "Thu Ngân")]
        [TestCase(4, "Cửa Hàng Trưởng")]
        [TestCase(5, "HR")]
        [TestCase(6, "Ban quản lý")]

        public void Tim_MaNhom(int number, string name)
        {
            Assert.AreEqual(number, _QLNS.search_MaNhom(name));
        }
    }

}