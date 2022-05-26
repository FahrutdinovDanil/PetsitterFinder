using Core;
using Core.DB;
using System;

namespace FinderConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user;
            bool auth = false;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[+] Добро пожаловать в Petsitter Finder!");
            while (!auth)
            {
                Console.WriteLine("[+] Для авторизации введите /login, для регистрации /registration, для входа как сотрудник /loginEmp");
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
                    }
                    else
                    {
                        Console.WriteLine("[+] Логин или пароль не верный, попробуйте еще раз!");
                    }
                }
            }
        }
    }
}
