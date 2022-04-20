using FireDepartment.Classes;
using FireDepartment.Pages;
using System.Windows;
using System.Windows.Navigation;

namespace FireDepartment
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Act_list());
        }

        private void Travel_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Travel_list());
        }

        private void Guard_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Guard_list());
        }

        private void Fireman_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Fireman_list());
        }

        private void Complect_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Complect_list());
        }
    }
}
//это код который инициирует создание БД (потом убрать)
//using (FireDB db = new FireDB())
//{
//    Console.WriteLine(db.Complects.Count());
//}

//ParseMethods.FillDB();
//StaticMethods.Report();
//я