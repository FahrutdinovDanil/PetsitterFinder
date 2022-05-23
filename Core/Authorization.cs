using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Authorization
    {
        public static ObservableCollection<User> users { get; set; }
        public static User AuthorizationUser(string login, string password)
        {
            users = new ObservableCollection<User>(Connection.connection.User.ToList());
            var userExists = users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
            if (userExists != null)
            {
                return userExists;
            }
            else
            {
                return userExists;
            }
        }
        public static void EditUser(int id, byte[] photo, string nick)
        {
            var user = Connection.connection.User.Where(x => x.Id == id).FirstOrDefault();
            //user.Nickname = nick;
            //user.Photo = photo;
            Connection.connection.SaveChanges();
        }

        //public static ObservableCollection<User> SearchUser(string nick)
        //{
        //    return users = new ObservableCollection<User>(Connection.connection.User.Where(a => a.Nickname == nick).ToList());
        //}
    }
}
