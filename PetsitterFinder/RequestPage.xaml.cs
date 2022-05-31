using com.sun.org.apache.xpath.@internal.operations;
using Core;
using Core.DB;
using CsQuery.Engine.PseudoClassSelectors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static List<OverexposuredDate> overexposuredDates { get; set; }
        private Request Request { get; set; }
        private OverexposuredDate OverexposuredDate { get; set; }
        public RequestPage(Petsitter petsitter, User user)
        {
            InitializeComponent();
            currentUser = user;
            selectedPetsitter = petsitter;
            pets = DataAccess.GetPets(user.Id);
            cbPet.ItemsSource = pets;

            cbPet.DisplayMemberPath = "Name";
            Request = new Request();
            OverexposuredDate = new OverexposuredDate();
            overexposuredDates = DataAccess.GetOverexposuredDates().ToList();
            foreach (var date in overexposuredDates)
            {
                cldDate.BlackoutDates.Add(new CalendarDateRange(Convert.ToDateTime(date.Date)));
            }

        }
        private void btn_SendRequest_Click(object sender, RoutedEventArgs e)
        {
            var dates = cldDate.SelectedDates;
            if (dates != null)
            {
                if (Request.OverexposuredDates.Where(r => r.RequestId == Request.Id).Count() == 0)
                {
                    foreach (var date in dates)
                    {
                        Request.OverexposuredDates.Add(new OverexposuredDate { Request = Request, Date = date.Date});
                    }
                }
            }

            Request.Sum = lvDates.Items.Count * selectedPetsitter.PricePerDay;
            Request.State = false;
            Request.Status = "В ожидании";
            Request.PetssiterId = selectedPetsitter.Id;
            Request.UserId = currentUser.Id;
            DataAccess.AddRequest(Request);
        }

        private void cbPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pet = cbPet.SelectedItem as Pet;
            if (Request.RequestPets.Where(x => x.Pet.Id == pet.Id).Count() == 0)
                Request.RequestPets.Add(new RequestPet { Pet = pet });
            lvPets.ItemsSource = Request.RequestPets;
            lvPets.Items.Refresh();
        }

        private void lvPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pet = lvPets.SelectedItem as RequestPet;
            if (pet != null)
            {
                var requestPet = Request.RequestPets.FirstOrDefault(p => p.Pet.Id == pet.Pet.Id);
                Request.RequestPets.Remove(requestPet);
                lvPets.ItemsSource = Request.RequestPets;
                lvPets.Items.Refresh();
            }
        }

        private void cldDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            tbSum.Text = (lvDates.Items.Count * selectedPetsitter.PricePerDay).ToString();
        }
    }
}


