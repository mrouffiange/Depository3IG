using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    public class Activity
    {
        public String Title { get; set; }

        public Boolean Compulsory { get; set; }

        public Activity(String title, Boolean compulsory)
        {
            Title = title;
            Compulsory = compulsory;
        }

        public override string ToString()
        {
            return Title + (Compulsory ? " obligatoire." : ".");
        }
    }
}
