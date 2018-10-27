using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Architecture_Reminder.ViewModels;
using Architecture_Reminder.Views.Reminder;

namespace Architecture_Reminder.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private int _countChildren;
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
            ListBoxMain.Items.Clear();
            
            _countChildren = _mainViewViewModel.Reminders.Count;

            for (int i = 0; i < (_countChildren); i++)
            {
                _currentReminderConfigurationView = new ReminderConfigurationView(_mainViewViewModel.Reminders.ElementAt(i));
                ListBoxMain.Items.Add(_currentReminderConfigurationView);
            }

        }

    }

}
