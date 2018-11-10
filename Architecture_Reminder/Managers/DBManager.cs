using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architecture_Reminder.Models;
using Architecture_Reminder.Tools;

namespace Architecture_Reminder.Managers
{
    public class DBManager
    {
        private static readonly List<User> Users = new List<User>();

        static DBManager()
        {
            Users = SerializationManager.Deserialize<List<User>>(FileFolderHelper.StorageFilePath) ?? new List<User>();
        }

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
            SaveChanges();
        }

        private static void SaveChanges()
        {
            SerializationManager.Serialize(Users, FileFolderHelper.StorageFilePath);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = Users.FirstOrDefault(u => u.Guid == userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate.Password))
                return userInStorage;
            return null;
        }

        public static void UpdateUser(User currentUser)
        {
            SaveChanges();
        }
    }
}
