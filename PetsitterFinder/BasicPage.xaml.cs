using Core;
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
    /// Логика взаимодействия для BasicPage.xaml
    /// </summary>
    public partial class BasicPage : Page
    {
        public static User currentUser;
        public BasicPage(User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void lb_Main_Click(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new BasicPage());
        }
        private void lb_MyPets_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MyPetsPage(currentUser));
        }

        private void btn_MyCabinet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MyCabinetPage());
        }

        private void lb_Sitters_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new SittersPage(currentUser));
        }

        private void lb_MyRequests_Click(object sender, MouseButtonEventArgs e)
        {
            if (currentUser.RoleId == 3)
                NavigationService.Navigate(new ClientRequestsPage(currentUser));
            else
                NavigationService.Navigate(new PetsitterRequestsPage(currentUser));


        }
    }
}
