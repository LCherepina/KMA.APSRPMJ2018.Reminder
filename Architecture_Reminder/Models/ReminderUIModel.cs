using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.Models
{
    public class UIModel : INotifyPropertyChanged
    {
        #region Fields
        private Reminder _reminder;
        #endregion

        #region Properties
        internal Reminder Reminder
        {
            get { return _reminder; }
            private set
            {
                _reminder = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _reminder.Title; }
            set
            {
                _reminder.Title = value;
                OnPropertyChanged();
            }
        }
        public long TotalIncome
        {
            get { return _reminder.TotalIncome; }
        }
        public long TotalOutcome
        {
            get { return _reminder.TotalOutcome; }
        }

        public Guid Guid
        {
            get { return _reminder.Guid; }
        }

        #endregion

        public UIModel(Reminder reminder)
        {
            _reminder = reminder;
        }

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
