using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users = new List<User>();

        public static bool UserExist(string login)
        {
            foreach(User u in Users)
                if (u.Login == login)
                    return true;
            return false;
        }

        public static User GetUserByLogin(string login)
        {
            foreach (User u in Users)
                if (u.Login == login)
                    return u;
            return null;
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }
    }
}
