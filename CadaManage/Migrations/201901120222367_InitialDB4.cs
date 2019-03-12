namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applications", "PayModel_Id", "dbo.PayModels");
            DropIndex("dbo.Applications", new[] { "PayModel_Id" });
            AddColumn("dbo.Applications", "PayModel_cartNumber", c => c.String());
            AddColumn("dbo.Applications", "PayModel_Validity", c => c.DateTime(nullable: false));
            AddColumn("dbo.Applications", "PayModel_cartName", c => c.String());
            AddColumn("dbo.Applications", "PayModel_cartCod", c => c.String());
            DropColumn("dbo.Applications", "PayModel_Id");
            DropTable("dbo.PayModels");
        }
        
        public override void Down()
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
            DropColumn("dbo.Applications", "PayModel_cartCod");
            DropColumn("dbo.Applications", "PayModel_cartName");
            DropColumn("dbo.Applications", "PayModel_Validity");
            DropColumn("dbo.Applications", "PayModel_cartNumber");
            CreateIndex("dbo.Applications", "PayModel_Id");
            AddForeignKey("dbo.Applications", "PayModel_Id", "dbo.PayModels", "Id");
        }
    }
}
