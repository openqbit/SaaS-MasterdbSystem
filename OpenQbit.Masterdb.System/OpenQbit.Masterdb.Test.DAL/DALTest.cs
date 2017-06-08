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
            Resorce newResorce =
              new Resorce
              { ID = 10, Type = "dd", TypeID = 1000 };

            db.Resorce.Add(newResorce);
            db.SaveChanges();
            //using System.Linq; //using System.Data; //using System.Data.Entity;
            Resorce findResorce =
                db.Resorce.Where(C => C.ID == 10).FirstOrDefault();

            Assert.AreEqual(newResorce.ID, findResorce.ID);

            if (findResorce != null)
            {
                db.Resorce.Remove(findResorce); // remove from Db
            }

        }

    }
}
