using System;
using System.Windows;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get ; set; }

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
