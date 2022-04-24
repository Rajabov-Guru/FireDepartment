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
using FireDepartment.Model;

namespace FireDepartment.Pages
{
    /// <summary>
    /// Логика взаимодействия для Guard_add.xaml
    /// </summary>
    public partial class Guard_add : Page
    {
        public Guard_add()
        {
            InitializeComponent();
        }

        private void Ok_Ga_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameSenior.Text == "" | SurnameSenior.Text.Length > 30)
            {
                MessageBox.Show("Фамилия введена некорректно");
                return;
            }

            if (NameSenior.Text == "" | NameSenior.Text.Length > 30)
            {
                MessageBox.Show("Имя введено некорректно");
                return;
            }
            
            if (PatronymicSenior.Text == "" | PatronymicSenior.Text.Length > 30)
            {
                MessageBox.Show("Отчество введено некорректно");
                return;
            }

            string senior = SurnameSenior.Text + " " + NameSenior.Text + " " + PatronymicSenior.Text;
            var rnd = new Random();

            using (FireDB db = new FireDB())
            {
                Guard add = new Guard();
                
                add.Senior = senior;
                add.ComplectId = rnd.Next(1, 11);
                db.Guards.Add(add);
                db.SaveChanges();
                NavigationService.Navigate(new Guard_list());
            }




        }

        private void Cancel_Ga_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Guard_list());
        }
    }
}
