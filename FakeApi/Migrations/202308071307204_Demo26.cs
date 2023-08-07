namespace FakeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Demo26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    id = c.Int(nullable: false),
                    postId = c.Int(nullable: false),
                    name = c.String(),
                    email = c.String(),
                    body = c.String(),
                });
            //.PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Int(nullable: false),
                    Title = c.String(),
                    Body = c.String(),
                });
                //.PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
