using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    public class ApplicationContext : DbContext
    {
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Filter> Filters { get; set; }

        public DbSet<Participation> Participations { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Success> Successes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPromoter> UserPromoters { get; set; }

        public DbSet<UserStandard> UserStandards { get; set; }
        public ApplicationContext() : base(@"Data Source = tcp:namurmotion.database.windows.net,1433;Initial Catalog = NamurMotionDB; User ID = mrouffiange@namurmotion;Password=MartinFlorian2016")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
