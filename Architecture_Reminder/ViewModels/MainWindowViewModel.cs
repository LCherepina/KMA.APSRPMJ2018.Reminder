﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Architecture_Reminder.Annotations;
using Architecture_Reminder.Managers;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Properties;


namespace Architecture_Reminder.ViewModels
{
    public class MainWindowViewModel : ILoaderOwner
    {
        private Visibility _visibility = Visibility.Hidden;
        private bool _isEnabled = true;

        public Visibility LoaderVisibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }

 /*       internal void StartApplication()
        {
            NavigationManager.Instance.Navigate(StationManager.CurrentUser != null ? ModesEnum.Main : ModesEnum.SignIn);
        }
        */
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}