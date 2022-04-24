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
    /// Логика взаимодействия для Travel_list.xaml
    /// </summary>
    public partial class Travel_list : Page
    {
        List<Travel> source;
        public Travel_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Travels.ToList();
            }
            travelGrid.ItemsSource = source;
        }
        public void UpdatreGrid()
        {
            using (FireDB db = new FireDB())
            {
                this.source = db.Travels.ToList();
            }
            travelGrid.ItemsSource = null;
            travelGrid.ItemsSource = source;
        }
        private void Add_Ta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Tl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_Tl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddTravelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Travel_add());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (travelGrid.SelectedItem != null)
            {
                Travel t = (Travel)travelGrid.SelectedItem;
                StaticMethods.Travel(t);
            }
            else 
            {
                MessageBox.Show("Выберите путевку");
            }
        }

        private void ChangeTravel(object sender, RoutedEventArgs e)
        {
            if (travelGrid.SelectedItem != null)
            {
                Travel t = (Travel)travelGrid.SelectedItem;
                NavigationService.Navigate(new Travel_change(t));
            }
            else
            {
                MessageBox.Show("Выберите путевку");
            }
        }

        private void TravelDelete(object sender, RoutedEventArgs e)
        {
            if (travelGrid.SelectedItem != null)
            {
                Travel t = (Travel)travelGrid.SelectedItem;
                using (FireDB db = new FireDB())
                {
                    Travel travel = db.Travels.Find(t.Id);
                    db.Travels.Remove(travel);
                    db.SaveChanges();
                    this.UpdatreGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите комплект");
            }
        }

        private void view(object sender, RoutedEventArgs e)
        {
            if (travelGrid.SelectedItem != null)
            {
                Travel t = (Travel)travelGrid.SelectedItem;
                NavigationService.Navigate(new Traval_view(t));
            }
            else
            {
                MessageBox.Show("Выберите комплект");
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
                        source = source.OrderByDescending(x => x.Indate).ToList();
                        travelGrid.ItemsSource = null;
                        travelGrid.ItemsSource = source;
                        break;
                    case 2:
                        source = source.OrderByDescending(x => x.Surname).ToList();
                        travelGrid.ItemsSource = null;
                        travelGrid.ItemsSource = source;
                        break;
                    case 3:
                        source = source.OrderByDescending(x => x.Obj_ignition).ToList();
                        travelGrid.ItemsSource = null;
                        travelGrid.ItemsSource = source;
                        break;
                    case 4:
                        source = source.OrderByDescending(x => x.Address).ToList();
                        travelGrid.ItemsSource = null;
                        travelGrid.ItemsSource = source;
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
    }
}
