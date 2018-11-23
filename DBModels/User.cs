using Architecture_Reminder.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Security.Cryptography;
using System.Text;

namespace Architecture_Reminder.DBModels
{
    [Serializable]
    public class User
    {

        #region Fields
        private Guid _guid;
        private string _login;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _lastLoginDate;
        private bool _logOut;
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

        public DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }

        public bool LogOut
        {
            get
            {
                return _logOut;
            }
            set { _logOut = value; }
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
            _guid = Guid.NewGuid();
            _login = login;
            SetPassword(password);
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _lastLoginDate = DateTime.Now;
            _logOut = false;
            _reminders = new List<Reminder>();
          
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
            try
            {
                Console.WriteLine(_password);
                string res = Encrypting.Encrypt(password);
                return _password.CompareTo(res) == 0;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
        public bool CheckPassword(User userCandidate)
        {
            try
            {
                return _password == userCandidate._password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

        #region EntityConfiguration

        public class UserEntityConfiguration : EntityTypeConfiguration<User>
        {
            public UserEntityConfiguration()
            {
                ToTable("Users");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.FirstName)
                    .HasColumnName("FirstName")
                    .IsRequired();
                Property(p => p.LastName)
                    .HasColumnName("LastName")
                    .IsRequired();
                Property(p => p.Email)
                    .HasColumnName("Email")
                    .IsOptional();
                Property(p => p.Login)
                    .HasColumnName("Login")
                    .IsRequired();
                Property(p => p.Password)
                    .HasColumnName("Password")
                    .IsRequired();
                Property(p => p.LastLoginDate)
                    .HasColumnName("LastLoginDate")
                    .IsRequired();
                Property(p => p.LogOut)
                    .HasColumnName("LogOut")
                    .IsRequired();

                HasMany(s => s.Reminders)
                    .WithRequired(w => w.User)
                    .HasForeignKey(w => w.UserGuid)
                    .WillCascadeOnDelete(true);
            }
        }
        #endregion
    }
}
