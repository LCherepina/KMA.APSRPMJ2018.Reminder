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
            var reminderModel = new ReminderConfigurationViewModel(reminder);
            FillTimeBox();

            DataContext = reminderModel;
        }

        public void FillTimeBox()
        {

             for (int i = 0; i <= _hours; i++)
            {
                
                if (i < 10) ComboBoxHours.Items.Add("0" + i);
                else ComboBoxHours.Items.Add(i+"");
                
            }

            for (int i = 0; i <= _minutes; i++)
            {
                if (i < 10) ComboBoxMinutes.Items.Add("0" + i);
                else ComboBoxMinutes.Items.Add(i+"");

            }

            ComboBoxHours.SelectedItem = currentHour + 1;
            ComboBoxMinutes.SelectedItem = currentMinute;

        }


    }
}