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

namespace Architecture_Reminder.Views.Reminder
{
    /// <summary>
    /// Interaction logic for ReminderConfigurationView.xaml
    /// </summary>
    public partial class ReminderConfigurationView
    {
        private ReminderConfigurationViewModel reminderModel;
        #region Fields
        private int _minutes = 59;
        private int _hours = 23;
        private int currentHour = DateTime.Now.Hour;
        private int currentMinute = DateTime.Now.Minute;
        private int _id;
        #endregion
        public ReminderConfigurationView(Models.Reminder reminder)
        {
            _id = reminder.MyId;
            InitializeComponent();
           reminderModel = new ReminderConfigurationViewModel(reminder);
           FillTimeBox();

            DataContext = reminderModel;
        }

        public void FillTimeBox()
        {
            string[] hours = new string[24];
            string[] minutes = new string[60];
            for (int i = 0; i < hours.Length; i++)
            {
                if (i < 10) hours[i] = "0" + i;
                else hours[i] = i + "";
            }
            for (int i = 0; i < minutes.Length; i++)
            {
                if (i < 10) minutes[i] = "0" + i;
                else minutes[i] = i + "";
            }
            ComboBoxHours.ItemsSource = hours;
            ComboBoxMinutes.ItemsSource = minutes;

            ComboBoxHours.SelectedIndex = currentHour;
            ComboBoxMinutes.SelectedIndex = currentMinute;

        }


    }
}