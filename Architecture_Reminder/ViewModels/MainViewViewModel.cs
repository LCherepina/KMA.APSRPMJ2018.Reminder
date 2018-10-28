using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Architecture_Reminder.Models;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Views;
using KMA.APZRPMJ2018.WalletSimulator.Properties;

namespace Architecture_Reminder.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields

        private int _indexSelected;
        private Reminder _selectedReminder;
        private MainView _mainView;
        private List<Reminder> _reminders;

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
            get { return _reminders; }
        }

        public int SelectedReminderIndex
        {
            get { return _indexSelected;}
            set
            {
                _indexSelected = value;
               
            }
        }
        #endregion

        #region Constructor
        
        public MainViewViewModel()
        {
            FillReminder();
            PropertyChanged += OnPropertyChanged;
        }
        #endregion

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            OnReminderChanged(_selectedReminder);
        }
        private void FillReminder()
        {
            _reminders = new List<Reminder>();
          
        }
        private void AddReminderExecute(object o)
        {
          //  Reminder reminder = new Reminder(DateTime.Today.Date, "", StationManager.CurrentUser);
       
            Reminder reminder = new Reminder(DateTime.Today.Date, DateTime.Now.Hour+1 ,DateTime.Now.Minute,"");
            _reminders.Add(reminder);
             _selectedReminder = reminder;
            OnPropertyChanged();
        }
        
        private void DeleteReminderExecute(KeyEventArgs args)
        {
            
            if (_reminders.Count == 0) return;
            if (SelectedReminderIndex < 0) return;
            _mainView = new MainView();
            _reminders.RemoveAt(SelectedReminderIndex);
             OnPropertyChanged();
            
        }

        private void RunReminderExecute(object o)
        {
            
            Console.WriteLine("Reminder");
            
           
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
