namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CadastralObjects", "type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CadastralObjects", "type", c => c.String());
        }
    }
}
