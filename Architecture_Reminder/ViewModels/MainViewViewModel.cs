using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Architecture_Reminder.Models;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Views;
using KMA.APZRPMJ2018.WalletSimulator.Properties;
using Architecture_Reminder.Managers;

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

        #endregion

        public List<Reminder> Reminders
        {
            get {
                //return _reminders; 
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
            //FillReminder();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            OnReminderChanged(SelectedReminder);
        }
        //private void FillReminder()
        //{
            //_reminders = new List<Reminder>();

        //}
        private void AddReminderExecute(object o)
        {
            //  Reminder reminder = new Reminder(DateTime.Today.Date, "", StationManager.CurrentUser);
            List<Reminder> rems = Reminders;
            Reminder reminder = new Reminder(DateTime.Today.Date, DateTime.Now.Hour+1, DateTime.Now.Minute, "");
            StationManager.CurrentUser.Reminders.Add(reminder);
            SelectedReminder = reminder;
            StationManager.CurrentUser.Reminders.Sort();
            OnPropertyChanged();
        }

        private void DeleteReminderExecute(KeyEventArgs args)
        {

            if (StationManager.CurrentUser.Reminders.Count == 0) return;
            if (SelectedReminderIndex < 0) return;
            StationManager.CurrentUser.Reminders.RemoveAt(SelectedReminderIndex);
            OnPropertyChanged();

        }

        private void RunReminderExecute(object o)
        {
            
            Console.WriteLine("Reminder");
           
            MessageBox.Show(DateTime.Now.ToString());

            OnPropertyChanged();
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