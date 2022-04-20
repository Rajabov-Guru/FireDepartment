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
    }
}
