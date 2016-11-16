using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Labo3
{
    //[DataContract(IsReference = true)]
    public class UserPromoter : User
    {
        public string PromoterName { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string Description { get; set; }
        public DbGeography GeographicalCoordinates { get; set; }
        public double Grade { get; set; }
        public EventType Type { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Schedule> Schedules { get; set; }
        public IList<UserStandard> Followers { get; set; }

    }
}
