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
    /// Логика взаимодействия для Act_change.xaml
    /// </summary>
    public partial class Act_change : Page
    {
        List<string> Belongings = new List<string>() { "Принадлежность1", "Принадлежность2", "Принадлежность3", "Принадлежность4" };
        List<string> TrueFalse = new List<string>() { "ДА", "НЕТ" };
        Act a;
        public Act_change(Act act)
        {
            InitializeComponent();
            this.a = act;
            belongings.ItemsSource = Belongings;
            if (Belongings.Contains(a.Belonging)) 
            {
                belongings.SelectedIndex = Belongings.IndexOf(a.Belonging);
            }
            waterShit.ItemsSource = TrueFalse;
            waterShit.SelectedIndex = a.WaterSupply ? 0 : 1;
            FireAutomatization.ItemsSource = TrueFalse;
            FireAutomatization.SelectedIndex = a.AvailabilityOfFireAutomatic ? 0 : 1;
            localization.SelectedDate = a.Localization;
            Liquidation.SelectedDate = a.Liquidation;
            Situation.Text = a.Situation;
            FireEquipment.Text = a.FireEquipment;
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

        private void Ok_Ad_Click(object sender, RoutedEventArgs e)
        {
            //проверки
            using (FireDB db = new FireDB())
            {
                Act act = db.Acts.Find(a.Id);
                /*act.somthing=Somthing.Text;
                ....
                */
                db.SaveChanges();
                NavigationService.Navigate(new Act_list());
            }
        }

        private void Sel_change(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Cancel_Ad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_list());
        }
    }
}
