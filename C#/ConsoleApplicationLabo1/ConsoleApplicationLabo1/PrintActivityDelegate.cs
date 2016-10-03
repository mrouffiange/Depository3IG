using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    public class PrintActivityDelegate
    {
        public PrintActivityDelegate()
        {

        }

        public string PrintActivity(Activity activity)
        {
            return activity.Title + "\n";
        }
    }
}
