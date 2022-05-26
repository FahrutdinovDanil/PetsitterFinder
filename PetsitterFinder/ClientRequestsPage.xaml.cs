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
    /// Логика взаимодействия для ClientRequestsPage.xaml
    /// </summary>
    public partial class ClientRequestsPage : Page
    {
        private static User currentUser;
        private static List<Request> requests { get; set; }
        public ClientRequestsPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            lvRequests.ItemsSource = DataAccess.GetRequestsForClient(DataAccess.GetClient(currentUser).Id);
        }
    }
}
