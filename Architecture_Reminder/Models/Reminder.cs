using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture_Reminder.Models
{
    public class Reminder
    {

        #region Fields
        private DateTime _dateTime;
        private string _text;
        #endregion

        #region Properties
        public DateTime RemDateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        public String RemText
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion

        #region Constructor
        public Reminder(DateTime dateTime, string text, User user)
        {
            _dateTime = dateTime;
            _text = text;
            user.Reminders.Add(this);
        }

        private Reminder() { }
        #endregion

    }
}
