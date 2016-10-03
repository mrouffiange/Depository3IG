using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Contact
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Mail { get; set; }

        public Contact(string firstName, string lastName, string mail)
        {
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
        }


    }
}
