using Core;
using Core.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsitterFinderConsole
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
                        //MainMenu((int)usr.id_Role, usr.id_Parent);
                    }
                    else
                    {
                        Console.WriteLine("[+] Логин или пароль не верный, попробуйте еще раз!");
                    }
                }
                //else if (answer == "/registration")
                //{
                //    bool correcInput = false;
                //    while (!correcInput)
                //    {
                //        Console.WriteLine("[+] Введите Ваше имя:");
                //        string usrName = Console.ReadLine();
                //        Console.WriteLine("[+] Введите Вашу фамилию:");
                //        string usrSurname = Console.ReadLine();
                //        Console.WriteLine("[+] Введите Ваш номер телефона :");
                //        string usrNumber = Console.ReadLine();
                //        Console.WriteLine("[+] Введите Ваш логин:");
                //        string usrLogin = Console.ReadLine();
                //        Console.WriteLine("[+] Введите Ваш пароль:");
                //        string usrPassword = Console.ReadLine();
                //        int id_Role = 2;
                //        if (usrLogin != null && usrName != null && usrSurname != null && usrPassword != null)
                //        {
                //            correcInput = true;
                //            Console.WriteLine("[+] Загрузка...");
                //            Parent par = new Parent();
                //            par.Login = usrLogin;
                //            par.Password = usrPassword;
                //            par.Name = usrName;
                //            par.Surname = usrSurname;
                //            par.Number = usrNumber;
                //            par.id_Role = id_Role;
                //            if (MainFunc.CheckRegistrationLogin(par.Login))
                //            {
                //                AddToBD.AddParent(par);
                //                Console.WriteLine($"Приветсвуем Вас, {par.Name}!");
                //                auth = true;
                //                MainMenu((int)par.id_Role, par.id_Parent);
                //                break;
                //            }
                //            else
                //            {
                //                Console.WriteLine("[+] Пользователь с таким логином уже существует");
                //            }

                //        }

                //    }
                //}
            }
        }
    }
}
