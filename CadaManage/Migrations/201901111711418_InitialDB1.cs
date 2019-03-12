namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects");
            DropForeignKey("dbo.Applications", "fk_typeCW", "dbo.TypeCWs");
            DropIndex("dbo.Applications", new[] { "fk_cadastralObject" });
            DropIndex("dbo.Applications", new[] { "fk_typeCW" });
            AlterColumn("dbo.Applications", "fk_cadastralObject", c => c.Int());
            AlterColumn("dbo.Applications", "fk_typeCW", c => c.Int());
            CreateIndex("dbo.Applications", "fk_cadastralObject");
            CreateIndex("dbo.Applications", "fk_typeCW");
            AddForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects", "Id");
            AddForeignKey("dbo.Applications", "fk_typeCW", "dbo.TypeCWs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "fk_typeCW", "dbo.TypeCWs");
            DropForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects");
            DropIndex("dbo.Applications", new[] { "fk_typeCW" });
            DropIndex("dbo.Applications", new[] { "fk_cadastralObject" });
            AlterColumn("dbo.Applications", "fk_typeCW", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "fk_cadastralObject", c => c.Int(nullable: false));
            CreateIndex("dbo.Applications", "fk_typeCW");
            CreateIndex("dbo.Applications", "fk_cadastralObject");
            AddForeignKey("dbo.Applications", "fk_typeCW", "dbo.TypeCWs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects", "Id", cascadeDelete: true);
        }
    }
}
