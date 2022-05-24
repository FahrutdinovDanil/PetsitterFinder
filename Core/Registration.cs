﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Registration
    {
        public static ObservableCollection<User> users { get; set; }
        public static bool AddUser(User user)
        {
            try
            {
                Connection.connection.User.Add(user);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddClient(Client client)
        {
            try
            {
                Connection.connection.Client.Add(client);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddPetsitter(Petsitter petsitter)
        {
            try
            {
                Connection.connection.Petsitter.Add(petsitter);
                Connection.connection.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UniqueLogin(string login)
        {
            users = new ObservableCollection<User>(Connection.connection.User.ToList());
            bool loginUnic = true;
            foreach (var i in users)
            {
                if (i.Login == login)
                {
                    loginUnic = false;
                }
            }
            return loginUnic;
        }
    }
}