using Core.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataAccess
    {
        private static ObservableCollection<Client> clients = new ObservableCollection<Client>(Connection.connection.Clients);
        public static User GetUser(int idUser)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.Users);
            var currentUser = users.Where(u => u.Id == idUser).FirstOrDefault();
            return currentUser;
        }

        public static Pet GetPet(int idPet)
        {
            ObservableCollection<Pet> users = new ObservableCollection<Pet>(Connection.connection.Pets);
            var currentPet = users.Where(u => u.Id == idPet).FirstOrDefault();
            return currentPet;
        }

        public static User GetUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.Users);
            var currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            return currentUser;
        }

        public static ObservableCollection<Pet> GetPets()
        {
            ObservableCollection<Pet> pets = new ObservableCollection<Pet>(Connection.connection.Pets.Where(p => p.IsDeleted == false || p.IsDeleted == null));
            return pets;
        }
        public static ObservableCollection<Client> GetClients()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>(Connection.connection.Clients);
            return clients;
        }

        public static Client GetClientById(int id)
        {
            return clients.Where(c => c.Id == id).FirstOrDefault();
        }

        public static ObservableCollection<Petsitter> GetPetsitters()
        {
            ObservableCollection<Petsitter> petsitters = new ObservableCollection<Petsitter>(Connection.connection.Petsitters);
            return petsitters;
        }
        public static ObservableCollection<OverexposuredDate> GetOverexposuredDates()
        {
            ObservableCollection<OverexposuredDate> overexposuredDates = new ObservableCollection<OverexposuredDate>(Connection.connection.OverexposuredDates);
            return overexposuredDates;
        }

        public static List<Pet> GetPets(int Id)
        {
            var user = GetUser(Id);
            var pets = user.Owners.Select(o => o.Pet).ToList();
            return pets;
        }

        public static ObservableCollection<Request> GetRequests()
        {
            ObservableCollection<Request> requests = new ObservableCollection<Request>(Connection.connection.Requests.Where(p => p.State == false));
            return requests;
        }

        public static ObservableCollection<Request> GetRequestsForClient(int Id)
        {
            return new ObservableCollection<Request>(GetRequests().Where(r => r.UserId == Id));
        }

        public static ObservableCollection<Request> GetRequestsForPetsitter(int Id)
        {
            return new ObservableCollection<Request>(GetRequests().Where(r => r.PetssiterId == Id));
        }

        public static void SavePet(Pet pet)
        {
            if (GetPets().FirstOrDefault(a => a.Id == pet.Id) == null)
                Connection.connection.Pets.Add(pet);

            Connection.connection.SaveChanges();
        }

        public static bool EditPet(Pet pet)
        {
            try
            {
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void UpdatePet(Pet pet)
        {
            Pet newPet = GetPet(pet.Id);
            newPet.Discription = pet.Discription;
            newPet.Name = pet.Name;
            newPet.Year = pet.Year;
            newPet.Month = pet.Month;
            newPet.Size = pet.Size;
            newPet.Вreed = pet.Вreed;
            newPet.Gender = pet.Gender;
            newPet.IsDeleted = pet.IsDeleted;
            SavePet(newPet);
        }

        public static void RemovePet(int id)
        {
            Connection.connection.Pets.Remove(GetPet(id));
            Connection.connection.SaveChanges();
        }
        public static OverexposuredDate GetOverexposuredDate(int idDate)
        {
            ObservableCollection<OverexposuredDate> overexposuredDates = new ObservableCollection<OverexposuredDate>(Connection.connection.OverexposuredDates);
            var currentDate = overexposuredDates.Where(u => u.Id == idDate).FirstOrDefault();
            return currentDate;
        }

        public static void RemoveOverexposuredDate(int id)
        {
            Connection.connection.OverexposuredDates.Remove(GetOverexposuredDate(id));
            Connection.connection.SaveChanges();
        }

        public static bool AddPet(Pet pet)
        {
            try
            {
                Connection.connection.Pets.Add(pet);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddRequest(Request request)
        {
            try
            {
                Connection.connection.Requests.Add(request);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddRequestPet(RequestPet requestPet)
        {
            try
            {
                Connection.connection.RequestPets.Add(requestPet);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddOverexposuredDate(OverexposuredDate overexposuredDate)
        {
            try
            {
                Connection.connection.OverexposuredDates.Add(overexposuredDate);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddOwner(Owner owner)
        {
            try
            {
                Connection.connection.Owners.Add(owner);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Client GetClient(User user)
        {
            return GetClients().FirstOrDefault(c => c.UserId == user.Id);
        }

        public static Petsitter GetPetsitter(User user)
        {
            return GetPetsitters().FirstOrDefault(c => c.UserId == user.Id);
        }

        public static bool EditRequest(Request request)
        {
            try
            {
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteRequest(Request request)
        {
            request.State = true;
            try
            {
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
