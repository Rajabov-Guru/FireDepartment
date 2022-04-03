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
        public static void Report()
        {
            try
            {
                Act a = null;
                using (FireDB db = new FireDB())
                {
                    a = db.Acts.First();
                }
                WordDocument w = new WordDocument();
                string name1 = AppDomain.CurrentDomain.BaseDirectory + "Shablons\\Akt.docx";
                string newName1 = AppDomain.CurrentDomain.BaseDirectory+"docs\\Акт о пожаре (" + DateTime.Now.ToString("dd.MM.yyyy") + ").docx" ;
          
                w.AddDoc(name1, newName1);
                w.OpenDoc(newName1);
                w.FillConsent(newName1, a);
                w.CloseDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
