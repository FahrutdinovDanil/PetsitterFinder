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
            ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.User);
            var currentUser = users.Where(u => u.Id == idUser).FirstOrDefault();
            return currentUser;
        }

        public static Pet GetPet(int idPet)
        {
            ObservableCollection<Pet> users = new ObservableCollection<Pet>(Connection.connection.Pet);
            var currentPet = users.Where(u => u.Id == idPet).FirstOrDefault();
            return currentPet;
        }

        public static User GetUser(string login, string password)
        {
            ObservableCollection<User> users = new ObservableCollection<User>(Connection.connection.User);
            var currentUser = users.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            return currentUser;
        }

        public static ObservableCollection<Pet> GetPets()
        {
            ObservableCollection<Pet> pets = new ObservableCollection<Pet>(Connection.connection.Pet.Where(p => p.IsDeleted == false || p.IsDeleted == null));
            return pets;
        }
        public static ObservableCollection<Petsitter> GetPetsitters()
        {
            ObservableCollection<Petsitter> petsitters = new ObservableCollection<Petsitter>(Connection.connection.Petsitter);
            return petsitters;
        }

        public static List<Pet> GetPets(int Id)
        {
            var user = GetUser(Id);
            var pets = user.Owner.Select(o => o.Pet).ToList();
            return pets;
        }

        public static bool AddPet(Pet pet)
        {
            try
            {
                Connection.connection.Pet.Add(pet);
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
                Connection.connection.Request.Add(request);
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
                Connection.connection.RequestPet.Add(requestPet);
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
                Connection.connection.Owner.Add(owner);
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
