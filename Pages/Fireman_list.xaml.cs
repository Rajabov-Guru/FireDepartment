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
    /// Логика взаимодействия для Fireman_list.xaml
    /// </summary>
    public partial class Fireman_list : Page
    {
        List<Fireman> source;
        public Fireman_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Firemans.ToList();
            }
            firemanGrid.ItemsSource = source;
        }

        public void UpdatreGrid()
        {
            using (FireDB db = new FireDB())
            {
                this.source = db.Firemans.ToList();
            }
            firemanGrid.ItemsSource = null;
            firemanGrid.ItemsSource = source;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_Fl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddFiremanClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Fireman_add());
        }

        private void FiremanChange(object sender, RoutedEventArgs e)
        {
            if (firemanGrid.SelectedItem != null) 
            {
                Fireman f = (Fireman)firemanGrid.SelectedItem;
                NavigationService.Navigate(new Fireman_change(f));
            }
            else 
            {
                MessageBox.Show("Выберите бойца");
            }
        }

        private void FiremanDelete(object sender, RoutedEventArgs e)
        {
            if (firemanGrid.SelectedItem != null)
            {
                Fireman f = (Fireman)firemanGrid.SelectedItem;
                using (FireDB db = new FireDB()) 
                {
                    Fireman fireman = db.Firemans.Find(f.Id);
                    db.Firemans.Remove(fireman);
                    db.SaveChanges();
                    this.UpdatreGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите бойца");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (queries.SelectedItem != null)
            {
                int number = int.Parse(queries.Text.Split('-')[0]);
                switch (number)
                {
                    case 1:
                        source = source.OrderByDescending(x => x.Date_birth).ToList();
                        firemanGrid.ItemsSource = null;
                        firemanGrid.ItemsSource = source;
                        break;
                    case 2:
                        //
                        firemanGrid.ItemsSource = null;
                        firemanGrid.ItemsSource = source;
                        break;
                    case 3:
                        //
                        firemanGrid.ItemsSource = null;
                        firemanGrid.ItemsSource = source;
                        break;
                    case 4:
                        //
                        firemanGrid.ItemsSource = null;
                        firemanGrid.ItemsSource = source;
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
