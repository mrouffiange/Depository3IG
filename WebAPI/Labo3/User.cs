using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labo3
{
    // [DataContract(IsReference = true)]
    [DataContract]
    public abstract class User
    {
        [Key]
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
