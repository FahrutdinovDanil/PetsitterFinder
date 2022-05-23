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

namespace PetsitterFinder
{
    /// <summary>
    /// Логика взаимодействия для GoToRegistrationPage.xaml
    /// </summary>
    public partial class GoToRegistrationPage : Page
    {
        public GoToRegistrationPage()
        {
            InitializeComponent();
        }

        private void btn_RegClient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientRegistrationPage());
        }

        private void btn_RegSitter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SitterRegistrationPage());
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
