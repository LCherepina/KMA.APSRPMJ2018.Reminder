﻿using Architecture_Reminder.Tools;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Architecture_Reminder.Models
{

    public class User
    {

        #region Fields
        private string _login;
        private string _password;
        private List<Reminder> _reminders;
        #endregion

        #region Properties
        
        public string Login
        {
            get { return _login; }
            private set { _login = value; }
        }
        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }
        public List<Reminder> Reminders
        {
            get { return _reminders; }
            private set { _reminders = value; }
        }
        #endregion

        #region Constructor

        public User(string login, string password)
        {
            _login = login;
            SetPassword(password);
        }

        private User()
        {
            _reminders = new List<Reminder>();
        }

        #endregion

        private void SetPassword(string password)
        {
            _password = Encrypting.Encrypt(password);
        }
        

        public bool CheckPassword(string password)
        {
            Console.WriteLine(_password);
            string res = Encrypting.Encrypt(password);
            return _password.CompareTo(res) == 0;
        }

    }
}
