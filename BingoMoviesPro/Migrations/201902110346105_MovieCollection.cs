namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieCollection : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieCollections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovieCollections");
        }
    }
}
