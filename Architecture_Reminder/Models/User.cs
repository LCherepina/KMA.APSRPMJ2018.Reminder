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
            _password = password;
        }

        private User()
        {
            _reminders = new List<Reminder>();
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
