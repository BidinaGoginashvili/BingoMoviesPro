namespace BingoMoviesPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieActors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieMainId = c.Int(nullable: false),
                        ActorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.ActorsId, cascadeDelete: true)
                .ForeignKey("dbo.MovieMains", t => t.MovieMainId, cascadeDelete: true)
                .Index(t => t.MovieMainId)
                .Index(t => t.ActorsId);
            
            CreateTable(
                "dbo.MovieMains",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieTitleEng = c.String(),
                        MovieTitleKa = c.String(),
                        ReleaseDate = c.String(),
                        MovieLength = c.String(),
                        MovieImdb = c.Double(nullable: false),
                        MovieImgpath = c.String(),
                        MovieVdpath = c.String(),
                        budget = c.Double(nullable: false),
                        GenreId = c.Int(nullable: false),
                        DirectorsId = c.Int(nullable: false),
                        MovieGenres_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.DirectorsId, cascadeDelete: true)
                .ForeignKey("dbo.MovieGenres", t => t.MovieGenres_Id)
                .Index(t => t.DirectorsId)
                .Index(t => t.MovieGenres_Id);
            
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieActors", "MovieMainId", "dbo.MovieMains");
            DropForeignKey("dbo.MovieMains", "MovieGenres_Id", "dbo.MovieGenres");
            DropForeignKey("dbo.MovieMains", "DirectorsId", "dbo.Directors");
            DropForeignKey("dbo.MovieActors", "ActorsId", "dbo.Actors");
            DropIndex("dbo.MovieMains", new[] { "MovieGenres_Id" });
            DropIndex("dbo.MovieMains", new[] { "DirectorsId" });
            DropIndex("dbo.MovieActors", new[] { "ActorsId" });
            DropIndex("dbo.MovieActors", new[] { "MovieMainId" });
            DropTable("dbo.MovieGenres");
            DropTable("dbo.MovieMains");
            DropTable("dbo.MovieActors");
            DropTable("dbo.Directors");
            DropTable("dbo.Actors");
        }
    }
}
