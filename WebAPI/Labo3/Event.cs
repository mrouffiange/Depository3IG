using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    [DataContract(IsReference = true)]
    public class Event
    {
        [Key]
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public DateTime BeginDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string ShortDescription { get; set; }
        [DataMember]
        public string CompleteDescription { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int MinimumAge { get; set; }
        [DataMember]
        public Schedule EventSchedule { get; set; }
        [DataMember]
        public UserPromoter EventPromoter { get; set; }
        [DataMember]
        public EventType TypeOfEvent { get; set; }
        [DataMember]
        public IList<Filter> Filters { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
