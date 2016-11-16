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
    public abstract class User
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
