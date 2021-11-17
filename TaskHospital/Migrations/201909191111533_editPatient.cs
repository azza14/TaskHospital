namespace TaskHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPatient : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Patients", "TypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "TypeId", c => c.Int(nullable: false));
        }
    }
}
