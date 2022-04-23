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
    /// Логика взаимодействия для Complect_add.xaml
    /// </summary>
    public partial class Complect_add : Page
    {
        public Complect_add()
        {
            InitializeComponent();
        }

        private void Ok_Ca_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentList.Text != "")
            {
                using (FireDB db=new FireDB()) 
                {
                    Complect c = new Complect();
                    c.EquipmentList = EquipmentList.Text;
                    db.Complects.Add(c);
                    db.SaveChanges();
                    NavigationService.Navigate(new Complect_list());
                }
            }
            else 
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void Cancel_Ca_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Complect_list());
        }
    }
}
