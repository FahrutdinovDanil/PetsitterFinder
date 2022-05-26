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
    /// Логика взаимодействия для AddPetPage.xaml
    /// </summary>
    public partial class AddPetPage : Page
    {
        private static User currentUser;
        public AddPetPage(User user)
        {
            currentUser = user;
            InitializeComponent();
        }

        private void btn_NextPage_Click(object sender, RoutedEventArgs e)
        {
            Pet petToAdd = new Pet();
            petToAdd.Owners.Add(new Owner { User = currentUser});
            petToAdd.Name= tbPetName.Text.Trim();

            DataAccess.AddPet(petToAdd);
        }

        private void btn_AddPetPhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
