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
            if (belongings.SelectedItem != null &&
                Situation.Text != "" &&
                FireEquipment.Text != "" &&
                waterShit.SelectedItem != null &&
                FireAutomatization.SelectedItem != null &&
                Parished.Text != "" &&
                ParishedChildren.Text != "" &&
                ParishedEmployees.Text != "" &&
                Injured.Text != "" &&
                InjuredChildren.Text != "" &&
                InjuredEmployees.Text != "" &&
                DestoyedBuildings.Text != "" &&
                DestoyedFlats.Text != "" &&
                DestoyedFloorArea.Text != "" &&
                DestoyedTechnicks.Text != "" &&
                DestoyedAgricultural.Text != "" &&
                DestoyedBeasts.Text != "" &&
                DamagedBuildings.Text != "" &&
                DamagedFlats.Text != "" &&
                DamagedFloorArea.Text != "" &&
                DamagedTechnicks.Text != "" &&
                DamagedAgricultural.Text != "" &&
                DamagedBeasts.Text != "" &&
                Terms.Text != "" &&
                Cause.Text != "" &&
                RescuedHumans.Text != "" &&
                RescuedTechnicks.Text != "" &&
                RescuedBeasts.Text != "" &&
                RescuedMaterialValues.Text != ""
                ) // Проверка на целостность введенных данных
            {
                var data1 = DateTime.Parse(localization.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                var data2 = DateTime.Parse(Liquidation.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                if (data1 > DateTime.Parse("01.01.2022") && data1 < DateTime.Parse("31.12.2032") &&
                    data2 > DateTime.Parse("01.01.2022") && data2 < DateTime.Parse("31.12.2032"))
                {
                    using (FireDB db = new FireDB())
                    {
                        Act act = db.Acts.Find(a.Id);
                        act.Belonging = belongings.Text;
                        act.Detection = data1;// Костыль
                        act.Localization = data1;
                        act.Liquidation = data2;
                        act.Situation = Situation.Text;
                        act.FireEquipment = FireEquipment.Text;
                        act.WaterSupply = bool.Parse(waterShit.Text);
                        act.AvailabilityOfFireAutomatic = bool.Parse(FireAutomatization.Text);
                        act.Parished = int.Parse(Parished.Text);
                        act.ParishedChildren = int.Parse(ParishedChildren.Text);
                        act.ParishedEmployees = int.Parse(ParishedEmployees.Text);
                        act.Injured = int.Parse(Injured.Text);
                        act.InjuredChildren = int.Parse(InjuredChildren.Text);
                        act.InjuredEmployees = int.Parse(InjuredEmployees.Text);
                        act.DestoyedBuildings = int.Parse(DestoyedBuildings.Text);
                        act.DestoyedFlats = int.Parse(DestoyedFlats.Text);
                        act.DestoyedFloorArea = int.Parse(DestoyedFloorArea.Text);
                        act.DestoyedTechnicks = int.Parse(DestoyedTechnicks.Text);
                        act.DestoyedAgricultural = int.Parse(DestoyedAgricultural.Text);
                        act.DestoyedBeasts = int.Parse(DestoyedBeasts.Text);
                        act.DamagedBuildings = int.Parse(DamagedBuildings.Text);
                        act.DamagedFlats = int.Parse(DamagedFlats.Text);
                        act.DamagedFloorArea = int.Parse(DamagedFloorArea.Text);
                        act.DamagedTechnicks = int.Parse(DamagedTechnicks.Text);
                        act.DamagedAgricultural = int.Parse(DamagedAgricultural.Text);
                        act.DamagedBeasts = int.Parse(DamagedBeasts.Text);
                        act.Terms = Terms.Text;
                        act.Cause = Cause.Text;
                        act.RescuedHumans = int.Parse(RescuedHumans.Text);
                        act.RescuedTechnicks = int.Parse(RescuedTechnicks.Text);
                        act.RescuedBeasts = int.Parse(RescuedBeasts.Text);
                        act.RescuedMaterialValues = int.Parse(RescuedMaterialValues.Text);
                        db.SaveChanges();
                        NavigationService.Navigate(new Act_list());
                    }
                }
                else MessageBox.Show("Введите все даты в промежутке (2022-2032 год)");

            }
            else MessageBox.Show("Введите данные");
            
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
