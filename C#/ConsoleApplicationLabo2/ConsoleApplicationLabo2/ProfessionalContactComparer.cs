using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class ProfessionalContactComparer : IEqualityComparer<ProfessionalContact>
    {
        public bool Equals(ProfessionalContact x, ProfessionalContact y)
        {
            if (GetHashCode(x) == GetHashCode(y))
                return true;
            else
                return false;
        }

        public int GetHashCode(ProfessionalContact obj)
        {
            return obj.Job.GetHashCode();
        }
    }
}
