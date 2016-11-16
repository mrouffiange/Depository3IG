using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Labo3
{
    //[DataContract(IsReference = true)]
    public class Success
    {
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public IList<UserStandard> User { get; set; }
    }
}
