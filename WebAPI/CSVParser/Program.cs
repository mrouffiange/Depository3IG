using CsvHelper;
using Labo3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser
{
    class Program
    {
        private static int MAX_RECORDS = 10;
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(@"C:\Users\Martin\Desktop\3IG\NamCSVUTF.csv"))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                using (ApplicationContext context = new ApplicationContext())
                {
                    int nbRecords = 0;
                    while (csv.Read() && nbRecords < MAX_RECORDS)
                    {
                        Cryptography crypto = new Cryptography();

                        string gid = csv.GetField<string>(0);
                        //System.Console.WriteLine(gid);
                        string rue = csv.GetField<string>(1);
                        string numero = csv.GetField<string>(2);
                        string cp = csv.GetField<string>(3);
                        string localite = csv.GetField<string>(4);
                        string tel = csv.GetField<string>(5);
                        string email = csv.GetField<string>(6);
                        string nom = csv.GetField<string>(7);
                        if (rue.Length > 0 && localite.Length > 0 && email.Length > 0 && nom.Length > 0 && tel.Length > 0)
                        {
                            nom = nom.ToLower();
                            nom = nom.Substring(0, 1).ToUpper() + nom.Substring(1, nom.Length-1);
                            String login = "login" + gid;
                            String password = "password";
                           // password = crypto.GetMd5Hash(password);

                            String description = "Description de " + nom;
                            String adress = rue + " " + numero + ", " + cp + " " + localite;
                            context.Database.ExecuteSqlCommand("Insert into Users (Login, Password, PromoterName, Address, Email, Description, PhoneNumber, Grade, Discriminator, Type_Name) Values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9})", login, password, nom, adress, email, description, tel, 0, "UserPromoter", "Shopping");
                            nbRecords++;
                            System.Console.Write(".");
                        }
                    }
                }
            }
        }
    }
}
