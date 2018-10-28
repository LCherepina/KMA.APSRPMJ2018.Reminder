using Architecture_Reminder.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KMA.APZRPMJ2018.WalletSimulator.Properties;

namespace Architecture_Reminder.ViewModels
{
    internal class ReminderConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly Reminder _currentReminder;

        #endregion

        #region Properties


        public DateTime RemDateTimeStart
        {
            get { return DateTime.Today.Date; }
            set
            {
                _currentReminder.RemDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime RemDate
        {
            get { return _currentReminder.RemDate.Date; }
            set
            {
                _currentReminder.RemDate = value;
                OnPropertyChanged();
            }
        }

        public string RemTimeHours
        {
            get { return _currentReminder.RemTimeHour; }
            set
            {
                _currentReminder.RemTimeHour = value;
                OnPropertyChanged();
            }
        }
        public string RemTimeMinutes
        {
            get { return _currentReminder.RemTimeMin; }
            set
            {
                _currentReminder.RemTimeMin = value;
                OnPropertyChanged();
            }
        }

        public string RemText
        {
            get { return _currentReminder.RemText; }
            set
            {
                _currentReminder.RemText = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Constructor

        public ReminderConfigurationViewModel(Reminder reminder)
        {
            _currentReminder = reminder;
        }

        #endregion

        #region EventsAndHandlers

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #endregion
    }
}