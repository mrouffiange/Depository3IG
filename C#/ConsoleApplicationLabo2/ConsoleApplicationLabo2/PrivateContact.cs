using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    public class PrivateContact : Person
    {
        public String NumTel { get; set; }
        public String Mail { get; set; }
        public DateTime Birthday { get; set; }

        public PrivateContact(String name, String lastname, String numtel, String mail) : base(name, lastname)
        {
            NumTel = numtel;
            Mail = mail;
            Birthday = new DateTime();
        }

        public PrivateContact(String name, String lastname, String numtel, String mail, DateTime birthday) : this(name, lastname, numtel, mail)
        {
            Birthday = birthday;
        }

        public override bool HasHisBirthday()
        {
            return (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day == Birthday.Day);
        }

        public string Print()
        {
            return " est un contact privé";
        }

        public override string ToString()
        {
            String ch = base.ToString() + ", " + Birthday; 
            ch += (HasHisBirthday()) ?  ", bon anniversaire !": "";
            return ch;
        }
    }
}
