﻿using Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для SittersPage.xaml
    /// </summary>
    public partial class SittersPage : Page
    {
        private static ObservableCollection<Petsitter> sitters { get; set; }
        public static User currentUser;
        public SittersPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            sitters = DataAccess.GetPetsitters();
            lvPetsitters.ItemsSource = sitters;
            DataContext = this;
        }

        private void lvPetsitters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedSitter = lvPetsitters.SelectedItem as Petsitter;
            NavigationService.Navigate(new PetsitterPage(selectedSitter));
        }
    }
}