﻿using System;
using System.Windows;
using Architecture_Reminder.Models;
using System.IO;
using Architecture_Reminder.Tools;

namespace Architecture_Reminder.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get ; set; }

        static StationManager()
        {
            DeserializeLastUser();
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
                CurrentUser = userCandidate;
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
