using System;
using System.Data.Entity;
using System.Linq;
using Labo3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLabo3
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (ApplicationContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        [TestMethod]
        public void CanGetEventType()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.EventTypes.ToList().Count);
            }
        }

        [TestMethod]
        public void ModificationValue()
        {
            using (var context = GetContext())
            {
                context.Customers.ToList().First().AccountBalance += 50;
                Assert.AreEqual(50, context.Customers.ToList().First().AccountBalance);
            }

        }

        [TestMethod]
        public void ModificationValue2()
        {
            using (var context = GetContext())
            {
                context.Customers.ToList().First().AccountBalance += 50;
                Assert.AreEqual(100, context.Customers.ToList().First().AccountBalance);
            }

        }

        public ApplicationContext GetContext()
        {
            return new ApplicationContext();
        }
    }
}
