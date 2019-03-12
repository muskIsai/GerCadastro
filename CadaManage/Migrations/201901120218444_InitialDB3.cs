namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PayModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cartNumber = c.String(),
                        Validity = c.DateTime(nullable: false),
                        cartName = c.String(),
                        cartCod = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Applications", "PayModel_Id", c => c.Int());
            CreateIndex("dbo.Applications", "PayModel_Id");
            AddForeignKey("dbo.Applications", "PayModel_Id", "dbo.PayModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applications", "PayModel_Id", "dbo.PayModels");
            DropIndex("dbo.Applications", new[] { "PayModel_Id" });
            DropColumn("dbo.Applications", "PayModel_Id");
            DropTable("dbo.PayModels");
        }
    }
}
