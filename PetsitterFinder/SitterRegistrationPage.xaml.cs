using Core;
using Core.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для SitterRegistrationPage.xaml
    /// </summary>
    public partial class SitterRegistrationPage : Page
    {
        private ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.Users);
        private byte[] user_photo;
        public SitterRegistrationPage()
        {
            InitializeComponent();
        }

        private void btn_AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                user_photo = File.ReadAllBytes(openFile.FileName);
                imgClient.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
        private void btn_SaveSitter_Click(object sender, RoutedEventArgs e)
        {
            User userToAdd = new User();
            userToAdd.Password = tbPassword.Text.Trim();
            userToAdd.Login = tbLogin.Text.Trim();
            userToAdd.RoleId = 2;

            var lastUser = users.Last();
            Petsitter petsitterToAdd = new Petsitter();
            petsitterToAdd.Name = tbName.Text.Trim();
            petsitterToAdd.Surname = tbSurname.Text.Trim();
            petsitterToAdd.Phone = tbPhone.Text.Trim();
            petsitterToAdd.Photo = user_photo;
            petsitterToAdd.Address = tbCity.Text;
            petsitterToAdd.BirthDate = dpBirthDate.SelectedDate;
            petsitterToAdd.UserId = lastUser.Id;


            if (Registration.UniqueLogin(userToAdd.Login))
            {
                if (petsitterToAdd.Name != "" && petsitterToAdd.Surname != "" && userToAdd.Login != "" && userToAdd.Password != "" && petsitterToAdd.Phone != "")
                {
                    Registration.AddUser(userToAdd);

                    Registration.AddPetsitter(petsitterToAdd);
                    NavigationService.Navigate(new AuthorizationPage());

                    MessageBox.Show("Аккаунт успешно создан!");
                }
                else
                {
                    MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                tbLogin.Text = "";
                MessageBox.Show("Придумайте другой логин");
            }
        }
    }
}
