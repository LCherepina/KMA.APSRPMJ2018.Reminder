using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Architecture_Reminder.Managers;
using Architecture_Reminder.Models;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Views;
using Architecture_Reminder.Views.Reminder;
using KMA.APZRPMJ2018.WalletSimulator.Properties;

namespace Architecture_Reminder.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Reminder _selectedReminder;
        private List<Reminder> _reminders;

        #region Commands
        private ICommand _addReminderCommand;
        private ICommand _deleteReminderCommand;
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

        #endregion

        public List<Reminder> Reminders
        {
            get { return _reminders; }
        }
        public Reminder SelectedReminder
        {
            get { return _selectedReminder; }
            set
            {
                _selectedReminder = value;
                OnPropertyChanged();
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
            //Console.WriteLine(_selectedReminder.ToString());
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
           //  if (args.Key != Key.Delete) return;
            if (SelectedReminder == null) return;
            if (_reminders.Count() == 0) return;
            
            _reminders.RemoveAt(0);
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
