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
    //[DataContract(IsReference = true)]
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShortDescription { get; set; }
        public string CompleteDescription { get; set; }
        public double Price { get; set; }
        public int MinimumAge { get; set; }
        public Schedule EventSchedule { get; set; }
        public UserPromoter EventPromoter { get; set; }
        public EventType TypeOfEvent { get; set; }
        public IList<Filter> Filters { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
