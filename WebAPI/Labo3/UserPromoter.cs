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
    [DataContract]
    public class UserPromoter : User
    {
        [DataMember]
        public string PromoterName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string EMail { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DbGeography GeographicalCoordinates { get; set; }
        [DataMember]
        public double Grade { get; set; }
        [DataMember]
        public EventType Type { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Schedule> Schedules { get; set; }
        public IList<UserStandard> Followers { get; set; }

    }
}
