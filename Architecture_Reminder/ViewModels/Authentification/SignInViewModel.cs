using Architecture_Reminder.Managers;
using Architecture_Reminder.Models;
using Architecture_Reminder.Properties;
using Architecture_Reminder.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Architecture_Reminder.ViewModels.Authentification
{
    class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _password;
        private string _login;
        #endregion

        #region Commands
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        #endregion

        #region Properties
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }
        #endregion

        #region Commands
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }
        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));
            }
        }
        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));
            }
        }


        #endregion

        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }
        private bool SignInCanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_login) && !String.IsNullOrWhiteSpace(_password);
        }

        private void SignInExecute(object obj)
        {
            User currentUser;
            Console.WriteLine(_login);
            try
            {
                currentUser = DBManager.GetUserByLogin(_login);
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine,
                    e.Message));
                return;
            }
            if (currentUser == null)
            {
                MessageBox.Show(String.Format(Resources.SignIn_UserDoesntExist, _login));
                return;
            }
            try
            {
                if (!currentUser.CheckPassword(_password))
                {
                    MessageBox.Show(Resources.SignIn_WrongPassword);
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToValidatePassword, Environment.NewLine,
                    e.Message));
                return;
            }
            StationManager.CurrentUser = currentUser;
            NavigationManager.Instance.Navigate(ModesEnum.Main);
        }
        private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModesEnum.SignUp);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            /*PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }*/
        }
    }
}
