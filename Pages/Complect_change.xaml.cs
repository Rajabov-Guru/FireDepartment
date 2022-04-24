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
    /// Логика взаимодействия для Complect_change.xaml
    /// </summary>
    public partial class Complect_change : Page
    {
        Complect c;
        public Complect_change(Complect complect)
        {
            InitializeComponent();
            this.c = complect;
            EquipmentList.Text = c.EquipmentList;
        }

        private void Ok_Ca_Click(object sender, RoutedEventArgs e)
        {
            using (FireDB db = new FireDB()) 
            {
                Complect complect = db.Complects.Find(c.Id);
                complect.EquipmentList = EquipmentList.Text;
                db.SaveChanges();
                NavigationService.Navigate(new Complect_list());
            }
        }

        private void Cancel_Ca_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Complect_list());
        }
    }
}
