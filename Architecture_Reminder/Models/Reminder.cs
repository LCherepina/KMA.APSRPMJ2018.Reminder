using System;
using System.Data.Entity.ModelConfiguration;

namespace Architecture_Reminder.Models
{
    [Serializable]
    public class Reminder : IComparable<Reminder>
    {
        public static int _id = 1;
        #region Fields
        private Guid _guid;
        private Guid _userGuid;
        private DateTime _dateTime;
        private int _minutes;
        private int _hours;
        private string _text;
        private int _myId;
        private User _user;
        #endregion

        #region Properties
        public Guid Guid
        {
            get { return _guid; }
            private set { _guid = value; }
        }
        public int MyId
        {
            get { return _myId; }
            set { _myId = value; }
        }

        public DateTime RemDate
        {
            get { return _dateTime.Date; }
            set { _dateTime = value; }
        }
        public int RemTimeHour
        {
            get { return _hours; }
            set { _hours = value; }
        }
        public int RemTimeMin
        {
            get { return _minutes; }
            set { _minutes = value; }
        }
        public string RemText
        {
            get { return _text; }
            set { _text = value; }
        }

        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        public Guid UserGuid
        {
            get { return _userGuid; }
            private set { _userGuid = value; }
        }
        #endregion

        #region Constructor
        //    public Reminder(DateTime dateTime, string text, User user)
        public Reminder(DateTime dateTime, int hours, int minutes, string text, User user)
        {
            _guid = Guid.NewGuid();
            _dateTime = dateTime.Date;
            _hours = hours;
            _minutes = minutes;
            _text = text;
            _myId = _id;
            _id++;
            _user = user;
            user.Reminders.Add(this);
            user.Reminders.Sort();
        }

        private Reminder() { }
        #endregion

        public override string ToString()
        {
            return _text;
        }

        public int CompareTo(Reminder other)
        {
            if (RemDate > other.RemDate)
                return 1;
            else if (RemDate < other.RemDate)
                return -1;

            if (RemTimeHour > other.RemTimeHour)
            {
                return 1; 
            }
            else if (RemTimeHour < other.RemTimeHour)
                return -1;

            if (RemTimeMin > other.RemTimeMin)
                return 1;
            else if (RemTimeMin < other.RemTimeMin)
                return -1;

            return 0;
        }
        #region EntityFrameworkConfiguration
        public class ReminderEntityConfiguration : EntityTypeConfiguration<Reminder>
        {
            public ReminderEntityConfiguration()
            {
                ToTable("Reminder");
                HasKey(s => s.Guid);

                Property(p => p.Guid)
                    .HasColumnName("Guid")
                    .IsRequired();
                Property(p => p.RemDate)
                    .HasColumnName("RemDate")
                    .IsRequired();
                Property(s => s.RemTimeHour)
                    .HasColumnName("RemTimeHour")
                    .IsRequired();
                Property(s => s.RemTimeMin)
                    .HasColumnName("RemTimeMin")
                    .IsRequired();
                Property(s => s.RemText)
                    .HasColumnName("RemText")
                    .IsRequired();
            }
        }
        #endregion

        public void DeleteDatabaseValues()
        {
            _user = null;
        }
    }
}