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
    /// Логика взаимодействия для SittersPage.xaml
    /// </summary>
    public partial class SittersPage : Page
    {
        private static List<Petsitter> sitters { get; set; }
        public static User currentUser;
        public static int actualPage;
        public SittersPage(User user)
        {
            InitializeComponent();
            currentUser = user;
            sitters = DataAccess.GetPetsitters().ToList();
            lvPetsitters.ItemsSource = sitters;
            foreach (var sitter in sitters.ToList())
            {
                if (currentUser.Id == sitter.UserId)
                {
                    sitters.Remove(sitter);
                }
            }
            lvPetsitters.ItemsSource = sitters;
        }

        private void lvPetsitters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            var selectedSitter = lvPetsitters.SelectedItem as Petsitter;
            NavigationService.Navigate(new PetsitterPage(selectedSitter, currentUser));
        }

        public void Filter()
        {
            var filterPetsitters = sitters;

            if (tb_City_Search.Text != "")
            {
                filterPetsitters = sitters.Where(z => (z.Address.Contains(tb_City_Search.Text))).ToList();
            }
            else if (tb_Name_Search.Text != "")
            {
                filterPetsitters = sitters.Where(z => (z.Name.Contains(tb_Name_Search.Text)) || (z.Surname.Contains(tb_Name_Search.Text))).ToList();
            }
            lvPetsitters.ItemsSource = filterPetsitters;
        }

        private void tb_City_Search_TextChanged(object sender, RoutedEventArgs e)
        {
            actualPage = 0;
            Filter();
        }

        private void tb_Name_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Filter();
        }
    }
}
