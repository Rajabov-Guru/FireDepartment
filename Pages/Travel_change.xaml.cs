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
    /// Логика взаимодействия для Travel_change.xaml
    /// </summary>
    public partial class Travel_change : Page
    {
        Travel t;
        public Travel_change(Travel travel)
        {
            InitializeComponent();
            this.t = travel;

            Name_division.Text = t.Name_division;
            Type_ignition.Text = t.Type_ignition;
            Surname.Text=t.Surname;
            Name.Text=t.Name;
            Patronymic.Text=t.Patronymic;   
            Telephone.Text=t.Telephone;
            DatePicker_Indate.Text = t.Indate.ToString();
            Obj_ign.Text= t.Obj_ignition;
            Adress.Text = t.Address;
            
        }

        private void Cancel_Ta_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Travel_list());
        }

        private void Ok_Ta_Click(object sender, RoutedEventArgs e)
        {
            if (Name_division.Text != "" &&
            Adress.Text != null &&
               Obj_ign.Text != null &&
               Type_ignition.Text != "" &&
           DatePicker_Indate.SelectedDate.HasValue &&
                     Surname.Text != "" &&
                        Name.Text != "" &&
                  Patronymic.Text != "" &&
                   Telephone.Text != "") // Проверка на введенность данных
            {
                using (FireDB db = new FireDB())
                {
                    Travel travel = db.Travels.Find(t.Id);
                    travel.Name_division = Name_division.Text;
                    travel.Name_division = Name_division.Text;
                    travel.Type_ignition = Type_ignition.Text;
                    travel.Surname = Surname.Text;
                    travel.Name = Name.Text;
                    travel.Patronymic = Patronymic.Text;
                    travel.Telephone = Telephone.Text;
                    travel.Indate = DateTime.Parse(DatePicker_Indate.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture)); ;
                    travel.Obj_ignition = Obj_ign.Text;
                    travel.Address = Adress.Text;
                    //дописать
                    db.SaveChanges();
                    NavigationService.Navigate(new Travel_list());
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
    }
}
