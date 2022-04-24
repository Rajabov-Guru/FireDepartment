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
    /// Логика взаимодействия для Travel_change.xaml
    /// </summary>
    public partial class Travel_change : Page
    {
        Travel t;
        public Travel_change(Travel travel)
        {
            InitializeComponent();
            this.t = travel;

            Name_division.Text = t.Name_division;
            Type_ignition.Text = t.Type_ignition;
            //...
        }

        private void Cancel_Ta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Travel_list());
        }

        private void Ok_Ta_Click(object sender, RoutedEventArgs e)
        {
            using (FireDB db = new FireDB()) 
            {
                Travel travel = db.Travels.Find(t.Id);
                travel.Name_division = Name_division.Text;
                //дописать
                db.SaveChanges();
                NavigationService.Navigate(new Travel_list());
            }
        }
    }
}
