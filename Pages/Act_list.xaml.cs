using FireDepartment.Classes;
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
    /// Логика взаимодействия для Act_list.xaml
    /// </summary>
    public partial class Act_list : Page
    {
        List<Act> source;
        public Act_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Acts.ToList();
            }
            actGrid.ItemsSource = source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void UpdatreGrid()
        {

            using (FireDB db = new FireDB())
            {
                this.source = db.Acts.ToList();
            }
            actGrid.ItemsSource = null;
            actGrid.ItemsSource = source;
        }

        private void AddActClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Act_add());
        }

        private void ActChangeClick(object sender, RoutedEventArgs e)
        {
            if (actGrid.SelectedItem != null)
            {
                Act a = (Act)actGrid.SelectedItem;
                NavigationService.Navigate(new Act_change(a));
            }
            else 
            {
                MessageBox.Show("Выберите акт");
            }

        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (actGrid.SelectedItem != null)
            {

                Act a = (Act)actGrid.SelectedItem;
                using (FireDB db = new FireDB())
                {
                    Act act = db.Acts.Find(a.Id);
                    db.Acts.Remove(act);
                    db.SaveChanges();
                    this.UpdatreGrid();
                }
                MessageBox.Show("Акт удален из базы данных");
            }
            else
            {
                MessageBox.Show("Выберите акт");
            }
        }
        
        private void ViewClick(object sender, RoutedEventArgs e)
        {
            if (actGrid.SelectedItem != null)
            {
                Act a = (Act)actGrid.SelectedItem;
                Travel t;
                using (FireDB db = new FireDB()) 
                {
                    Act act = db.Acts.Where(x => x.Id == a.Id).First();
                    t = act.Travels.First();
                   
                }
                NavigationService.Navigate(new Act_view(a, t));

            }
            else
            {
                MessageBox.Show("Выберите акт");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (queries.SelectedItem != null)
            {
                int number = int.Parse(queries.Text.Split('-')[0]);
                switch (number)
                {
                    case 1:
                        source=source.OrderByDescending(x => x.Belonging).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 2:
                        source = source.OrderByDescending(x => x.Detection).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 3:
                        source = source.OrderByDescending(x => x.Parished).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 4:
                        source = source.OrderByDescending(x => x.DamagedFloorArea).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 5:
                        source = source.OrderByDescending(x => x.ParishedChildren).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 6:
                        source = source.OrderByDescending(x => x.RescuedHumans).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    default:
                        Console.WriteLine("Что-то оченб странное произошло");
                        break;
                }
            }
            else 
            {
                MessageBox.Show("Выберите зварос из списка!");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (actGrid.SelectedItem != null)
            {
                Act a = (Act)actGrid.SelectedItem;
                Travel t;
                using (FireDB db = new FireDB()) 
                {
                    Act act = db.Acts.Where(x => x.Id == a.Id).First();
                    t=act.Travels.First();
                }
                StaticMethods.Act(a,t);

            }
            else
            {
                MessageBox.Show("Выберите акт");
            }
        }

        private void Form_Al_Click(object sender, RoutedEventArgs e)
        {
            if (ReportBox.SelectedItem != null)
            {
                int key = int.Parse(ReportBox.Text.Split('-')[0]);
                List<Act> actSource=new List<Act>();
                using (FireDB db = new FireDB())
                {
                    switch (key)
                    {
                        case 1:
                            
                            actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month == DateTime.Now.Month && x.Detection.Day == DateTime.Now.Day).ToList();
                            break;
                        case 2:
                            List<Act> tempSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month == DateTime.Now.Month).ToList();
                            actSource = tempSource.Where(x => x.Detection.Day>=DateTime.Now.Day-WeekShit()).ToList();
                            break;
                        case 3:
                            actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month == DateTime.Now.Month).ToList();
                            break;
                        case 4:
                            int y = StartOfQuarter();
                            actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month>=y).ToList();
                            break;
                        case 5:
                            if (StartOfHalf() == 1)
                            {
                                actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month >= 1).ToList();
                            }
                            else 
                            {
                                actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year && x.Detection.Month >= 7).ToList();
                            }
                            break;
                        case 6:
                            actSource = db.Acts.Where(x => x.Detection.Year == DateTime.Now.Year).ToList();
                            break;
                        default:
                            break;
                    }
                }
                if (actSource.Count != 0)
                {
                    Act ReportAct = new Act();
                    ReportAct.Parished = actSource.Select(x => x.Parished).Sum();
                    ReportAct.ParishedChildren = actSource.Select(x => x.ParishedChildren).Sum();
                    ReportAct.ParishedEmployees = actSource.Select(x => x.ParishedEmployees).Sum();
                    ReportAct.Injured = actSource.Select(x => x.Injured).Sum();
                    ReportAct.InjuredChildren = actSource.Select(x => x.InjuredChildren).Sum();
                    ReportAct.InjuredEmployees = actSource.Select(x => x.InjuredEmployees).Sum();
                    ReportAct.DestoyedBuildings = actSource.Select(x => x.DestoyedBuildings).Sum();
                    ReportAct.DamagedBuildings = actSource.Select(x => x.DamagedBuildings).Sum();
                    ReportAct.DestoyedFlats = actSource.Select(x => x.DestoyedFlats).Sum();
                    ReportAct.DamagedFlats = actSource.Select(x => x.DamagedFlats).Sum();
                    ReportAct.DestoyedFloorArea = actSource.Select(x => x.DestoyedFloorArea).Sum();
                    ReportAct.DamagedFloorArea = actSource.Select(x => x.DamagedFloorArea).Sum();
                    ReportAct.DestoyedTechnicks = actSource.Select(x => x.DestoyedTechnicks).Sum();
                    ReportAct.DamagedTechnicks = actSource.Select(x => x.DamagedTechnicks).Sum();
                    ReportAct.DestoyedAgricultural = actSource.Select(x => x.DestoyedAgricultural).Sum();
                    ReportAct.DamagedAgricultural = actSource.Select(x => x.DamagedAgricultural).Sum();
                    ReportAct.DestoyedBeasts = actSource.Select(x => x.DestoyedBeasts).Sum();
                    ReportAct.DamagedBeasts = actSource.Select(x => x.DamagedBeasts).Sum();
                    ReportAct.RescuedHumans = actSource.Select(x => x.RescuedHumans).Sum();
                    ReportAct.RescuedTechnicks = actSource.Select(x => x.RescuedTechnicks).Sum();
                    ReportAct.RescuedBeasts = actSource.Select(x => x.RescuedBeasts).Sum();
                    ReportAct.RescuedMaterialValues = actSource.Select(x => x.RescuedMaterialValues).Sum();

                    StaticMethods.Report(ReportAct, key);
                }
                else 
                {
                    MessageBox.Show("За этот период не было пожаров");
                }
                
            }
            else MessageBox.Show("Выберите тип отчета");
        }
        public static int WeekShit() 
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            switch (day)
            {
                case "Monday":
                    return 0;
                    break;
                case "Tuesday":
                    return 1;
                    break;
                case "Wednesday":
                    return 2;
                    break;
                case "Thursday":
                    return 3;
                    break;
                case "Friday":
                    return 4;
                    break;
                case "Saturday":
                    return 5;
                    break;
                case "Sunday":
                    return 6;
                    break;
                default:
                    return 0;
                    break;
            }
        }
        public static int StartOfQuarter() 
        {
            int quartet = (DateTime.Now.Month-1) / 3 + 1;
            int start = (quartet - 1) * 3 + 1;
            return start;
            // m/3+1
            //(n-1)*3+1
        }
        public static int StartOfHalf() 
        {
            return (DateTime.Now.Month - 1) / 6 + 1;
        }
    }
}
