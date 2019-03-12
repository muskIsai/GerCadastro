namespace CadaManage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fk_User = c.String(maxLength: 128),
                        date = c.DateTime(nullable: false),
                        fk_cadastralObject = c.Int(nullable: false),
                        fk_typeCW = c.Int(nullable: false),
                        description = c.String(),
                        fk_status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CadastralObjects", t => t.fk_cadastralObject, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.fk_status, cascadeDelete: true)
                .ForeignKey("dbo.TypeCWs", t => t.fk_typeCW, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.fk_User)
                .Index(t => t.fk_User)
                .Index(t => t.fk_cadastralObject)
                .Index(t => t.fk_typeCW)
                .Index(t => t.fk_status);
            
            CreateTable(
                "dbo.CadastralObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fk_typeCO = c.Int(),
                        cadastralNumber = c.String(),
                        dateOfEntry = c.DateTime(nullable: false),
                        legalStatus = c.String(),
                        address = c.String(),
                        preview = c.String(),
                        subPreview = c.String(),
                        square = c.Double(nullable: false),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HandBookOfCOTypes", t => t.fk_typeCO)
                .Index(t => t.fk_typeCO);
            
            CreateTable(
                "dbo.HandBookOfCOTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tHCOname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeCWs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tCWname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CadastralWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fk_typeCW = c.Int(nullable: false),
                        fk_User = c.String(maxLength: 128),
                        accounting = c.String(),
                        description = c.String(),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.fk_User)
                .ForeignKey("dbo.TypeCWs", t => t.fk_typeCW, cascadeDelete: true)
                .Index(t => t.fk_typeCW)
                .Index(t => t.fk_User);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        surname = c.String(),
                        name = c.String(),
                        patronimic = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            Sql("insert into dbo.AspNetRoles values ('1', 'Admin')");
            Sql("insert into dbo.AspNetRoles values ('2', 'Engineer')");
            Sql("insert into dbo.AspNetRoles values ('3', 'Castomer')");
            Sql("insert into dbo.AspNetRoles values ('4', 'Carlos')");
            Sql("insert into dbo.AspNetRoles values ('5', 'Vershin')");

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Applications", "fk_User", "dbo.AspNetUsers");
            DropForeignKey("dbo.CadastralWorks", "fk_typeCW", "dbo.TypeCWs");
            DropForeignKey("dbo.CadastralWorks", "fk_User", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "fk_typeCW", "dbo.TypeCWs");
            DropForeignKey("dbo.Applications", "fk_status", "dbo.Status");
            DropForeignKey("dbo.CadastralObjects", "fk_typeCO", "dbo.HandBookOfCOTypes");
            DropForeignKey("dbo.Applications", "fk_cadastralObject", "dbo.CadastralObjects");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CadastralWorks", new[] { "fk_User" });
            DropIndex("dbo.CadastralWorks", new[] { "fk_typeCW" });
            DropIndex("dbo.CadastralObjects", new[] { "fk_typeCO" });
            DropIndex("dbo.Applications", new[] { "fk_status" });
            DropIndex("dbo.Applications", new[] { "fk_typeCW" });
            DropIndex("dbo.Applications", new[] { "fk_cadastralObject" });
            DropIndex("dbo.Applications", new[] { "fk_User" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CadastralWorks");
            DropTable("dbo.TypeCWs");
            DropTable("dbo.Status");
            DropTable("dbo.HandBookOfCOTypes");
            DropTable("dbo.CadastralObjects");
            DropTable("dbo.Applications");
        }
    }
}
