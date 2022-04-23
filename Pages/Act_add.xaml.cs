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
        // Ещё костыли
        List<string> Belongings = new List<string>() {"Принадлежность1", "Принадлежность2", "Принадлежность3", "Принадлежность4" };
        List<string> TrueFalse = new List<string>() { "ДА", "НЕТ" };
        public Act_add()
        {
            InitializeComponent();
            Belonging.ItemsSource = Belongings;
            WaterSupply.ItemsSource = TrueFalse;
            AvailabilityOfFireAutomatic.ItemsSource = TrueFalse;
        }

        private void Ok_Ad_Click(object sender, RoutedEventArgs e)
        {
            
            if (Belonging.SelectedItem != null &&
                Situation.Text != "" &&
                FireEquipment.Text != "" &&
                WaterSupply.SelectedItem != null &&
                AvailabilityOfFireAutomatic.SelectedItem != null &&
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
                var data1 = DateTime.Parse(Localization.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                var data2 = DateTime.Parse(Liquidation.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                if (data1 > DateTime.Parse("01.01.2022") && data1 < DateTime.Parse("31.12.2032") &&
                    data2 > DateTime.Parse("01.01.2022") && data2 < DateTime.Parse("31.12.2032"))
                {
                    using (FireDB db = new FireDB())
                    {
                        Act act = new Act();
                        act.Belonging = Belonging.Text;
                        act.Detection = data1;// Костыль
                        act.Localization = data1;
                        act.Liquidation = data2;
                        act.Situation = Situation.Text;
                        act.FireEquipment = FireEquipment.Text;
                        act.WaterSupply = bool.Parse(WaterSupply.Text);
                        act.AvailabilityOfFireAutomatic = bool.Parse(AvailabilityOfFireAutomatic.Text);
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
                        db.Acts.Add(act);
                        db.SaveChanges();
                        NavigationService.Navigate(new Act_list());
                    }
                }
                else MessageBox.Show("Введите все даты в промежутке (2022-2032 год)");
                
            }
            else MessageBox.Show("Введите данные");
        }

        private void Cancel_Ad_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_list());
        }
    }
}
