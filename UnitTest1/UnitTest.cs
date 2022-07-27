
using System;
using Item_Type;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Book m = new Book("m", new DateTime(1, 1, 1222), 12);
            Book m1 = new Book("m", new DateTime(1, 1, 1222), 12);
            Assert.IsTrue(m.Equals(m1));
        }
    }
}
