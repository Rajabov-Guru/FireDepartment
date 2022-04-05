using FireDepartment.Classes;
using FireDepartment.Model;
using FireDepartment.Pages;
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