using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Architecture_Reminder.ViewModels;
using Architecture_Reminder.Views.Reminder;

namespace Architecture_Reminder.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private int _countChildren =0;
        private MainViewViewModel _mainViewViewModel;
        private ReminderConfigurationView _currentReminderConfigurationView;

        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainViewViewModel = new MainViewViewModel();
            _mainViewViewModel.ReminderChanged += OnReminderChanged;
            DataContext = _mainViewViewModel;
        }

        private void OnReminderChanged(Models.Reminder reminder)
        {
            MainGrid.Children.Clear();

            _countChildren = _mainViewViewModel.Reminders.Count();

            int _nRows = MainGrid.RowDefinitions.Count;

            if (_nRows < _countChildren)
            {
                for (int i = 0; i < (_countChildren - _nRows); i++)
                {
                    MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(60) });
                }
            }
            else if (_nRows > _countChildren)
            {
                for (int i = 0; i < ( _nRows - _countChildren); i++)
                {
                    MainGrid.RowDefinitions.RemoveAt(_countChildren-i);
                }
            }
        


           if (_countChildren > 0)
            {
                //MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(60) });
            }
            Console.WriteLine(_countChildren);
            for (int i = 0; i < _countChildren; i++)
            {
                _currentReminderConfigurationView = new ReminderConfigurationView(_mainViewViewModel.Reminders.ElementAt(i));
                MainGrid.Children.Add(_currentReminderConfigurationView);
                Grid.SetRow(_currentReminderConfigurationView, i);
            }
        }

    }

}
