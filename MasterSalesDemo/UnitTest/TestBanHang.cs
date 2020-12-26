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
    public class TestBanHang
    {
        [TestFixture]
        public class UnitTestBanHang
        {
            private BanHang_ViewModel _BanHang;

            [SetUp]
            public void Setup()
            {
                _BanHang = new BanHang_ViewModel();
            }

            [TestCase("19/12/2020")]

            public void TestNgayHoaDon(string testDate)
            {
                //Assert.AreEqual(testDate, _BanHang.get_DateNow()); // test hihi
            }

            [TestCase("HD00001", 1)]
            [TestCase("HD00012", 12)]
            [TestCase("HD00178", 178)]
            [TestCase("HD01172", 1172)]

            public void getCodeHD(string input, int output)
            {
                //Assert.AreEqual(_BanHang.trans_number_HD(input), output); // test hihi
            }

            [TestCase(1, "00000001")]
            [TestCase(123, "00000123")]
            [TestCase(827, "00000827")]
            [TestCase(12, "00000012")]

            public void initCodeHD(int input, string output)
            {
                //Assert.AreEqual(_BanHang.trans_string_HD(input), output); // test hihi
            }
        }
    }
}