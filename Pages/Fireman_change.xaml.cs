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
    /// Логика взаимодействия для Fireman_change.xaml
    /// </summary>
    public partial class Fireman_change : Page
    {
        Fireman f;
        public Fireman_change(Fireman fireman)
        {
            InitializeComponent();
            this.f = fireman;
            SurnameFireman.Text = f.Surname;
            //...
        }

        private void Cancel_Fa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Fireman_list());
        }

        private void Ok_Fa_Click(object sender, RoutedEventArgs e)
        {
            using (FireDB db = new FireDB()) 
            {
                Fireman fireman = db.Firemans.Find(f.Id);
                fireman.Surname = SurnameFireman.Text;
                //...
            }
        }
    }
}
