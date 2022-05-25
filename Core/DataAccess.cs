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

        public static ObservableCollection<Petsitter> GetPetsitters()
        {
            ObservableCollection<Petsitter> petsitters = new ObservableCollection<Petsitter>(Connection.connection.Petsitters);
            return petsitters;
        }

        public static List<Pet> GetPets(int Id)
        {
            var user = GetUser(Id);
            var pets = user.Owners.Select(o => o.Pet).ToList();
            return pets;
        }
        public static ObservableCollection<Request> GetRequests()
        {
            ObservableCollection<Request> requests = new ObservableCollection<Request>(Connection.connection.Requests);
            return requests;
        }

        public static ObservableCollection<Request> GetRequestsForClient(int Id)
        {
            return new ObservableCollection<Request>(Connection.connection.Requests.Where(r => r.ClientId == Id));
        }

        public static ObservableCollection<Request> GetRequestsForPetsitter(int Id)
        {
            return new ObservableCollection<Request>(Connection.connection.Requests.Where(r => r.PetssiterId == Id));
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
    }
}
