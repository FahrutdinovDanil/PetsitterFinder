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

namespace PetsitterFinder
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame_auto_reg.Navigate(new AuthorizationPage());
        }

        private void lb_Main_Click(object sender, MouseButtonEventArgs e)
        {
            //frame_auto_reg.Navigate(new BasicPage());
        }

        private void btn_MyCabinet_Click(object sender, RoutedEventArgs e)
        {
            //frame_auto_reg.Navigate(new MyCabinetPage());
        }

        private void lb_Sitters_Click(object sender, MouseButtonEventArgs e)
        {
            //frame_auto_reg.Navigate(new SittersPage());
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame_auto_reg.GoBack();
        }
    }
}
