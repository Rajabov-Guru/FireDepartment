using FireDepartment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FireDepartment.Classes
{
    static class StaticMethods
    {
        public static void Act(Act a,Travel t) // Акт о пожаре
        {
            try
            {
                WordDocument w = new WordDocument();
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\Act.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory + "docs\\Акт о пожаре (" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";

                w.AddDoc(name1, newName1);
                w.OpenDoc(newName1);
                w.FillAct(newName1, a,t);
                w.CloseDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void Travel() // путевка
        {
            try
            {
                string fioDisp; // диспетчер
                Travel a = null;
                Guard g = null;
                using (FireDB db = new FireDB())
                {
                    a = db.Travels.First();//
                    g = db.Guards.First();//что цеплять
                }
                WordDocument w = new WordDocument();
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\Travel.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory + "docs\\Путевка (" + DateTime.Now.ToString("dd.MM.yyyy") + ").docx";

                w.AddDoc(name1, newName1);
                w.OpenDoc(newName1);
                w.FillTravel(newName1, a, g);
                w.CloseDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void Report(Act a,int key)
        {
            try
            {
                WordDocument w = new WordDocument();
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\Report.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory + "docs\\Отчет (" + DateTime.Now.ToString("dd.MM.yyyy") + ").docx";

                w.AddDoc(name1, newName1);
                w.OpenDoc(newName1);
                switch (key)
                {
                    case 1:
                        w.FillReportDay(newName1,a);
                        break;
                    case 2:
                        w.FillReportWeek(newName1, a);
                        break;
                    case 3:
                        w.FillReportMonth(newName1, a);
                        break;
                    case 4:
                        w.FillReportQuarter(newName1, a);
                        break;
                    case 5:
                        w.FillReportHalfYear(newName1, a);
                        break;
                    case 6:
                        w.FillReportYear(newName1, a);
                        break;
                    default:
                        break;
                }
                w.CloseDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
