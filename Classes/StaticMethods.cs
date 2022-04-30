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
        public static void Travel(Travel t) // путевка
        {
            try
            {
                WordDocument w = new WordDocument();
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\Travel4.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory + "docs\\Путевка (" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";

                w.AddDoc(name1, newName1);
                w.OpenDoc(newName1);
                w.FillTravel(newName1, t);
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
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\ReportInPeriod.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory + "docs\\" + NameOfReportFile(key); 

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
        public static string NameOfReportFile(int key) 
        {
            switch (key)
            {
                case 1:
                    return "Отчет за день(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                case 2:
                    return "Отчет за неделю(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                case 3:
                    return "Отчет за месяц(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                case 4:
                    return "Отчет за квартал(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                case 5:
                    return "Отчет за пол года(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                case 6:
                    return "Отчет за год(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
                default:
                    return "Отчет за день(" + DateTime.Now.ToString("dd.MM.yyyy_HH_mm") + ").docx";
                    break;
            }
        }
    }
}
