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
    /// Логика взаимодействия для PetsitterRequestsPage.xaml
    /// </summary>
    public partial class PetsitterRequestsPage : Page
    {
        private static List<Request> requests { get; set; }
        private static User currentUser;
        public PetsitterRequestsPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            lvRequests.ItemsSource = DataAccess.GetRequestsForPetsitter(currentUser.Id);
            DataContext = this;
        }
    }
}
