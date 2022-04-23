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
    /// Логика взаимодействия для Complect_list.xaml
    /// </summary>
    public partial class Complect_list : Page
    {
        List<Complect> source;
        public Complect_list()
        {
            InitializeComponent();
            using (FireDB db = new FireDB())
            {
                this.source = db.Complects.ToList();
            }
            complectGrid.ItemsSource = source;
        }

        private void AddComplectClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Complect_add());
        }
    }
}
