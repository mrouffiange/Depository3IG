using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labo3
{
    //[DataContract(IsReference = true)]
    public class Participation
    {
        [Key, Column(Order = 0)]
        public string UserLogin { get; set; }
        [Key, Column(Order = 1)]
        public int EventId { get; set; }
        public int Grade { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
