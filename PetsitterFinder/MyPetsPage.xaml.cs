using Core;
using Core.DB;
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
    /// Логика взаимодействия для MyPetsPage.xaml
    /// </summary>
    public partial class MyPetsPage : Page
    {
        private static User currentUser;
        private static List<Pet> pets { get; set; }
        public MyPetsPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            pets = DataAccess.GetPets(user.Id);
            lvPets.ItemsSource = pets;
            DataContext = this;
        }

        private void btn_AddPet_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPetPage(currentUser));
        }
    }
}
