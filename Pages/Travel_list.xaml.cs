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
        public Travel_list()
        {
            InitializeComponent();
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
    }
}
