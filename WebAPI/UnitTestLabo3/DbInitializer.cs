using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labo3;

namespace UnitTestLabo3
{

    class DbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            EventType eventType = new EventType()
            {
                Name = "Name",
                MinimumAge = 12
            };
        context.EventTypes.Add(eventType);
            context.SaveChanges();
        }
    }

}
