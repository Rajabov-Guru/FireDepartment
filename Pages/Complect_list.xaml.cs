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
    /// Логика взаимодействия для Complect_list.xaml
    /// </summary>
    public partial class Complect_list : Page
    {
        List<Complect> source;
        public Complect_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Complects.ToList();
            }
            complectGrid.ItemsSource = source;
        }

        public void UpdatreGrid()
        {
            using (FireDB db = new FireDB())
            {
                this.source = db.Complects.ToList();
            }
            complectGrid.ItemsSource = null;
            complectGrid.ItemsSource = source;
        }
        private void AddComplectClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Complect_add());
        }

        private void ChangeComplectClick(object sender, RoutedEventArgs e)
        {
            if (complectGrid.SelectedItem != null)
            {
                Complect c = (Complect)complectGrid.SelectedItem;
                NavigationService.Navigate(new Complect_change(c));
            }
            else 
            {
                MessageBox.Show("Выберите комплект");
            }
            
        }

        private void ComplectDelClick(object sender, RoutedEventArgs e)
        {
            if (complectGrid.SelectedItem != null)
            {
                Complect c = (Complect)complectGrid.SelectedItem;
                using (FireDB db = new FireDB()) 
                {
                    Complect complect=db.Complects.Find(c.Id);
                    db.Complects.Remove(complect);
                    db.SaveChanges();
                    this.UpdatreGrid();
                }
            }
            else
            {
                MessageBox.Show("Выберите комплект");
            }
        }

       
    }
}
