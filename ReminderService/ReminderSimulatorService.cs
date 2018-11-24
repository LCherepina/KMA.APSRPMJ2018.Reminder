using System;
using System.Collections.Generic;
using Architecture_Reminder.DBAdapter;
using Architecture_Reminder.DBModels;
using Architecture_Reminder.ServiceInterface;


namespace Architecture_Reminder.ReminderService
{
    class ReminderSimulatorService : IReminderContract
    {
        public bool UserExists(string login)
        {
            return DBAdapter.ReminderServiceWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return DBAdapter.ReminderServiceWrapper.GetUserByLogin(login);
        }

        public User GetUserByGuid(Guid guid)
        {
            return DBAdapter.ReminderServiceWrapper.GetUserByGuid(guid);
        }

        public void AddUser(User user)
        {
            DBAdapter.ReminderServiceWrapper.AddUser(user);
        }

        public void AddReminder(Reminder reminder)
        {
            DBAdapter.ReminderServiceWrapper.AddReminder(reminder);
        }

        public List<User> GetAllUsers(Guid reminderGuid)
        {
            return DBAdapter.ReminderServiceWrapper.GetAllUsers(reminderGuid);
        }

        public void DeleteReminder(Reminder selectedReminder)
        {
            DBAdapter.ReminderServiceWrapper.DeleteReminder(selectedReminder);
        }


        public void SaveReminder(Reminder reminder)
        {
            DBAdapter.ReminderServiceWrapper.SaveReminder(reminder);
        }
    }
}
