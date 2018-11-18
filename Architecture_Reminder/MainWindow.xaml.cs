﻿using System;
using System.Windows.Controls;
using Architecture_Reminder.Tools;
using Architecture_Reminder.Managers;
using Architecture_Reminder.ViewModels;

namespace Architecture_Reminder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
          //  mainWindowViewModel.StartApplication();
            navigationModel.Navigate(ModesEnum.SignIn);
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}