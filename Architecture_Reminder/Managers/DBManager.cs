
using Architecture_Reminder.Adapter;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.Managers
{
    public class DBManager
    {
        /*
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
        */

        public static void UpdateUser(User currentUser)
        {
            SaveChanges();
        }
        private static void SaveChanges()
        {
            //return EntityWrapper.();
        }

        public static bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        internal static User CheckCachedUser(User userCandidate)
        {
            var userInStorage = EntityWrapper.GetUserByGuid(userCandidate.Guid);
            if (userInStorage != null && userInStorage.CheckPassword(userCandidate))
                return userInStorage;
            return null;
        }

        public static void DeleteReminder(Reminder selectedReminder)
        {
            EntityWrapper.DeleteReminder(selectedReminder);
        }

        public static void AddReminder(Reminder reminder)
        {
            EntityWrapper.DeleteReminder(reminder);
        }

    }
}
