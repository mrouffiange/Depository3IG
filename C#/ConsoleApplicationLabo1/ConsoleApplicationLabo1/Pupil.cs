using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationLabo1
{
    class Pupil : Person
    {
        public delegate string DelegatePrintActivityCompulsory(Activity activity);
        public int Grade { get; set; }
        public List<Activity> LstActivities { get; set; }
        public char[] pupilEvaluations { get; set; }

        public Pupil(String name, int age, int grade) : base(name, age)
        {
            Grade = grade;
            LstActivities = new List<Activity>();
            pupilEvaluations = new char[Parameter.MAXACTIVITIES];
        }

        public Pupil(String name, int age) : this(name, age, 1) { }

        public void AddActivity(Activity activity)
        {
            LstActivities.Add(activity);
        }

        public void AddEvaluation(String title = null, char evaluation = (char)Parameter.enumEvaluation.Satisfaisant)
        {
            for (var i = 0; i < pupilEvaluations.Length && i < LstActivities.Count(); i++)
            {
                if (LstActivities.ElementAt(i).Equals(title))
                {
                    pupilEvaluations[i] = evaluation;
                }
            }
        }

        public string PrintPupilActivityCompulsory(DelegatePrintActivityCompulsory MyPrintActivity)
        {
            int numAct = 0;
            string ch = base.ToString() + " a choisi les activités obligatoires : \n";
            foreach (Activity activity in LstActivities)
            {
                if (activity.Compulsory)
                    ch += (++numAct) + " " + MyPrintActivity(activity);
            }
            return ch;
        }

        public override String ToString()
        {
            string ch = HeaderPupil();
            ch = PrintActivitiesPupil(ch);
            return ch;
        }

        private string PrintActivitiesPupil(string ch)
        {
            int cptActivities = LstActivities.Count(); // mets le nbr d'activité
            if (cptActivities == 0)
            {
                ch += " n'a pas encore choisi d'activité\n";
            }
            else
            {
                ch += " a comme activitée(s) :\n";
                for(int i = 0; i < cptActivities; i++)
                {
                    ch += "\n" + LstActivities.ElementAt(i).Title + " : " + LstActivities.ElementAt(i).Compulsory;

                }
            }

            return ch;
        }

        private string HeaderPupil()
        {
            return base.ToString();
        }
    }
}