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
    public class Success
    {
        [Key]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Points { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [DataMember]
        public IList<UserStandard> User { get; set; }
    }
}
