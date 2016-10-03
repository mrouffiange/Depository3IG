using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    public abstract class Person
    {
        public String Name { get; set; }

        public String LastName { get; set; }

        public Person(String name, String lastname)
        {
            Name = name;
            LastName = lastname;
        }

        public abstract bool HasHisBirthday();

        public override string ToString() {
            return Name + " " + LastName;
        }
    }
}
