using Core;
using Core.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PetsitterPage.xaml
    /// </summary>
    public partial class PetsitterPage : Page
    {
        private static Petsitter selectedPetsitter;
        private static User currentUser;
        public PetsitterPage(Petsitter petsitter, User user)
        {
            InitializeComponent();
            currentUser = user;
            selectedPetsitter = petsitter;
            tbNameSurname.Text = $"{selectedPetsitter.Name} {selectedPetsitter.Surname}";
            tbAddress.Text = selectedPetsitter.Address;
            tbPrice.Text = selectedPetsitter.PricePerDay.ToString();
            this.DataContext = selectedPetsitter;
        }

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RequestPage(selectedPetsitter, currentUser));
        }
    }
}
