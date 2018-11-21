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

        private int currentHour = DateTime.Now.Hour;
        private int currentMinute = DateTime.Now.Minute;
        //private int _id;
        #endregion
        public ReminderConfigurationView(Models.Reminder reminder)
        {
            //_id = reminder.MyId;
            InitializeComponent();
           reminderModel = new ReminderConfigurationViewModel(reminder);
            DataContext = reminderModel;
        }

    }
}