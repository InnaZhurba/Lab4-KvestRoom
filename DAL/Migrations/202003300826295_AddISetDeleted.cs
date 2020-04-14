namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddISetDeleted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        min = c.Int(nullable: false),
                        max = c.Int(nullable: false),
                        KvestRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KvestRooms", t => t.KvestRoom_Id)
                .Index(t => t.KvestRoom_Id);
            
            CreateTable(
                "dbo.KvestRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UsersValueId = c.Int(nullable: false),
                        AgeCategory = c.Int(nullable: false),
                        PriceForOneUser = c.Int(nullable: false),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TimeCategoryId = c.Int(nullable: false),
                        KvestRoomId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserName = c.String(),
                        SertificateId = c.Int(nullable: false),
                        NumberOfUsers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sertificates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Sertificates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SertificateNumber = c.Int(nullable: false),
                        Shown = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TimeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.UsersValues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        min = c.Int(nullable: false),
                        max = c.Int(nullable: false),
                        KvestRoom_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KvestRooms", t => t.KvestRoom_Id)
                .Index(t => t.KvestRoom_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersValues", "KvestRoom_Id", "dbo.KvestRooms");
            DropForeignKey("dbo.TimeCategories", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.Status", "Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Id", "dbo.Sertificates");
            DropForeignKey("dbo.KvestRooms", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.AgeCategories", "KvestRoom_Id", "dbo.KvestRooms");
            DropIndex("dbo.UsersValues", new[] { "KvestRoom_Id" });
            DropIndex("dbo.TimeCategories", new[] { "Status_Id" });
            DropIndex("dbo.Orders", new[] { "Id" });
            DropIndex("dbo.Status", new[] { "Id" });
            DropIndex("dbo.KvestRooms", new[] { "Status_Id" });
            DropIndex("dbo.AgeCategories", new[] { "KvestRoom_Id" });
            DropTable("dbo.UsersValues");
            DropTable("dbo.TimeCategories");
            DropTable("dbo.Sertificates");
            DropTable("dbo.Orders");
            DropTable("dbo.Status");
            DropTable("dbo.KvestRooms");
            DropTable("dbo.AgeCategories");
            DropTable("dbo.Administrators");
        }
    }
}
