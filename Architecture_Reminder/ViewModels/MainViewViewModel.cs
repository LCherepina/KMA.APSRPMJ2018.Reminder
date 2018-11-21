﻿using System;
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
using Architecture_Reminder.Adapter;

namespace Architecture_Reminder.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields

        private int _indexSelected;
        private ReminderUIModel _selectedReminder;
        //private MainView _mainView;
        private List<ReminderUIModel> _reminders;

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
            get
            {
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

        public ReminderUIModel SelectedReminder { get { return _selectedReminder; } set { _selectedReminder = value; } }
        #endregion

        #region Constructor

        public MainViewViewModel()
        {
            FillReminders();
            PropertyChanged += OnPropertyChanged;
            //OnPropertyChanged(nameof(SelectedReminder));
        }
        #endregion

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            //OnReminderChanged(SelectedReminder);
            //if (propertyChangedEventArgs.PropertyName == "SelectedWallet")
            if(SelectedReminder != null)
                OnReminderChanged(SelectedReminder.Reminder);
        }

        private void FillReminders()
        {
            _reminders = new List<ReminderUIModel>();
            foreach (var rem in EntityWrapper.GetUserByGuid(StationManager.CurrentUser.Guid).Reminders)
                _reminders.Add(new ReminderUIModel(rem));
            if (_reminders.Count != 0)
                SelectedReminder = _reminders[0];
        }

        private async void AddReminderExecute(object o)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                //   Thread.Sleep(300);
                Reminder reminder = new Reminder(DateTime.Today.Date, DateTime.Now.Hour + 1, DateTime.Now.Minute, "",
                    StationManager.CurrentUser);
                var remUIModel = new ReminderUIModel(reminder);
                _reminders.Add(remUIModel);
                SelectedReminder = remUIModel;
                DBManager.AddReminder(reminder);
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
                //Reminder r = Reminders.ElementAt(SelectedReminderIndex);
                DBManager.DeleteReminder(Reminders.ElementAt(SelectedReminderIndex));
                Reminders.RemoveAt(SelectedReminderIndex);
                //if(SelectedReminder!=null)
                //(SelectedReminder.Reminder);
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
                    int minRemain = (Reminders[0].RemTimeMin - DateTime.Now.Minute);
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
 