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
    /// Логика взаимодействия для Traval_view.xaml
    /// </summary>
    public partial class Traval_view : Page
    {
        Travel t;
        public Traval_view(Travel travel)
        {
            InitializeComponent();
            this.t = travel;
            guardName.Text = $"Расчет №{t.GuardId}";

            Address.Text = t.Address;
            //..

        }

        private void Cancel_Tv_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Travel_list());
        }
    }
}
