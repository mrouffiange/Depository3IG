using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Pupil eleve = new Pupil("Schepmans", 22);
            Activity cours1 = new Activity("Math", true);
            Activity cours2 = new Activity("C#", true);
            Activity cours3 = new Activity("Ndls", false);

            eleve.AddActivity(cours1);
            eleve.AddActivity(cours2);
            eleve.AddActivity(cours3);

            eleve.AddEvaluation("Math");
            eleve.AddEvaluation(evaluation: 'T', title: "C#");
            eleve.AddEvaluation("Ndls", 'R');

            System.Console.Write(eleve);

            List<Pupil> lstPupils = new List<Pupil>()
            {
                new Pupil("Guebel", 10, 5),
                new Pupil("Rouffi", 7),
                new Pupil("Michou", 10),
                new Pupil("Delcourt", 8, 3),
                new Pupil("Herou", 4),
            };


            //var pupilGrade1Plus6 = from pupil in lstPupils
            //                       where pupil.Age > 6 && pupil.Grade == 1
            //                       select pupil;

            var pupilGrade1Plus6 = lstPupils.Where(pupilFound => pupilFound.Age > 6 && pupilFound.Grade == 1);

            if (pupilGrade1Plus6 != null)
            {
                System.Console.WriteLine("\r\nDebut pupil plus de 6 ans et encore grade 1");
                foreach (var pupil in pupilGrade1Plus6)
                {
                    System.Console.Write(pupil);

                }
                System.Console.WriteLine("\r\nFin pupil plus de 6 ans et encore grade 1");
            }

            List<Person> listPersons = new List<Person>()
            {
                new Person("Demoumou", 26),
                new Person("Lagneaux", 23),
                new Person("BBBB", 5),
                new Person("CCCC", 2),
                new Person("DDDD", 12),
            };

            var listFusion = listPersons.Union(lstPupils);

            System.Console.WriteLine("\r\nDebut de la liste fusionne");
            foreach (var person in listFusion)
            {
                System.Console.Write(person);
            }
            System.Console.WriteLine("\r\nFin de la liste fusionne");

            List<Pupil> listPupilsDuplicated = new List<Pupil>()
            {
                new Pupil("Flo", 10, 5),
                new Pupil("Marti", 7),
                new Pupil("Lolo", 9),
                new Pupil("Lolo", 9),
                new Pupil("Nico", 4),
                new Pupil("Flo", 10, 5),
            };

            IEnumerable<Pupil> listPupilsNoDuplicated = listPupilsDuplicated.Distinct<Pupil>(new PersonComparer());

            System.Console.WriteLine("\r\nDebut de la liste dupliquée");
            var nbPupil = 0;
            foreach (var pupil in listPupilsNoDuplicated)
            {
                nbPupil++;
                System.Console.Write(pupil);
            }
            System.Console.Write(nbPupil);
            System.Console.WriteLine("\r\nFin de la liste dupliquée");

            /*System.Console.WriteLine(eleve.PrintPupilActivityCompulsory(
            delegate (Activity activity)
            {
            return activity.Title + "\n";
            }));*/

            //System.Console.WriteLine(eleve.PrintPupilActivityCompulsory(StaticPrintActivity));

            /*PrintActivityDelegate p = new PrintActivityDelegate();
            System.Console.WriteLine(eleve.PrintPupilActivityCompulsory(p.PrintActivity));*/

            System.Console.WriteLine(eleve.PrintPupilActivityCompulsory(activity => activity.Title + Environment.NewLine));



            Console.Read();
        }

        private static string StaticPrintActivity(Activity activity)
        {
            return activity.Title + "\n";
        }
    }
}