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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static User user;
        public static int attempts_count = 0;
        public AuthorizationPage()
        {
            InitializeComponent();
            tbLogin.Text = Properties.Settings.Default.Login;
        }
        private void btn_authorization_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Password < DateTime.Now)
            {
                string login = tbLogin.Text.Trim();
                string password = tbPassword.Password.Trim();
                user = Authorization.AuthorizationUser(login, password);
                if (user != null)
                {
                    if (cbSaveLogin.IsChecked.GetValueOrDefault())
                    {
                        Properties.Settings.Default.Login = tbLogin.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login = null;
                        Properties.Settings.Default.Save();
                    }
                    NavigationService.Navigate(new BasicPage(user));
                }
                else
                {
                    attempts_count++;
                    MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (attempts_count == 3)
                    {
                        attempts_count = 0;
                        Properties.Settings.Default.Password = DateTime.Now.AddMinutes(1);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверный пароль 3 раза, возможность входа заблокирована на: \n" + (Properties.Settings.Default.Password - DateTime.Now).Seconds + " сек.");
            }
        }

        private void btn_registration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GoToRegistrationPage());
        }
    }
}
