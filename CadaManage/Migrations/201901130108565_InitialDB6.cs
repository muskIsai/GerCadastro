namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs");
            DropIndex("dbo.CadastralWorks", new[] { "fk_typeCW" });
            RenameColumn(table: "dbo.CadastralWorks", name: "Application_Id", newName: "app_Id");
            RenameIndex(table: "dbo.CadastralWorks", name: "IX_Application_Id", newName: "IX_app_Id");
            AddColumn("dbo.Applications", "cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.CadastralWorks", "fk_typeCW");
            DropColumn("dbo.CadastralWorks", "cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CadastralWorks", "cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.CadastralWorks", "fk_typeCW", c => c.Int());
            DropColumn("dbo.Applications", "cost");
            RenameIndex(table: "dbo.CadastralWorks", name: "IX_app_Id", newName: "IX_Application_Id");
            RenameColumn(table: "dbo.CadastralWorks", name: "app_Id", newName: "Application_Id");
            CreateIndex("dbo.CadastralWorks", "fk_typeCW");
            AddForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs", "Id");
        }
    }
}
