using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class Car
    {
        public String NumPlaque { get; set; }

        public Car(String numPlaque)
        {
            NumPlaque = numPlaque;
        }

        public override string ToString()
        {
            return NumPlaque;
        }
    }
}
