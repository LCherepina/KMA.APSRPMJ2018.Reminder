﻿using Architecture_Reminder.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Architecture_Reminder.Annotations;
using Architecture_Reminder.DBAdapter;
using Architecture_Reminder.DBModels;

namespace Architecture_Reminder.ViewModels
{
    internal class ReminderConfigurationViewModel : INotifyPropertyChanged
    {
        #region Fields

        private readonly Reminder _currentReminder;
        private string[] _hours;
        private string[] _minutes;
        private ValueType val;

        #endregion

        #region Properties


        public DateTime RemDate
        {
            get { return _currentReminder.RemDate.Date; }
            set
            {
                _currentReminder.RemDate = value;
                ReminderServiceWrapper.SaveReminder(_currentReminder);
                OnPropertyChanged();
            }
        }

        public int RemTimeHours
        {
            get { return _currentReminder.RemTimeHour; }
            set
            {
               if ((((value == DateTime.Now.Hour && _currentReminder.RemTimeMin > DateTime.Now.Minute )
                                       || (value > DateTime.Now.Hour ) ) && _currentReminder.RemDate == DateTime.Today) || _currentReminder.RemDate > DateTime.Today)
               { 

                    _currentReminder.RemTimeHour = value;
                    OnPropertyChanged();
                   // Console.WriteLine(value);
                }
               else
               {
                   _currentReminder.RemTimeHour = _currentReminder.RemTimeHour;
                   OnPropertyChanged();
                }
                ReminderServiceWrapper.SaveReminder(_currentReminder);
            }
        }
        public int RemTimeMinutes
        {
            get { return _currentReminder.RemTimeMin; }
            set
            {
                var oldTime = _currentReminder.RemTimeMin;
                if(((( _currentReminder.RemTimeHour == DateTime.Now.Hour && value > DateTime.Now.Minute) || (_currentReminder.RemTimeHour > DateTime.Now.Hour))
                   && _currentReminder.RemDate == DateTime.Today) || _currentReminder.RemDate > DateTime.Today)
                {
                    _currentReminder.RemTimeMin = value;
                    OnPropertyChanged();
                    // Console.WriteLine(value);   
                }
               else
               {
                   _currentReminder.RemTimeMin = oldTime;
                   OnPropertyChanged();
                }

                /*     if (value < DateTime.Now.Minute && _currentReminder.RemDate < DateTime.Today &&
                           _currentReminder.RemTimeHour <= DateTime.Now.Hour)
                     {
                         Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() => RemTimeMinutes = oldTime),
                                 DispatcherPriority.ApplicationIdle);
                     }
                     */
                ReminderServiceWrapper.SaveReminder(_currentReminder);
            }
        }

        public string RemText
        {
            get { return _currentReminder.RemText; }
            set
            {
                _currentReminder.RemText = value;
                ReminderServiceWrapper.SaveReminder(_currentReminder);
                OnPropertyChanged();
            }
        }
        public string[] FillHours
        {
            get
            {
                _hours = new string[24];
                for (int i = 0; i < _hours.Length; i++)
                {
                    if (i < 10) _hours[i] = "0" + i;
                    else _hours[i] = i + "";
                }

                return _hours;
            }

        }
        public string[] FillMinutes
        {
            get
            {
                _minutes = new string[60];
                for (int i = 0; i < _minutes.Length; i++)
                {
                    if (i < 10) _minutes[i] = "0" + i;
                    else _minutes[i] = i + "";
                }

                return _minutes;
            }
        }


        #endregion

        #region Constructor

        public ReminderConfigurationViewModel(Reminder reminder)
        {
            _currentReminder = reminder;
        }

        public ReminderConfigurationViewModel()
        {
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