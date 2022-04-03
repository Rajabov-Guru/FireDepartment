using FireDepartment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireDepartment.Classes
{
    static class Query
    {
        //1.	Данные по участию расчета в пожаре
        public static bool MainQuery1(Guard g, Act a)
        {
            using (FireDB db = new FireDB()) 
            {
                int count = a.Travels.Where(x => x.GuardId == g.Id).Count();
                return count > 0;
            }
        }

        //2.	Данные по участию в пожаре бойца
        public static bool MainQuery2(Fireman f, Act a)
        {
            using (FireDB db = new FireDB())
            {
                int count=f.Guard.Travels.Where(x => x.ActId == a.Id).Count();
                return count > 0;
            }
        }

        //4.	Сколько погибло людей за период 
        public static int MainQuery3(DateTime BegDate, DateTime EndDate)
        {
            using (FireDB db = new FireDB())
            {
                var comps = db.Acts.SqlQuery("SELECT * FROM Acts").Where(x => x.Liquidation > BegDate).Where(x => x.Liquidation < EndDate).ToList();
                return comps.Select(c => c.Parished).Sum();
            }
        }

        //9.	Данные о поврежденной поэтажной площади за определенный период
        public static int MainQuery9(DateTime BegDate, DateTime EndDate)
        {
            using (FireDB db = new FireDB())
            {
                var comps = db.Acts.SqlQuery("SELECT * FROM Acts").Where(x => x.Liquidation > BegDate).Where(x => x.Liquidation < EndDate).ToList();
                return comps.Select(c => c.DamagedFloorArea).Sum();
            }
        }

        //10.	Данные о том сколько работников ПО погибло и получило травмы за период
        public static int MainQuery10(DateTime BegDate, DateTime EndDate)
        {
            using (FireDB db = new FireDB())
            {

                var comps = db.Acts.SqlQuery("SELECT * FROM Acts").Where(x => x.Liquidation > BegDate).Where(x => x.Liquidation < EndDate).ToList();
                int[] mas = new int[2];
                mas[0] = comps.Select(c => c.InjuredEmployees).Sum();
                mas[1] = comps.Select(c => c.ParishedEmployees).Sum();
                return mas[0] + mas[1];
            }
        }
    }
}
