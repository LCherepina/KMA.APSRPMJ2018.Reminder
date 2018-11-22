using System;
using System.Windows;
using Architecture_Reminder.Models;
using System.IO;
using Architecture_Reminder.Tools;

namespace Architecture_Reminder.Managers
{
    public static class StationManager
    {

        private static User _currentUser;

        public static User CurrentUser { get { return _currentUser; } set { _currentUser = value; } }

        static StationManager()
        {
            //   _currentUser = new User("","","","","");
            // _currentUser = DBManager.GetLastUser();
            //DeserializeLastUser();
           
            _currentUser = GetLastUser();
            if (_currentUser != null)
            {
                _currentUser.LastLoginDate = DateTime.Now;
                DBManager.UpdateUser(_currentUser);
                
            }
           
            Console.WriteLine(_currentUser);
        }

        private static User GetLastUser()
        {
            User userCandidate;
            try
            {
                userCandidate = DBManager.GetLastUser();
            }
            catch (Exception e)
            {
                userCandidate = null;
               
            }
            

            return userCandidate;
        }

        private static void DeserializeLastUser()
        {
            User userCandidate;
            try
            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
            }catch(Exception e)
            {
                userCandidate = null;
                Logger.Log("Failed to Deserialize last user", e);
            }
            if (userCandidate == null)
            {
                Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
                Logger.Log("Failed to relogin last user");
            else
                //CurrentUser = userCandidate;
                _currentUser = userCandidate;
        }

        public static void Initialize()
        {

        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
