using FireDepartment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FireDepartment.Pages
{
    /// <summary>
    /// Логика взаимодействия для Guard_change.xaml
    /// </summary>
    public partial class Guard_change : Page
    {
        Guard g;
        public Guard_change(Guard guard)
        {
            InitializeComponent();
            this.g = guard;
            string[] senior = g.Senior.Split(' ');
            SurnameSenior.Text = senior[0];
            NameSenior.Text = senior[1];
            PatronymicSenior.Text = senior[2];
        }

        private void Cancel_Ga_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Guard_list());
        }

        private void Ok_Ga_Click(object sender, RoutedEventArgs e)
        {
            string FIO = $"{SurnameSenior.Text} {NameSenior.Text} {PatronymicSenior.Text}";
            using (FireDB db = new FireDB()) 
            {
                Guard guard = db.Guards.Find(g.Id);
                guard.Senior = FIO;
                db.SaveChanges();
                NavigationService.Navigate(new Guard_list());

            }
        }
    }
}
