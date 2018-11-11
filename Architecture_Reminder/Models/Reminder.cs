using System;

namespace Architecture_Reminder.Models
{
    [Serializable]
    public class Reminder : IComparable<Reminder>
    {
        public static int _id = 1;
        #region Fields
        private DateTime _dateTime;
        private int _minutes;
        private int _hours;
        private string _text;
        private int _myId;
        #endregion

        #region Properties

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
        #endregion

        #region Constructor
        //    public Reminder(DateTime dateTime, string text, User user)
        public Reminder(DateTime dateTime, int hours, int minutes, string text, User user)
        {
            _dateTime = dateTime.Date;
            _hours = hours;
            _minutes = minutes;
            _text = text;
            _myId = _id;
            _id++;
            user.Reminders.Add(this);
            user.Reminders.Sort();
        }

        private Reminder() { }
        #endregion

        public String ToString()
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
    }
}