using Labo3;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            EventType eventType = new EventType()
            {
                Name = "Cinema",
                MinimumAge = 12
            };
            context.EventTypes.Add(eventType);
            context.SaveChanges();
        }
    }

}