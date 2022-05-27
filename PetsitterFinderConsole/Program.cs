using Core;
using Core.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsitterFinderConsole
{
    public class Program
    {
        private ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.Users);
        static void Main(string[] args)
        {
            User user;

            bool auth = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[+] Добро пожаловать в Petsitter Finder!");
            while (!auth)
            {
                Console.WriteLine("[+] Для авторизации введите /login, для регистрации /registrationClient, для входа как сотрудник /registrationSitter");
                string answer = Console.ReadLine();
                if (answer == "/login")
                {
                    Console.WriteLine("[+] Введите логин для авторизации: ");
                    string loginUsr = Console.ReadLine();
                    Console.WriteLine("[+] Введите пароль для авторизации: ");
                    string passwUsr = Console.ReadLine();
                    Console.WriteLine("[+] Загрузка...");
                    user = Authorization.AuthorizationUser(loginUsr, passwUsr);
                    if (user != null)
                    {
                        Console.WriteLine($"Приветсвуем Вас!");
                        auth = true;
                        //MainMenu((int)usr.id_Role, usr.id_Parent);
                    }
                    else
                    {
                        Console.WriteLine("[+] Логин или пароль не верный, попробуйте еще раз!");
                    }
                }
                else if (answer == "/registrationClient")
                {
                    bool correcInput = false;
                    while (!correcInput)
                    {
                        Console.WriteLine("[+] Введите Ваше имя:");
                        string clientName = Console.ReadLine();
                        Console.WriteLine("[+] Введите Вашу фамилию:");
                        string clientSurname = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш номер телефона :");
                        string clientNumber = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш логин:");
                        string clientLogin = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш пароль:");
                        string clientPassword = Console.ReadLine();

                        if (clientName != null && clientSurname != null && clientNumber != null && clientLogin != null && clientPassword != null)
                        {
                            User userToAdd = new User();
                            userToAdd.Password = clientPassword;
                            userToAdd.Login = clientLogin;
                            userToAdd.RoleId = 3;
                            Registration.AddUser(userToAdd);

                            Client clientToAdd = new Client();
                            clientToAdd.Name = clientName;
                            clientToAdd.Surname = clientSurname;
                            clientToAdd.Phone = clientNumber;
                            clientToAdd.UserId = userToAdd.Id;
                            correcInput = true;
                            Registration.AddClient(clientToAdd);
                            Console.WriteLine("[+] Загрузка...");

                        }

                    }
                }
            }
        }
    }
}
