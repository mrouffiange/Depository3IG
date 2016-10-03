using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateContact pers1 = new PrivateContact("Rouffiange", "Martin", "081612201","mrt@hotmail.com");
            PrivateContact pers2 = new PrivateContact("Rouffiange", "Martin", "081612201", "mrt@hotmail.com", new DateTime(1994, 9, 25));

            List<ProfessionalContact> lstProfessionalContact = new List<ProfessionalContact>()
            {
                new ProfessionalContact("Rouffiange", "Martin", Parameter.CONSULTANT, "081612201", "mrt@hotmail.com"),
                new ProfessionalContact("Rouffiange2", "Martin2", Parameter.CONSULTANT, "081612201", "mrt@hotmail.com"),
                new ProfessionalContact("Rouffiange3", "Martin3", Parameter.INDEPENDANT, "081612201", "mrt@hotmail.com"),
            };

            Enterprise entSmart = new Enterprise(Parameter.ENTSMART, "City");
            Enterprise ent2 = new Enterprise("Cool", "Gembloux");

            lstProfessionalContact.ElementAt(0).EnterpriseAdd(entSmart);
            lstProfessionalContact.ElementAt(0).EnterpriseAdd(ent2);
            lstProfessionalContact.ElementAt(1).EnterpriseAdd(entSmart);

            Console.WriteLine(pers1);
            Console.WriteLine(pers2);

            var lstIndependant = from contact in lstProfessionalContact
                                 where contact.Job == Parameter.INDEPENDANT
                                 select contact;

            if (lstIndependant != null)
            {
                Console.WriteLine(lstIndependant.Count());
            }

            var lstConsultantForEntSmart = lstProfessionalContact.Where(contactFound => contactFound.Job == Parameter.CONSULTANT && contactFound.LstEntreprises.Exists(enterpriseFound => enterpriseFound.Name == Parameter.ENTSMART));

            if (lstConsultantForEntSmart != null)
            {
                foreach(var contact in lstConsultantForEntSmart)
                {
                    Console.WriteLine(contact);
                }
            }

            Car voiture1 = new Car("1-FOH-947");
            ContactCar contactCar = new ContactCar(lstProfessionalContact.ElementAt(0), voiture1);

            Console.WriteLine(contactCar);

            Console.ReadLine();
        }
    }
}
