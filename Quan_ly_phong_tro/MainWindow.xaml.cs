﻿using System;
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

namespace Quan_ly_phong_tro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        public void check(object sender, RoutedEventArgs e)
        {
            PageAddCustomer pageAddCustomer = new PageAddCustomer();
            _NavigationFrame.Navigate(pageAddCustomer);
        }

        public void checkCustomer(object sender, RoutedEventArgs e)
        {
            PageGetCustomer pageGetCustomer = new PageGetCustomer();
            _NavigationFrame.Navigate(pageGetCustomer);
        }

        public void dashboard(object sender, RoutedEventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            _NavigationFrame.Navigate(dashboard);
        }
        
        
        public void clickBill(object sender, RoutedEventArgs e)
        {
            PageBill pageBill = new PageBill();
            _NavigationFrame.Navigate(pageBill);
        }
    }
}
