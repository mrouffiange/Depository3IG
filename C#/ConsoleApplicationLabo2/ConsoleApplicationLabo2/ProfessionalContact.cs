using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    public class ProfessionalContact : Person
    {
        public String Job { get; set; }
        public String Phone { get; set; }
        public String Mail { get; set; }
        private List<Enterprise> lstEntreprises = new List<Enterprise>();
        public List<Enterprise> LstEntreprises { get; set; }

        public ProfessionalContact(String name, String lastname, String job, String phone, String mail) : base(name, lastname)
        {
            Job = job;
            Phone = phone;
            Mail = mail;
        }

        public override bool HasHisBirthday()
        {
            return false;
        }

        public void EnterpriseAdd(Enterprise enterprise)
        {
            lstEntreprises.Add(enterprise);
        }

        public string Print()
        {
            return " est un contact prefessionel";
        }

        public override string ToString()
        {
            String ch = base.ToString() + " (" + Phone + ")";
            ch += "\n" + Job;
            ch += "\n" + Mail;
            return ch;
        }
    }
}
