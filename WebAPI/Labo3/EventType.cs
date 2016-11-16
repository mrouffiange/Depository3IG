using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    //[DataContract(IsReference = true)]
    public class EventType
    {
        [Key]
        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Event> Promoters { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
