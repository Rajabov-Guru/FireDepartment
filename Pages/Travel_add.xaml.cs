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
    /// Логика взаимодействия для Travel_add.xaml
    /// </summary>
    public partial class Travel_add : Page
    {
        public Travel_add()
        {
            InitializeComponent();
        }

        private void Ok_Ta_Click(object sender, RoutedEventArgs e)
        {
            if (Name_division.Text != "" &&
             Address.Text != null &&
                Obj_ignition.Text != null &&
                Type_ignition.Text != "" &&
            Indate.SelectedDate.HasValue &&
                      Surname.Text != "" &&
                         Name.Text != "" &&
                   Patronymic.Text != "" && 
                    Telephone.Text != "") // Проверка на введенность данных
            {
                var data = DateTime.Parse(Indate.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                var number = ulong.Parse(Telephone.Text);
                if (data > DateTime.Parse("01.01.2022") && data < DateTime.Parse("31.12.2032"))
                {
                    if (number >= 8000000000 || number <= 8999999999)
                    {
                        using (FireDB db = new FireDB())
                        {
                            Travel travel = new Travel();
                            travel.Name_division = Name_division.Text;
                            travel.Address = Address.Text;            // Address.SelectedItem.Text;
                            travel.Obj_ignition = Obj_ignition.Text;  // Obj_ignition.SelectedItem.Text;
                            travel.Type_ignition = Type_ignition.Text;
                            travel.Indate = data;
                            travel.Surname = Surname.Text;
                            travel.Name = Name.Text;
                            travel.Patronymic = Patronymic.Text;
                            travel.Telephone = Telephone.Text;
                            travel.GuardId = db.Guards.Count() - 1;
                            travel.ActId = db.Acts.Count() - 1;
                            db.Travels.Add(travel);
                            db.SaveChanges();
                            Console.WriteLine("Работает");
                            NavigationService.Navigate(new Travel_list());
                        }
                    }
                    else MessageBox.Show("Введите номер телефона в диапазоне 8000000000-8999999999");

                }
                else MessageBox.Show("Введите дату в промежутке (2022-2032 год)");

            }
            else MessageBox.Show("Введите данные");
            
        }

        private void Cancel_Ta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Travel_list());
        }
    }
}
