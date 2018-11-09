using Architecture_Reminder.Tools;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Architecture_Reminder.Models
{

    public class User
    {

        #region Fields
        private Guid _guid;
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private List<Reminder> _reminders;
        #endregion

        #region Properties
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
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
        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            private set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
        }
        public List<Reminder> Reminders
        {
            get { return _reminders; }
            private set { _reminders = value; }
        }
        #endregion

        #region Constructor

        public User(string login, string password, string firstName, string lastName, string email)
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
