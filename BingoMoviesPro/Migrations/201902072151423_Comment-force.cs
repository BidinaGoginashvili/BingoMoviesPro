namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commentforce : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        MovieMainId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.MovieMains", t => t.MovieMainId, cascadeDelete: true)
                .Index(t => t.MovieMainId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieComments", "MovieMainId", "dbo.MovieMains");
            DropForeignKey("dbo.MovieComments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MovieComments", new[] { "ApplicationUserId" });
            DropIndex("dbo.MovieComments", new[] { "MovieMainId" });
            DropTable("dbo.MovieComments");
        }
    }
}
