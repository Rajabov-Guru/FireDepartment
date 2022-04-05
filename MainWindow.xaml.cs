using FireDepartment.Pages;
using System.Windows;

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