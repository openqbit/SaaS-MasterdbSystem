using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Test.BusinessService
{
    [TestClass]
    public class ServiceTest
    {
        public ServiceTest()
        {

        }
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            int expected = 10;

            int actual = 10;

            Assert.AreEqual(expected, actual);
        }

    }
}
