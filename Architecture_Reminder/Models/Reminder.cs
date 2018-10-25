﻿using System;
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
        private int _minutes;
        private int _hours;
        private string _text;
        #endregion

        #region Properties

        public DateTime RemDate
        {
            get { return _dateTime.Date; }
            set { _dateTime = value; }
        }
        public int RemTimeHour
        {
            get { return _dateTime.Hour; }
            set { _hours = value; }
        }
        public int RemTimeMin
        {
            get { return _dateTime.Minute; }
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
        public Reminder(DateTime dateTime,  int hours , int minutes, string text)
        {
            _dateTime = dateTime.Date;
            _hours = hours;
            _minutes = minutes;
            _text = text;
         //   user.Reminders.Add(this);
        }

        private Reminder() { }
        #endregion

    }
}
