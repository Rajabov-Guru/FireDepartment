﻿using FireDepartment.Model;
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
    /// Логика взаимодействия для Fireman_change.xaml
    /// </summary>
    public partial class Fireman_change : Page
    {
        Fireman f;
        public Fireman_change(Fireman fireman)
        {
            InitializeComponent();
            this.f = fireman;
            SurnameFireman.Text = f.Surname;
            NameFireman.Text = f.Name;
            PatronymicFireman.Text = f.Patronymic;
            DateBirth.SelectedDate = f.Date_birth;
        }

        private void Cancel_Fa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Fireman_list());
        }

        private void Ok_Fa_Click(object sender, RoutedEventArgs e)
        {
            if (SurnameFireman.Text != "" && NameFireman.Text != "" && PatronymicFireman.Text != "")
            {


                if (DateBirth.SelectedDate.HasValue)
                {
                    var data = DateTime.Parse(DateBirth.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture));
                    if (data > DateTime.Parse("01.01.1980") && data < DateTime.Parse("01.2002"))
                    {
                        string formatted = DateBirth.SelectedDate.Value.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        using (FireDB db = new FireDB())
                        {
                            Fireman fireman = db.Firemans.Find(f.Id);
                            fireman.Surname = SurnameFireman.Text;
                            fireman.Name = NameFireman.Text;
                            fireman.Patronymic = PatronymicFireman.Text;
                            fireman.Date_birth = data;
                            fireman.GuardId = db.Guards.Count() - 1;
                            db.SaveChanges();
                            NavigationService.Navigate(new Fireman_list());
                        }
                    }
                    else MessageBox.Show("Введите дату в промежутке (1980-2002 год)");
                }
                else MessageBox.Show("Введите дату");
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
            
        }
    }
}
