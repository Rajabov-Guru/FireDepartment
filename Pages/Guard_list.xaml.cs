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
    /// Логика взаимодействия для Guard_list.xaml
    /// </summary>
    public partial class Guard_list : Page
    {
        List<Guard> source;
        public Guard_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Guards.ToList();
            }
            guardGrid.ItemsSource = source;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Gl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_Gl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void AddGuardClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Guard_add());
        }
    }
}
