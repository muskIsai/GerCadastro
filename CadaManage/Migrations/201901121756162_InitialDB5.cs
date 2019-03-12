namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs");
            DropIndex("dbo.CadastralWorks", new[] { "fk_typeCW" });
            CreateTable(
                "dbo.LegalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        lsName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CadastralObjects", "fk_legalStatus", c => c.Int());
            AddColumn("dbo.CadastralWorks", "Application_Id", c => c.Int());
            AlterColumn("dbo.CadastralWorks", "fk_typeCW", c => c.Int());
            CreateIndex("dbo.CadastralObjects", "fk_legalStatus");
            CreateIndex("dbo.CadastralWorks", "fk_typeCW");
            CreateIndex("dbo.CadastralWorks", "Application_Id");
            AddForeignKey("dbo.CadastralObjects", "fk_legalStatus", "dbo.LegalStatus", "Id");
            AddForeignKey("dbo.CadastralWorks", "Application_Id", "dbo.Applications", "Id");
            AddForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs", "Id");
            DropColumn("dbo.CadastralObjects", "legalStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CadastralObjects", "legalStatus", c => c.String());
            DropForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs");
            DropForeignKey("dbo.CadastralWorks", "Application_Id", "dbo.Applications");
            DropForeignKey("dbo.CadastralObjects", "fk_legalStatus", "dbo.LegalStatus");
            DropIndex("dbo.CadastralWorks", new[] { "Application_Id" });
            DropIndex("dbo.CadastralWorks", new[] { "fk_typeCW" });
            DropIndex("dbo.CadastralObjects", new[] { "fk_legalStatus" });
            AlterColumn("dbo.CadastralWorks", "fk_typeCW", c => c.Int(nullable: false));
            DropColumn("dbo.CadastralWorks", "Application_Id");
            DropColumn("dbo.CadastralObjects", "fk_legalStatus");
            DropTable("dbo.LegalStatus");
            CreateIndex("dbo.CadastralWorks", "fk_typeCW");
            AddForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs", "Id", cascadeDelete: true);
        }
    }
}
