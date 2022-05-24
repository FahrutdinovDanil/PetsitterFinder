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
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        private static User currentUser;
        private static Petsitter selectedPetsitter;
        private static List<Pet> pets { get; set; }
        public RequestPage(Petsitter petsitter, User user)
        {
            InitializeComponent();
            currentUser = user;
            selectedPetsitter = petsitter;
            pets = DataAccess.GetPets(user.Id);
            cbPet.ItemsSource = pets;
            cbPet.DisplayMemberPath = "Name";
        }
        private void btn_SendRequest_Click(object sender, RoutedEventArgs e)
        {
            Request requestToAdd = new Request();
            requestToAdd.Date = dpDate.SelectedDate;
            requestToAdd.PetssiterId = selectedPetsitter.Id;
            requestToAdd.ClientId = currentUser.Id;
            

            RequestPet requestPetToAdd = new RequestPet();
            var selectedPet = cbPet.SelectedItem as Pet;
            requestPetToAdd.PetId = selectedPet.Id;

            DataAccess.AddRequest(requestToAdd);
            DataAccess.AddRequestPet(requestPetToAdd);

            //DataAccess.AddPetsitter(petsitterToAdd);
        }

        private void BtnAddPet_Click(object sender, RoutedEventArgs e)
        {
            //if (cbPet.SelectedIndex >= 0)
            //{
            //    var ApplicationsPet = new ApplicationsPet();
            //    var sel = cbPet.SelectedItem as Pet;
            //    ApplicationsPet.PetId = sel.Id;
            //    var isPet = DataAccess.GetPets().Where(c => c.Id == sel.Id).Count();
            //    if (isPet == 0)
            //    {
            //        DataAccess.AddApplicationsPet(ApplicationsPet);
            //        UpdatePetList();
            //    }
            //}
        }
        //private void UpdateCountryList()
        //{
        //    CountryLv.ItemsSource = DataAccess.GetProdCountries().Where(e => e.ProductId == selectedProduct.Id).ToList();
        //}

        private void BtnRemovePet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbPet_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
