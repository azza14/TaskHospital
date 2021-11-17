namespace TaskHospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittablestypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Patients", "TypePatients_ID", "dbo.TypePatients");
            DropIndex("dbo.Patients", new[] { "TypePatients_ID" });
            AddColumn("dbo.Patients", "TypePatients_ID1", c => c.Int());
            AlterColumn("dbo.Patients", "TypePatients_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "TypePatients_ID1");
            AddForeignKey("dbo.Patients", "TypePatients_ID1", "dbo.TypePatients", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "TypePatients_ID1", "dbo.TypePatients");
            DropIndex("dbo.Patients", new[] { "TypePatients_ID1" });
            AlterColumn("dbo.Patients", "TypePatients_ID", c => c.Int());
            DropColumn("dbo.Patients", "TypePatients_ID1");
            CreateIndex("dbo.Patients", "TypePatients_ID");
            AddForeignKey("dbo.Patients", "TypePatients_ID", "dbo.TypePatients", "ID");
        }
    }
}
