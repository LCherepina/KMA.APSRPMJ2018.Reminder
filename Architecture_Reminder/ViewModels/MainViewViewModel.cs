using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Architecture_Reminder.Models;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Views;
using KMA.APZRPMJ2018.WalletSimulator.Properties;
using Architecture_Reminder.Managers;
using System.Threading;
using System.Threading.Tasks;

namespace Architecture_Reminder.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields

        private int _indexSelected;
        private Reminder _selectedReminder;
        //private MainView _mainView;
        //private List<Reminder> _reminders;

        #region Commands
        private ICommand _addReminderCommand;
        private ICommand _deleteReminderCommand;
        private ICommand _runReminderCommand;
        private ICommand _logOutCommand;
        #endregion
        #endregion

        #region Properties
        #region Commands

        public ICommand AddReminderCommand
        {
            get
            {
                return _addReminderCommand ?? (_addReminderCommand = new RelayCommand<object>(AddReminderExecute));
            }
        }
        public ICommand DeleteReminderCommand
        {
            get
            {
                return _deleteReminderCommand ?? (_deleteReminderCommand = new RelayCommand<KeyEventArgs>(DeleteReminderExecute));
            }
        }

        public ICommand RunReminderCommand
        {
            get
            {
                return _runReminderCommand ?? (_runReminderCommand = new RelayCommand<object>(RunReminderExecute));
            }
        }

        public ICommand LogOutCommand
        {
            get
            {
                return _logOutCommand ?? (_logOutCommand = new RelayCommand<object>(LogOutExecute));
            }
        }

        #endregion

        public List<Reminder> Reminders
        {
            get {
                return StationManager.CurrentUser.Reminders;
            }
        }

        public int SelectedReminderIndex
        {
            get { return _indexSelected; }
            set
            {
                _indexSelected = value;

            }
        }

        public Reminder SelectedReminder { get { return _selectedReminder; } set { _selectedReminder = value; } }
        #endregion

        #region Constructor

        public MainViewViewModel()
        {
            //FillReminders();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            OnReminderChanged(SelectedReminder);
        }

        private void FillReminders()
        {
            /*_reminders = new List<Reminder>();
            foreach (var wallet in StationManager.CurrentUser.Reminders)
                _reminders.Add(wallet);
            if (_reminders.Count != 0)
                SelectedReminder = _reminders[0];*/
        }

        private async void AddReminderExecute(object o)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(300);
                Reminder reminder = new Reminder(DateTime.Today.Date, DateTime.Now.Hour + 1, DateTime.Now.Minute, "",
                    StationManager.CurrentUser);
                SelectedReminder = reminder;
                DBManager.AddReminder(reminder);
             //   var remindertUIModel = new ReminderUIModel(reminder);
             //   _.Add(walletUIModel);
           //     _selectedWallet = walletUIModel;
                //_reminders.Add(reminder);

                return true;

            });
            LoaderManager.Instance.HideLoader();
            OnPropertyChanged();

        }

        private async void DeleteReminderExecute(KeyEventArgs args)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                if (Reminders.Count == 0) return false;
                if (SelectedReminderIndex < 0) return false;
                Reminders.RemoveAt(SelectedReminderIndex);
                DBManager.DeleteReminder(SelectedReminder);
                Reminders.Sort();
                //FillReminders();
               
                return true;
            });
            LoaderManager.Instance.HideLoader();
            OnPropertyChanged();
        }

        private async void LogOutExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                Thread.Sleep(100);
                StationManager.CurrentUser = null;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ModesEnum.SignIn);
        }

        private void RunReminderExecute(object o)
        {

           Thread myThread = new Thread(new ThreadStart(CheckIfRun));
            myThread.IsBackground = true;
            myThread.Start();
            OnPropertyChanged();
        }

        private void CheckIfRun()
        {
            if (Reminders[0].RemDate == DateTime.Today)
            {
                if (Reminders[0].RemTimeHour == DateTime.Now.Hour)
                {
                    int minRemain = (Reminders[0].RemTimeMin - DateTime.Now.Minute) ;
                    TimeSpan interval = new TimeSpan(0, minRemain, -20);

                    Thread.Sleep(interval);
                    Console.WriteLine("Reminder");

                    
                    MessageBox.Show(Reminders[0].RemTimeHour + " : " + Reminders[0].RemTimeMin + " " + Reminders[0].ToString());
                    Reminders.RemoveAt(0);

                    DBManager.UpdateUser(StationManager.CurrentUser);
                    Reminders.Sort();

                    
                }
            }
            
           // OnPropertyChanged();
        }

        #region EventsAndHandlers
        #region Loader
        internal event ReminderChangedHandler ReminderChanged;
        internal delegate void ReminderChangedHandler(Reminder reminder);

        internal virtual void OnReminderChanged(Reminder reminder)
        {
            ReminderChanged?.Invoke(reminder);
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }



}