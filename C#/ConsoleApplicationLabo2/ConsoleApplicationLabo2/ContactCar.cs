using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo2
{
    class ContactCar
    {
        public Person Person { get; set; }
        public Car Car { get; set; }

        public ContactCar(Person person, Car car)
        {
            Person = person;
            Car = car;
        }

        public void DynamicPrint(dynamic objet)
        {
            System.Console.WriteLine(objet.Print() + " voiture : " + Car.ToString());
        }
    }
}
