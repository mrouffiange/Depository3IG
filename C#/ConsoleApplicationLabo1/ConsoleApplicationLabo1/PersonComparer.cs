using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (GetHashCode(x) == GetHashCode(y))
                return true;
            else
                return false;
        }

        public int GetHashCode(Person obj)
        {
            return obj.Name.GetHashCode() ^ obj.Age;
        }
    }
}