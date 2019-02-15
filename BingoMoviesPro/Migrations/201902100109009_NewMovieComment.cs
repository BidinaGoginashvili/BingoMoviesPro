namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMovieComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieComments", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.MovieComments", new[] { "ApplicationUserId" });
            AlterColumn("dbo.MovieComments", "ApplicationUserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovieComments", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MovieComments", "ApplicationUserId");
            AddForeignKey("dbo.MovieComments", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
