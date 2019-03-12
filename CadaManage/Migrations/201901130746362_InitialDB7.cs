namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CadastralWorks", "app_Id", "dbo.Applications");
            DropIndex("dbo.CadastralWorks", new[] { "app_Id" });
            RenameColumn(table: "dbo.CadastralWorks", name: "app_Id", newName: "fk_app");
            AlterColumn("dbo.CadastralWorks", "fk_app", c => c.Int(nullable: false));
            CreateIndex("dbo.CadastralWorks", "fk_app");
            AddForeignKey("dbo.CadastralWorks", "fk_app", "dbo.Applications", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CadastralWorks", "fk_app", "dbo.Applications");
            DropIndex("dbo.CadastralWorks", new[] { "fk_app" });
            AlterColumn("dbo.CadastralWorks", "fk_app", c => c.Int());
            RenameColumn(table: "dbo.CadastralWorks", name: "fk_app", newName: "app_Id");
            CreateIndex("dbo.CadastralWorks", "app_Id");
            AddForeignKey("dbo.CadastralWorks", "app_Id", "dbo.Applications", "Id");
        }
    }
}
