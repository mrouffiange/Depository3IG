using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    public class Enterprise
    {
        public String Name { get; set; }
        public String Locality { get; set; }

        public Enterprise(String name, String locality)
        {
            Name = name;
            Locality = locality;
        }

        public override string ToString()
        {
            return Name + " " + Locality;
        }
    }
}
