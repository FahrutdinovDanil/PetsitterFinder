using Core;
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
    /// Логика взаимодействия для ClientRegistrationPage.xaml
    /// </summary>
    public partial class ClientRegistrationPage : Page
    {
        private ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.User);
        private byte[] user_photo;

        public ClientRegistrationPage()
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
        private void btn_SaveClient_Click(object sender, RoutedEventArgs e)
        {
            User userToAdd = new User();
            userToAdd.Password = tbPassword.Text.Trim();
            userToAdd.Login = tbLogin.Text.Trim();
            userToAdd.RoleId = 3;

            var lastUser = users.Last();
            Client clientToAdd = new Client();
            clientToAdd.Name = tbName.Text.Trim();
            clientToAdd.Surname = tbSurname.Text.Trim();
            clientToAdd.Phone = tbPhone.Text.Trim();
            clientToAdd.Photo = user_photo;
            clientToAdd.UserId = lastUser.Id;
            

            if (Registration.UniqueLogin(userToAdd.Login))
            {
                if (clientToAdd.Name != "" && clientToAdd.Surname != "" && userToAdd.Login != "" && userToAdd.Password != "" && clientToAdd.Phone != "")
                {
                    Registration.AddUser(userToAdd);

                    Registration.AddClient(clientToAdd);
                    NavigationService.Navigate(new AuthorizationPage());

                    System.Windows.MessageBox.Show("Аккаунт успешно создан!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Заполните все поля!");
                }
            }
            else
            {
                tbLogin.Text = "";
                System.Windows.MessageBox.Show("Придумайте другой логин");
            }
        }
    }
}
