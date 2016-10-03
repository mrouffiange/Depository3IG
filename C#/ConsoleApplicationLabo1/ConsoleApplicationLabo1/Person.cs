using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class Person
    {
        public String Name { get; set; }

        private int age;
        public int Age
        {
            get { return age; }

            set { age = (value > 0) ? value : 1; }
        }

        public Person(String name, int age)
        {
            Name = name;
            Age = age;
        }

        public override String ToString()
        {
            return Name + " agée de " + Age + " ans\r\n";
        }
    }
}