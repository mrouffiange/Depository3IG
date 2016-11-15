using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Labo3;

namespace UnitTestProject2
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
        public void CanGetEvent()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(1, context.EventTypes.ToList().Count);
            }
        }

        public ApplicationContext GetContext()
        {
            return new ApplicationContext();
        }
    }
}
