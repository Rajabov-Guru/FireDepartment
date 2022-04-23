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
            this.a = act;
            guardName.Text = $"Расчет №{travel.GuardId}";
            Address.Text = travel.Address;
            Obj_ignition.Text = travel.Obj_ignition;
            typeOfIgnition.Text = travel.Type_ignition;
            MessaggeDate.Text = travel.Indate.ToString();
            SurnameOf.Text= travel.Surname;
            NameOf.Text = travel.Name;
            PatrOf.Text = travel.Patronymic;
            TelephoneOf.Text = travel.Telephone;
            belonging.Text = a.Belonging;
            localization.Text = a.Localization.ToString();
            liquidation.Text = a.Liquidation.ToString();
            situation.Text = a.Situation;
            FireEquipment.Text = a.FireEquipment;
            waterSupply.Text = a.WaterSupply ? "ДА" : "НЕТ";
            AvailabilityOfFireAutomatic.Text = a.AvailabilityOfFireAutomatic ? "ДА" : "НЕТ";
            Parished.Text = a.Parished.ToString();
            ParishedChildren.Text = a.ParishedChildren.ToString();
            ParishedEmployees.Text = a.ParishedEmployees.ToString();
            Injured.Text = a.Injured.ToString();
            InjuredChildren.Text = a.InjuredChildren.ToString();
            InjuredEmployees.Text = a.InjuredEmployees.ToString();
            DestoyedBuildings.Text = a.DestoyedBuildings.ToString();
            DestoyedFlats.Text = a.DestoyedFlats.ToString();
            DestoyedFloorArea.Text = a.DestoyedFloorArea.ToString();
            DestoyedTechnicks.Text = a.DestoyedTechnicks.ToString();
            DestoyedAgricultural.Text = a.DestoyedAgricultural.ToString();
            DestoyedBeasts.Text = a.DestoyedBeasts.ToString();
            DamagedBuildings.Text = a.DamagedBuildings.ToString();
            DamagedFlats.Text = a.DamagedFlats.ToString();
            DamagedFloorArea.Text = a.DamagedFloorArea.ToString();
            DamagedTechnicks.Text = a.DamagedTechnicks.ToString();
            DamagedAgricultural.Text = a.DamagedAgricultural.ToString();
            DamagedBeasts.Text = a.DamagedBeasts.ToString();
            Terms.Text = a.Terms.ToString();
            Cause.Text = a.Cause.ToString();
            RescuedHumans.Text = a.RescuedHumans.ToString();
            RescuedTechnicks.Text = a.RescuedTechnicks.ToString();
            RescuedBeasts.Text = a.RescuedBeasts.ToString();
            RescuedMaterialValues.Text = a.RescuedMaterialValues.ToString();
        }

        private void Cancel_Av_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_list());
        }
    }
}
