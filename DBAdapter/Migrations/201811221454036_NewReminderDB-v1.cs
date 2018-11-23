namespace Architecture_Reminder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewReminderDBv1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reminder", "MyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reminder", "MyId", c => c.Int(nullable: false));
        }
    }
}
