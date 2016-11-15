using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo3
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime BeginHour{ get; set; }
        public DateTime EndHour { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
