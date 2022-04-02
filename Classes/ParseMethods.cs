using FireDepartment.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Classes
{
    static class ParseMethods
    {
        static Random rand = new Random();
        //список строк файла
        public static string[] ParseFile(string path) 
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(path, Encoding.Default)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(line);
                }
            }
            return result.ToArray();
        }

        //список свойств строки
        public static string[] ParseLine(string line) 
        {
            return line.Trim().Split(';');
        }

        //генератор ФИО
        public static string GenerateFIO()
        {
            string[] surnames = ParseFile("data/surnames.txt");
            string[] names = ParseFile("data/names.txt");
            string[] patr = ParseFile("data/patronimycs.txt");
            string result = "";

            int ind1 = rand.Next(0, surnames.Length);
            int ind2 = rand.Next(0, names.Length);
            int ind3 = rand.Next(0, patr.Length);
            result += $"{surnames[ind1]} {names[ind2]} {patr[ind3]}";
            return result;
        }

        //добавление комлектов
        public static void AddComplects() 
        {
            string[] lines = ParseFile("data/complects.txt");
            foreach (string line in lines)
            {
                
                using (FireDB db = new FireDB()) 
                {
                    Complect c = new Complect();
                    c.EquipmentList = line;
                    db.Complects.Add(c);
                    db.SaveChanges();
                }
            }
        }

        //добавление расчётов
        public static void AddGuards() 
        {
            string[] lines = ParseFile("data/guards.txt");
            int comId = 1;
            foreach (string line in lines)
            {
                string senior = string.Join(" ",line.Split(';'));
                
                using (FireDB db = new FireDB())
                {
                    Guard g = new Guard();
                    g.ComplectId = comId;
                    comId++;
                    g.Senior = senior;
                    db.Guards.Add(g);
                    db.SaveChanges();
                }
            }
        }


        //добавление бойцов
        public static void AddFiremen() 
        {
            string[] lines = ParseFile("data/firemen.txt");
            for (int id = 1; id <= 10; id++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Fireman f = new Fireman();
                    f.GuardId = id;
                    f.Date_birth= DateTime.ParseExact(lines[i], "dd.MM.yyyy", null);
                    string[] fio = GenerateFIO().Split(' ');
                    f.Surname = fio[0];
                    f.Name = fio[1];
                    f.Patronymic = fio[2];
                    using (FireDB db = new FireDB())
                    {
                        db.Firemans.Add(f);
                        db.SaveChanges();
                    }

                }
                
            }
        }


        //добавление актов
        public static void AddActs() 
        {
            string[] lines = ParseFile("data/acts.txt");
            foreach (string line in lines)
            {
                string[] props = ParseLine(line);
                using (FireDB db = new FireDB())
                {
                    Act a = new Act();
                    a.Cause=props[0];

                    a.RescuedHumans = int.Parse(props[1]);
                    a.RescuedTechnicks = int.Parse(props[2]);
                    a.RescuedBeasts = int.Parse(props[3]);
                    a.RescuedMaterialValues = double.Parse(props[4].Replace(".",","));

                    a.Terms = props[5];

                    a.DestoyedBuildings = int.Parse(props[6]);
                    a.DestoyedFlats = int.Parse(props[7]);
                    a.DestoyedAgricultural = int.Parse(props[8]);
                    a.DestoyedBeasts = int.Parse(props[9]);
                    a.DestoyedTechnicks = int.Parse(props[10]);
                    a.DestoyedFloorArea = int.Parse(props[11]);

                    a.DamagedBuildings = int.Parse(props[12]);
                    a.DamagedFlats = int.Parse(props[13]);
                    a.DamagedFloorArea = int.Parse(props[14]);
                    a.DamagedTechnicks = int.Parse(props[15]);
                    a.DamagedAgricultural = int.Parse(props[16]);
                    a.DamagedBeasts = int.Parse(props[17]);

                    a.InjuredEmployees = int.Parse(props[18]);
                    a.InjuredChildren = int.Parse(props[19]);
                    a.Injured = int.Parse(props[20]);

                    a.ParishedEmployees = int.Parse(props[21]);
                    a.ParishedChildren = int.Parse(props[22]);
                    a.Parished = int.Parse(props[23]);

                    a.WaterSupply = props[24] == "Да";
                    a.FireEquipment = props[25];
                    a.AvailabilityOfFireAutomatic = props[26] == "Да";
                    a.Situation = props[27];

                    a.Liquidation= DateTime.ParseExact(props[28], "dd.MM.yyyy HH:mm", null);
                    a.Localization= DateTime.ParseExact(props[29], "dd.MM.yyyy HH:mm", null);
                    a.Detection= DateTime.ParseExact(props[30], "dd.MM.yyyy HH:mm", null);

                    a.Belonging = props[31];
                    db.Acts.Add(a);
                    db.SaveChanges();
                }
            }

        }

        //добавление путевок
        public static void AddTravels() 
        {
            string[] lines = ParseFile("data/travels.txt");
            int dopId = 1;
            foreach (string line in lines)
            {
                string[] props = ParseLine(line);
                using (FireDB db = new FireDB())
                {
                    Travel t = new Travel();
                    t.GuardId = dopId;
                    t.ActId = dopId;
                    t.Name = props[0];
                    t.Surname = props[1];
                    t.Patronymic = props[2];
                    t.Address = props[3];
                    t.Telephone = props[4];
                    t.Indate= DateTime.ParseExact(props[5], "HH:mm dd.MM.yyyy", null);
                    t.Obj_ignition = props[6];
                    t.Name_division = props[7];
                    t.Type_ignition = "Пожары твердых горючих веществ и материалов";
                    db.Travels.Add(t);
                    try
                    {

                        db.SaveChanges();

                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                        {
                            Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                            
                            foreach (DbValidationError err in validationError.ValidationErrors)
                            {
                                Console.WriteLine(err.ErrorMessage + "");
                            }
                        }
                    }
                }
                dopId++;
            }
        }

        public static void FillDB() 
        {
            AddComplects();
            AddGuards();
            AddFiremen();
            AddActs();
            AddTravels();
        }






    }
}
