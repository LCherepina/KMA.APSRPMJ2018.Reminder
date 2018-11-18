
using System.Data.Entity;
using Architecture_Reminder.Migrations;
using Architecture_Reminder.Models;

namespace Architecture_Reminder.Adapter
{
    internal class ReminderDBContext : DbContext
    {
        public ReminderDBContext():base("NewReminderDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ReminderDBContext, Configuration>(true));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Reminder.ReminderEntityConfiguration());
        }
    }
}
