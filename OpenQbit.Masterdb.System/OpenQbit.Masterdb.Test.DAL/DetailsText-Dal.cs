using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQbit.Masterdb.Common.Model;
using OpenQbit.Masterdb.DataAccsess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.Masterdb.Test.DAL
{
    public class DetailsText_Dal
    {
        [TestClass]
        public class DALTest
        {
            public DALTest()
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


            [TestMethod]
            public void CustomerInsertTest()
            {
                MasterDBContext db = new MasterDBContext();
                Details newDetail =
                  new Details
                  { ID = 10, RID = 1000, PRID = 10, ResourceHierachyID = 100 };

                db.Details.Add(newDetail);
                db.SaveChanges();

                Details findDetails =
                    db.Details.Where(C => C.ID == 10).FirstOrDefault();

                Assert.AreEqual(newDetail.ID, findDetails.ID);

                if (findDetails != null)
                {
                    db.Details.Remove(findDetails);
                }

            }
        }
    }
}
