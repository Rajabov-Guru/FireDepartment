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

                //Act a = (Act)actGrid.SelectedItem;
                //using (FireDB db = new FireDB()) 
                //{
                //    db.Acts.Remove(a);
                //    db.SaveChanges();
                //}
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
                        source=source.OrderBy(x => x.Belonging).ToList();
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 2:
                        //...
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 3:
                        //...
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 4:
                        //...
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 5:
                        //...
                        actGrid.ItemsSource = null;
                        actGrid.ItemsSource = source;
                        break;
                    case 6:
                        //...
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
    }
}
