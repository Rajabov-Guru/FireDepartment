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
    /// Логика взаимодействия для Act_view.xaml
    /// </summary>
    public partial class Act_view : Page
    {
        Act a;
        public Act_view(Act act,Travel travel)
        {
            InitializeComponent();
            this.a= act;
            //--
            guardName.Text = $"Расчет №{travel.GuardId}";
            Address.Text = travel.Address;
            Obj_ignition.Text = travel.Obj_ignition;
            typeOfIgnition.Text = travel.Type_ignition;
            MessaggeDate.Text = travel.Indate.ToString();
            SurnameOf.Text= travel.Surname;
            NameOf.Text = travel.Name;
            PatrOf.Text = travel.Patronymic;
            TelephoneOf.Text = travel.Telephone;
            /*
            belonging.Text= a.Belonging;
            ...
            */

        }

        private void Cancel_Av_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_list());
        }
    }
}
