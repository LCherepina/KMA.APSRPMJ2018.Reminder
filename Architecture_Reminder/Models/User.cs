using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture_Reminder.Models
{

    public class User
    {

        //to do ????
        #region Const
        private const string PrivateKey = "";
        private const string PublicKey = "";
        #endregion
        // ????????/

        #region Fields
        private string _email;
        private string _login;
        private string _password;
        private List<Reminder> _reminders;
        #endregion

        #region Properties
        public string Email
        {
            get { return _email; }
            private set { _email = value; }
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
        public List<Reminder> Reminders
        {
            get { return _reminders; }
            set { _reminders = value; }
        }
        #endregion

        #region Constructor

        public User(string email, string login, string password)
        {
            _email = email;
            _login = login;
            _password = password;
        }

        #endregion

        private void SetPassword(string password)
        {
            _password = password;
        }

        public bool CheckPassword(string password)
        {
            if (_password.CompareTo(password) == 1)
                return true;
            return false;
        }

    }
}
