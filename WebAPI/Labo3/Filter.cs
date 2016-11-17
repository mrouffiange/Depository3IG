using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labo3
{
    [DataContract(IsReference = true)]
    public class Filter
    {
        [Key]
        [DataMember]
        public string Tag { get; set; }
        [DataMember]
        public IList<Event> Events { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
