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
    /// Логика взаимодействия для Act_add.xaml
    /// </summary>
    public partial class Act_add : Page
    {
        List<string> Belongings = new List<string>() {"Принадлежность1", "Принадлежность2", "Принадлежность3", "Принадлежность4" };
        List<string> TrueFalse = new List<string>() { "ДА", "НЕТ" };
        public Act_add()
        {
            InitializeComponent();
            belongings.ItemsSource = Belongings;
            waterShit.ItemsSource = TrueFalse;
            FireAutomatization.ItemsSource = TrueFalse;
        }

        private void Ok_Ad_Click(object sender, RoutedEventArgs e)
        {
            //проверки
            using (FireDB db = new FireDB()) 
            {
                Act a = new Act();
                /*a.somthing=Somthing.Text;
                ....
                */
                db.Acts.Add(a);
                db.SaveChanges();
                NavigationService.Navigate(new Act_list());
            }
        }

        private void Cancel_Ad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_list());
        }
    }
}
