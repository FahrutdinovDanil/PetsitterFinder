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
        private static User currentUser;
        public static User user;
        private static Request Request { get; set; }
        private ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.Users);
        static void Main(string[] args)
        {

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
                        MainMenu(user);
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
                else if (answer == "/registrationSitter")
                {
                    bool correcInput = false;
                    while (!correcInput)
                    {
                        Console.WriteLine("[+] Введите Ваше имя:");
                        string sitterName = Console.ReadLine();
                        Console.WriteLine("[+] Введите Вашу фамилию:");
                        string sitterSurname = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш номер телефона :");
                        string sitterNumber = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш логин:");
                        string sitterLogin = Console.ReadLine();
                        Console.WriteLine("[+] Введите Ваш пароль:");
                        string sitterPassword = Console.ReadLine();

                        if (sitterName != null && sitterSurname != null && sitterNumber != null && sitterLogin != null && sitterPassword != null)
                        {
                            User userToAdd = new User();
                            userToAdd.Password = sitterPassword;
                            userToAdd.Login = sitterLogin;
                            userToAdd.RoleId = 3;
                            Registration.AddUser(userToAdd);

                            Petsitter petsitterToAdd = new Petsitter();
                            petsitterToAdd.Name = sitterName;
                            petsitterToAdd.Surname = sitterSurname;
                            petsitterToAdd.Phone = sitterNumber;
                            petsitterToAdd.UserId = userToAdd.Id;
                            correcInput = true;
                            Registration.AddPetsitter(petsitterToAdd);
                            Console.WriteLine("[+] Загрузка...");

                        }

                    }
                }
            }
        }
        static void MainMenu(User user)
        {
            currentUser = user;
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("[+] Доступные команды: /addPet, /myPets, /sendRequest /myRequests");
                string command = Console.ReadLine();
                if (command == "/addPet")
                {
                    Pet petToAdd = new Pet();
                    Console.WriteLine("[+] Введите имя вашего питомца: ");
                    petToAdd.Name = Console.ReadLine();
                    Console.WriteLine("[+] Введите породу питомца: ");
                    petToAdd.Вreed = Console.ReadLine();
                    Console.WriteLine("[+] Введите сколько лет питомцу: ");
                    petToAdd.Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("[+] И введите сколько месяцев питомцу: ");
                    petToAdd.Month = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("[+] Введите размер питомца: ");
                    petToAdd.Size = Convert.ToInt32(Console.ReadLine());

                    petToAdd.Owners.Add(new Owner { User = currentUser });

                    DataAccess.AddPet(petToAdd);
                    Console.WriteLine("[+] Питомец успешно добавлен!");
                }
                else if (command == "/myPets")
                {
                    List<Pet> pets = DataAccess.GetPets(currentUser.Id);
                    foreach (Pet pet in pets)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"[+] Имя: {pet.Name}");
                        Console.WriteLine($"[+] Порода: {pet.Вreed}");
                        Console.WriteLine($"[+] Возраст: {pet.Year}");

                    }
                    Console.WriteLine("");
                }
                else if (command == "/myRequests")
                {
                    if (currentUser.RoleId == 3)
                    {
                        List<Request> requests = DataAccess.GetRequestsForClient(DataAccess.GetClient(currentUser).Id);
                        foreach (Request request in requests)
                        {
                            Console.WriteLine("----------------------------");
                            Console.WriteLine($"[+] Имя клиента: {request.Client.Name}");
                            Console.WriteLine($"[+] Имя ситтера: {request.Petsitter.Name}");
                            Console.WriteLine($"[+] Статус: {request.Status}");

                        }
                        Console.WriteLine("");
                    }
                    else if (currentUser.RoleId == 2)
                    {
                        List<Request> requests = DataAccess.GetRequestsForPetsitter(DataAccess.GetPetsitter(currentUser).Id);
                        foreach (Request request in requests)
                        {
                            Console.WriteLine("----------------------------");
                            Console.WriteLine($"[+] Номер заказа: {request.Id}");
                            Console.WriteLine($"[+] Имя клиента: {request.Client.Name}");
                            Console.WriteLine($"[+] Имя ситтера: {request.Petsitter.Name}");
                            Console.WriteLine($"[+] Статус: {request.Status}");

                        }
                        Console.WriteLine("");

                        Console.WriteLine("[+] Доступные команды: /Accept, /Delete, /Reject");
                        string commandRequest = Console.ReadLine();
                        if (commandRequest == "/Accept")
                        {
                            Console.WriteLine("[+] Выберите номер заказа");
                            int selectedRequest = Convert.ToInt32(Console.ReadLine());
                            foreach (Request request in requests)
                            {

                                if (selectedRequest == request.Id)
                                {
                                    AcceptRequest(selectedRequest);
                                }

                            }
                        }
                        else if (commandRequest == "/Delete")
                        {
                            Console.WriteLine("[+] Выберите номер заказа");
                            int selectedRequest = Convert.ToInt32(Console.ReadLine());
                            foreach (Request request in requests)
                            {

                                if (selectedRequest == request.Id)
                                {
                                    DeleteRequest(selectedRequest);
                                }

                            }
                        }
                        else if (commandRequest == "/Reject")
                        {
                            Console.WriteLine("[+] Выберите номер заказа");
                            int selectedRequest = Convert.ToInt32(Console.ReadLine());
                            foreach (Request request in requests)
                            {

                                if (selectedRequest == request.Id)
                                {
                                    RejectRequest(selectedRequest);
                                }

                            }
                        }
                    }

                }
                else if (command == "/sendRequest")
                {
                    List<Petsitter> petsitters = DataAccess.GetPetsitters();
                    foreach (Petsitter petsitter in petsitters)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"[+] ID: {petsitter.Id}");
                        Console.WriteLine($"[+] Имя: {petsitter.Name}");
                        Console.WriteLine($"[+] Фамилия: {petsitter.Surname}");
                        Console.WriteLine($"[+] Адрес: {petsitter.Address}");
                        Console.WriteLine($"[+] Номер телефона: {petsitter.Phone}");

                    }
                    Console.WriteLine("");
                    
                    Console.WriteLine("[+] Выберите ситтера");
                    int selectedPetsitter = Convert.ToInt32(Console.ReadLine());
                    foreach (Petsitter petsitter in petsitters)
                    {

                        if (selectedPetsitter == petsitter.Id)
                        {
                            List<Pet> pets = DataAccess.GetPets(currentUser.Id);
                            foreach (Pet pet in pets)
                            {
                                Console.WriteLine("----------------------------");
                                Console.WriteLine($"[+] Номер: {pet.Id}");
                                Console.WriteLine($"[+] Имя: {pet.Name}");
                                Console.WriteLine($"[+] Порода: {pet.Вreed}");
                                Console.WriteLine($"[+] Возраст: {pet.Year}");
                            }

                            Console.WriteLine("[+] Выберите питомца: ");
                            int selectedPet= Convert.ToInt32(Console.ReadLine());
                            foreach (Pet pet in pets)
                            {
                                if (selectedPet == pet.Id)
                                {
                                    Request = new Request();

                                    //Console.WriteLine("[+] Введите дату: ");
                                    //Request.Date = Convert.ToDateTime(Console.ReadLine());
                                    Request.RequestPets.Add(new RequestPet { Pet = pet });
                                    //Request.Date = Convert.ToDateTime(Console.ReadLine());
                                    Request.State = false;
                                    Request.Status = "В ожидании";
                                    Request.PetssiterId = selectedPetsitter;
                                    Request.ClientId = DataAccess.GetClient(currentUser).Id;

                                    DataAccess.AddRequest(Request);
                                    Console.WriteLine("[+] Ваша заявка отправлена!");
                                }
                            }
                        }

                    }

                }
            }
        }
        static void AcceptRequest(int selectedRequest)
        {

            Request requests = DataAccess.GetRequestsForPetsitter(DataAccess.GetPetsitter(currentUser).Id).FirstOrDefault(r => r.Id == selectedRequest);
            requests.Status = "Принято";
            DataAccess.EditRequest(requests);
        }
        static void DeleteRequest(int selectedRequest)
        {

            Request requests = DataAccess.GetRequestsForPetsitter(DataAccess.GetPetsitter(currentUser).Id).FirstOrDefault(r => r.Id == selectedRequest);
            requests.Status = "Удален";
            DataAccess.DeleteRequest(requests);
        }
        static void RejectRequest(int selectedRequest)
        {

            Request requests = DataAccess.GetRequestsForPetsitter(DataAccess.GetPetsitter(currentUser).Id).FirstOrDefault(r => r.Id == selectedRequest);
            requests.Status = "Отказано";
            DataAccess.EditRequest(requests);
        }
    }
}
