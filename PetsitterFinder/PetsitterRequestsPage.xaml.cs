using Core;
using Core.DB;
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
    /// Логика взаимодействия для PetsitterRequestsPage.xaml
    /// </summary>
    public partial class PetsitterRequestsPage : Page
    {
        private static List<OverexposuredDate> overexposuredDates { get; set; }
        private static List<Request> requests { get; set; }
        private static User currentUser;
        public PetsitterRequestsPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            lvRequests.ItemsSource = DataAccess.GetRequestsForPetsitter(DataAccess.GetPetsitter(currentUser).Id);
        }

        private void btn_Accept_Click(object sender, RoutedEventArgs e)
        {
            var request = lvRequests.SelectedItem as Request;
            request.StatusForSitter = "Принято";
            request.StatusForClient = "Принято";
            DataAccess.EditRequest(request);
            lvRequests.Items.Refresh();
        }

        private void btn_Reject_Click(object sender, RoutedEventArgs e)
        {
            overexposuredDates = DataAccess.GetOverexposuredDates().ToList();
            var request = lvRequests.SelectedItem as Request;

            foreach (var reques in overexposuredDates.ToList())
            {
                if (request.Id == reques.RequestId)
                {
                    DataAccess.RemoveOverexposuredDate(reques.Id);
                }
            }
            request.StatusForClient = "Отказано";
            request.StatusForSitter = "Отказано";
            DataAccess.EditRequest(request);
            lvRequests.Items.Refresh();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            overexposuredDates = DataAccess.GetOverexposuredDates().ToList();
            var request = lvRequests.SelectedItem as Request;
            foreach (var reques in overexposuredDates.ToList())
            {
                if (request.Id == reques.RequestId)
                {
                    DataAccess.RemoveOverexposuredDate(reques.Id);
                }
            }
            request.StatusForSitter = "Удален";
            DataAccess.DeleteRequestPetsitter(request);
            NavigationService.Navigate(new PetsitterRequestsPage(currentUser));
        }
    }
}
