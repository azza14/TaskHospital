namespace TaskHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPatient1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "PatientCode", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Patients", "PatientCode");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Patients");
            AlterColumn("dbo.Patients", "PatientCode", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Patients", "PatientCode");
        }
    }
}
