namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects");
            DropIndex("dbo.Applications", new[] { "fk_cadastralObject" });
            AddColumn("dbo.Applications", "fk_typeCO", c => c.Int());
            CreateIndex("dbo.Applications", "fk_typeCO");
            AddForeignKey("dbo.Applications", "fk_typeCO", "dbo.HandBookOfCOTypes", "Id");
            DropColumn("dbo.Applications", "fk_cadastralObject");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applications", "fk_cadastralObject", c => c.Int());
            DropForeignKey("dbo.Applications", "fk_typeCO", "dbo.HandBookOfCOTypes");
            DropIndex("dbo.Applications", new[] { "fk_typeCO" });
            DropColumn("dbo.Applications", "fk_typeCO");
            CreateIndex("dbo.Applications", "fk_cadastralObject");
            AddForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects", "Id");
        }
    }
}
