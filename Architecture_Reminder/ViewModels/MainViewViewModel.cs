using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Reminder _selectedReminder;
        private ObservableCollection<Reminder> _reminders;
        #region Commands
        private ICommand _addReminderCommand;
        private ICommand _deleteReminderCommand;
        #endregion
        #endregion

        #region Properties
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
